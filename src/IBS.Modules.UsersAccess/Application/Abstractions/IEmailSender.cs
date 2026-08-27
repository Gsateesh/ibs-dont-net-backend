namespace IBS.Modules.UsersAccess.Application.Abstractions;

/// <summary>
/// Outbound email (spec section 1: Azure Communication Services). Implemented in
/// IBS.Infrastructure; a logging no-op implementation is used on developer machines.
/// </summary>
public interface IEmailSender
{
    /// <summary>
    /// True when mail actually leaves the building. False for the development sender, which
    /// only logs - and which is the signal the API uses to decide whether it is safe to hand
    /// an activation link back to the caller instead.
    /// </summary>
    bool DeliversMail { get; }

    /// <summary>Sends the invite link that lets a new employee set their first password.</summary>
    Task SendInviteAsync(string toEmail, string recipientName, string activationLink, CancellationToken ct = default);

    /// <summary>Sends a password-reset link, whether admin-triggered or self-service.</summary>
    Task SendPasswordResetAsync(string toEmail, string recipientName, string resetLink, CancellationToken ct = default);
}
