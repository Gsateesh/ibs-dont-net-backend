namespace IBS.Modules.UsersAccess.Application.Options;

/// <summary>
/// Tunables for the users and access module, bound from the <c>UsersAccess</c> configuration section.
/// </summary>
public sealed class UsersAccessOptions
{
    public const string SectionName = "UsersAccess";

    /// <summary>Base URL the invite and reset links point at, e.g. https://ibs.example.com.</summary>
    public string AppBaseUrl { get; set; } = "https://localhost:5001";

    /// <summary>Frontend route that redeems an invite token.</summary>
    public string ActivationPath { get; set; } = "/activate";

    /// <summary>Frontend route that redeems a reset token.</summary>
    public string PasswordResetPath { get; set; } = "/reset-password";

    /// <summary>Lifetime of an invite token.</summary>
    public TimeSpan InviteTokenLifetime { get; set; } = TimeSpan.FromDays(7);

    /// <summary>Lifetime of a password-reset token.</summary>
    public TimeSpan ResetTokenLifetime { get; set; } = TimeSpan.FromHours(2);

    /// <summary>Failed sign-in attempts tolerated before lockout (spec section 6.5).</summary>
    public int MaxFailedLoginAttempts { get; set; } = 5;

    /// <summary>Window over which failed attempts are counted.</summary>
    public TimeSpan FailedLoginWindow { get; set; } = TimeSpan.FromMinutes(15);

    /// <summary>How long a locked-out account stays locked (spec section 6.5).</summary>
    public TimeSpan LockoutDuration { get; set; } = TimeSpan.FromMinutes(15);

    /// <summary>Minimum length enforced when a password is set or changed.</summary>
    public int MinimumPasswordLength { get; set; } = 10;

    /// <summary>Blob container holding employee photos.</summary>
    public string PhotoContainer { get; set; } = "employee-photos";

    /// <summary>Blob container holding employee documents.</summary>
    public string DocumentContainer { get; set; } = "employee-documents";

    /// <summary>Prefix used when auto-generating employee codes.</summary>
    public string EmployeeCodePrefix { get; set; } = "EMP-";
}
