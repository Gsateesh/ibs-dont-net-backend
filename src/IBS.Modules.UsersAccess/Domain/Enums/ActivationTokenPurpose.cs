namespace IBS.Modules.UsersAccess.Domain.Enums;

/// <summary>What an activation token is for (spec section 4.5).</summary>
public enum ActivationTokenPurpose
{
    /// <summary>First-time account setup, emailed when the employee row is created.</summary>
    Invite = 1,

    /// <summary>Password reset, whether admin-triggered or self-service.</summary>
    Reset = 2
}
