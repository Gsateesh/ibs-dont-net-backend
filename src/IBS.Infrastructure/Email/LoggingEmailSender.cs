using IBS.Modules.UsersAccess.Application.Abstractions;
using Microsoft.Extensions.Logging;

namespace IBS.Infrastructure.Email;

/// <summary>
/// Development stand-in for <see cref="AcsEmailSender"/>: writes the link to the log instead
/// of sending mail, so the invite and reset flows can be walked end to end with no ACS resource.
/// Registered only when no ACS connection string is configured.
/// </summary>
public sealed class LoggingEmailSender(ILogger<LoggingEmailSender> logger) : IEmailSender
{
    /// <inheritdoc />
    public bool DeliversMail => false;

    public Task SendInviteAsync(string toEmail, string recipientName, string activationLink, CancellationToken ct = default)
    {
        logger.LogWarning(
            "Email is not configured. Invite for {Email} would link to: {Link}", toEmail, activationLink);
        return Task.CompletedTask;
    }

    public Task SendPasswordResetAsync(string toEmail, string recipientName, string resetLink, CancellationToken ct = default)
    {
        logger.LogWarning(
            "Email is not configured. Password reset for {Email} would link to: {Link}", toEmail, resetLink);
        return Task.CompletedTask;
    }
}
