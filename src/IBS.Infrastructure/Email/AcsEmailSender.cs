using Azure;
using Azure.Communication.Email;
using IBS.Modules.UsersAccess.Application.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IBS.Infrastructure.Email;

/// <summary>
/// Sends invite and reset mail through Azure Communication Services (spec section 1).
/// </summary>
public sealed class AcsEmailSender(
    IOptions<EmailOptions> options,
    ILogger<AcsEmailSender> logger) : IEmailSender
{
    /// <inheritdoc />
    public bool DeliversMail => true;

    private readonly EmailOptions _options = options.Value;
    private readonly EmailClient _client = new(options.Value.ConnectionString);

    public Task SendInviteAsync(string toEmail, string recipientName, string activationLink, CancellationToken ct = default)
    {
        var subject = "Set up your IBS account";
        var body = $"""
            <p>Hello {recipientName},</p>
            <p>An IBS account has been created for you. Choose a password to finish setting it up:</p>
            <p><a href="{activationLink}">Set my password</a></p>
            <p>This link can only be used once, and it expires shortly.
               If you were not expecting it, you can ignore this message.</p>
            """;

        return SendAsync(toEmail, subject, body, ct);
    }

    public Task SendPasswordResetAsync(string toEmail, string recipientName, string resetLink, CancellationToken ct = default)
    {
        var subject = "Reset your IBS password";
        var body = $"""
            <p>Hello {recipientName},</p>
            <p>Use the link below to choose a new password:</p>
            <p><a href="{resetLink}">Reset my password</a></p>
            <p>This link can only be used once, and it expires shortly.
               If you did not ask for it, nothing has changed on your account.</p>
            """;

        return SendAsync(toEmail, subject, body, ct);
    }

    private async Task SendAsync(string toEmail, string subject, string html, CancellationToken ct)
    {
        var message = new EmailMessage(
            senderAddress: _options.SenderAddress,
            content: new EmailContent(subject) { Html = html },
            recipients: new EmailRecipients([new EmailAddress(toEmail)]));

        // Started, not awaited to completion: delivery status is ACS business, not the business
        // of the HTTP request that triggered it.
        await _client.SendAsync(WaitUntil.Started, message, ct);
        logger.LogInformation("Queued a {Subject} email through Azure Communication Services.", subject);
    }
}
