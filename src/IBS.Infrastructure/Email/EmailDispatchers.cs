using Azure;
using Azure.Communication.Email;
using IBS.SharedKernel.Notifications;
using IBS.SharedKernel.Time;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using AcsEmailMessage = Azure.Communication.Email.EmailMessage;
using IbsEmailMessage = IBS.SharedKernel.Notifications.EmailMessage;

namespace IBS.Infrastructure.Email;

/// <summary>
/// Sends through Azure Communication Services. Registered only when a connection string is
/// configured; otherwise <see cref="LoggingEmailDispatcher"/> stands in.
/// </summary>
public sealed class AcsEmailDispatcher(
    IOptions<EmailOptions> options,
    ILogger<AcsEmailDispatcher> logger) : IEmailDispatcher
{
    private readonly EmailOptions _options = options.Value;
    private readonly EmailClient _client = new(options.Value.ConnectionString);

    public bool DeliversMail => true;

    public async Task<EmailDeliveryResult> SendAsync(IbsEmailMessage message, CancellationToken ct = default)
    {
        try
        {
            var acs = new AcsEmailMessage(
                senderAddress: _options.SenderAddress,
                content: new EmailContent(message.Subject) { Html = message.HtmlBody },
                recipients: new EmailRecipients([new EmailAddress(message.ToEmail, message.ToName)]));

            foreach (var attachment in message.Attachments)
            {
                acs.Attachments.Add(new Azure.Communication.Email.EmailAttachment(
                    attachment.FileName, attachment.ContentType, new BinaryData(attachment.Content)));
            }

            // Started, not awaited to completion: delivery is ACS business, not the business of
            // the HTTP request that triggered it. The operation id is kept so a delivery report
            // could be reconciled against it later.
            var operation = await _client.SendAsync(WaitUntil.Started, acs, ct);

            logger.LogInformation(
                "Queued a {Kind} email to {Email} through Azure Communication Services.",
                message.Kind, message.ToEmail);

            return EmailDeliveryResult.Queued(operation.Id);
        }
        catch (Exception ex) when (ex is RequestFailedException or InvalidOperationException)
        {
            // Swallowed on purpose. The caller has usually already committed the work the mail
            // was about, and losing a saved quotation because a mail server was unreachable
            // would be a worse outcome than an email that has to be resent.
            logger.LogError(ex, "Sending a {Kind} email to {Email} failed.", message.Kind, message.ToEmail);

            return EmailDeliveryResult.Failed(ex.Message);
        }
    }
}

/// <summary>
/// Development stand-in: writes the message to the log instead of sending it, so the invite,
/// reset and quotation flows can be walked end to end with no ACS resource.
/// </summary>
public sealed class LoggingEmailDispatcher(ILogger<LoggingEmailDispatcher> logger) : IEmailDispatcher
{
    public bool DeliversMail => false;

    public Task<EmailDeliveryResult> SendAsync(IbsEmailMessage message, CancellationToken ct = default)
    {
        logger.LogWarning(
            "Email is not configured. A {Kind} message to {Email} was suppressed. Subject: {Subject}. Attachments: {Attachments}.",
            message.Kind,
            message.ToEmail,
            message.Subject,
            message.Attachments.Count == 0
                ? "none"
                : string.Join(", ", message.Attachments.Select(a => a.FileName)));

        return Task.FromResult(EmailDeliveryResult.Suppressed());
    }
}

/// <summary>
/// Wraps whichever dispatcher is in play and records every message in <see cref="EmailLog"/>.
/// </summary>
/// <remarks>
/// A decorator rather than a call inside each feature, so mail is logged because it was sent
/// and not because somebody remembered to log it. The row is written whatever the outcome - a
/// refused send is precisely the one worth having a record of.
/// </remarks>
public sealed class EmailLoggingDispatcher(
    IEmailDispatcher inner,
    Persistence.IbsDbContext db,
    IClock clock,
    ILogger<EmailLoggingDispatcher> logger) : IEmailDispatcher
{
    public bool DeliversMail => inner.DeliversMail;

    public async Task<EmailDeliveryResult> SendAsync(IbsEmailMessage message, CancellationToken ct = default)
    {
        var result = await inner.SendAsync(message, ct);
        var now = clock.UtcNow;

        var log = new EmailLog
        {
            ToEmail = message.ToEmail,
            ToName = message.ToName,
            Subject = message.Subject,
            Kind = message.Kind,
            RelatedEntityType = message.RelatedEntityType,
            RelatedEntityId = message.RelatedEntityId,
            AttachmentCount = message.Attachments.Count,
            AttachmentNames = message.Attachments.Count == 0
                ? null
                : Truncate(string.Join(", ", message.Attachments.Select(a => a.FileName)), 1000),
            Status = result.Status,
            ProviderMessageId = result.ProviderMessageId,
            Error = Truncate(result.Error, 2000),
            SentByEmployeeId = message.SentByEmployeeId,
            SentAt = now,
            CreatedAt = now,
            CreatedByEmployeeId = message.SentByEmployeeId
        };

        try
        {
            db.EmailLogs.Add(log);
            await db.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            // The message may well have gone out already. Failing the caller now would report a
            // send that succeeded as a failure, which is the more damaging of the two mistakes.
            logger.LogError(ex, "Could not write the email log row for a {Kind} message.", message.Kind);
        }

        return result;
    }

    private static string? Truncate(string? value, int max) =>
        value is null || value.Length <= max ? value : value[..max];
}
