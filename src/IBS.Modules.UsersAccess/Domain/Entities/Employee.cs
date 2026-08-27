using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// A person with an account. This is the only login identity in the system - there is no
/// separate user table and no role table (spec sections 4.2 and 5.1).
/// </summary>
public class Employee : AuditableEntity
{
    // --- Section 1: core identity -------------------------------------------------

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    /// <summary>Convenience projection, not mapped to a column.</summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    /// <summary>The login identifier. Unique; there is no separate username field.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Contact number only - never used for authentication.</summary>
    public string? Mobile { get; set; }

    /// <summary>Blob Storage reference for the profile photo.</summary>
    public string? PhotoUrl { get; set; }

    // --- Section 2: employment ----------------------------------------------------

    /// <summary>Auto-generated as EMP-0001 and upward, but editable.</summary>
    public string EmployeeCode { get; set; } = string.Empty;

    public DateOnly DateOfJoining { get; set; }

    public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime;

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public Guid DesignationId { get; set; }

    public Designation? Designation { get; set; }

    public Guid BranchId { get; set; }

    public Branch? Branch { get; set; }

    /// <summary>
    /// Self-referencing manager link. Any assignment that would create a reporting cycle
    /// is rejected at the API layer (spec section 4.2).
    /// </summary>
    public Guid? ReportingManagerId { get; set; }

    public Employee? ReportingManager { get; set; }

    /// <summary>People who report to this employee.</summary>
    public ICollection<Employee> DirectReports { get; set; } = [];

    // --- Account state ------------------------------------------------------------

    public EmployeeStatus Status { get; set; } = EmployeeStatus.Invited;

    /// <summary>
    /// Null until the person sets it themselves through an activation or reset token
    /// (spec section 6). The seed tool is the only other writer of this column.
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>Forces a password change on next login when true.</summary>
    public bool MustChangePassword { get; set; }

    /// <summary>
    /// Bypasses every permission check (spec section 5.2). A flag, not a permission.
    /// Exactly one row in the table may carry it - enforced by a filtered unique index.
    /// </summary>
    public bool IsSuperAdmin { get; set; }

    // --- Login throttling (spec section 6.5) --------------------------------------

    /// <summary>Consecutive failed sign-in attempts since the last success.</summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>When the current lockout expires. Null when not locked out.</summary>
    public DateTimeOffset? LockoutEndsAt { get; set; }

    /// <summary>Timestamp of the first failure in the current counting window.</summary>
    public DateTimeOffset? FirstFailedLoginAt { get; set; }

    /// <summary>Last time this employee was seen making an authenticated request.</summary>
    public DateTimeOffset? LastSeenAt { get; set; }

    // --- Optional detail (spec section 4.3) ---------------------------------------

    public EmployeeProfessionalProfile? ProfessionalProfile { get; set; }

    /// <summary>Restricted record - see spec sections 4.3 and 5.5.</summary>
    public EmployeeStatutory? Statutory { get; set; }

    public EmployeeTargets? Targets { get; set; }

    public ICollection<EmployeeDocument> Documents { get; set; } = [];

    /// <summary>Granted permissions. The only source of access besides <see cref="IsSuperAdmin"/>.</summary>
    public ICollection<EmployeePermission> Permissions { get; set; } = [];

    /// <summary>Invite and reset tokens issued for this employee.</summary>
    public ICollection<ActivationToken> ActivationTokens { get; set; } = [];

    /// <summary>True when the account is currently locked out of sign-in.</summary>
    public bool IsLockedOut(DateTimeOffset now) => LockoutEndsAt is not null && LockoutEndsAt > now;
}
