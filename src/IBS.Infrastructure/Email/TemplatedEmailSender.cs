using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.SharedKernel.Notifications;

namespace IBS.Infrastructure.Email;

/// <summary>
/// The account mail UsersAccess sends - invites and password resets - written as templates over
/// <see cref="IEmailDispatcher"/>.
/// </summary>
/// <remarks>
/// Replaces the pair of senders that each spoke to a transport directly. Routing both through
/// the dispatcher means the wording lives in one place and, more usefully, that account mail is
/// recorded in <see cref="EmailLog"/> on the same terms as everything else.
/// </remarks>
public sealed class TemplatedEmailSender(IEmailDispatcher dispatcher) : IEmailSender
{
    /// <inheritdoc />
    public bool DeliversMail => dispatcher.DeliversMail;

    public Task SendInviteAsync(
        string toEmail, string recipientName, string activationLink, CancellationToken ct = default)
    {
        var body = $"""
            <p>Hello {recipientName},</p>
            <p>An IBS account has been created for you. Choose a password to finish setting it up:</p>
            <p><a href="{activationLink}">Set my password</a></p>
            <p>This link can only be used once, and it expires shortly.
               If you were not expecting it, you can ignore this message.</p>
            """;

        return dispatcher.SendAsync(
            new EmailMessage
            {
                ToEmail = toEmail,
                ToName = recipientName,
                Subject = "Set up your IBS account",
                HtmlBody = body,
                Kind = "account.invite"
            }, ct);
    }

    public Task SendPasswordResetAsync(
        string toEmail, string recipientName, string resetLink, CancellationToken ct = default)
    {
        var body = $"""
            <p>Hello {recipientName},</p>
            <p>Use the link below to choose a new password:</p>
            <p><a href="{resetLink}">Reset my password</a></p>
            <p>This link can only be used once, and it expires shortly.
               If you did not ask for it, nothing has changed on your account.</p>
            """;

        return dispatcher.SendAsync(
            new EmailMessage
            {
                ToEmail = toEmail,
                ToName = recipientName,
                Subject = "Reset your IBS password",
                HtmlBody = body,
                Kind = "account.password_reset"
            }, ct);
    }
}
