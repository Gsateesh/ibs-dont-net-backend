using System.ComponentModel.DataAnnotations;
using IBS.Modules.UsersAccess.Domain.Enums;

namespace IBS.Modules.UsersAccess.Application.Dtos;

/// <summary>One row of the Team list.</summary>
public sealed class EmployeeListItemResponse
{
    public Guid Id { get; set; }

    /// <example>Asha Nair</example>
    public string FullName { get; set; } = string.Empty;

    /// <example>asha.nair@ibs.example.com</example>
    public string Email { get; set; } = string.Empty;

    /// <example>EMP-0007</example>
    public string EmployeeCode { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }

    /// <example>Design Head</example>
    public string Designation { get; set; } = string.Empty;

    /// <example>Design</example>
    public string Department { get; set; } = string.Empty;

    /// <example>Bengaluru</example>
    public string Branch { get; set; } = string.Empty;

    public EmployeeStatus Status { get; set; }

    public bool IsSuperAdmin { get; set; }

    public string? ReportingManagerName { get; set; }

    public DateTimeOffset? LastSeenAt { get; set; }
}

/// <summary>The Person Detail view of one employee.</summary>
public sealed class EmployeeDetailResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public string? PhotoUrl { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public DateOnly DateOfJoining { get; set; }
    public EmploymentType EmploymentType { get; set; }

    public Guid DepartmentId { get; set; }
    public string Department { get; set; } = string.Empty;
    public Guid DesignationId { get; set; }
    public string Designation { get; set; } = string.Empty;
    public Guid BranchId { get; set; }
    public string Branch { get; set; } = string.Empty;

    public Guid? ReportingManagerId { get; set; }
    public string? ReportingManagerName { get; set; }

    public EmployeeStatus Status { get; set; }
    public bool IsSuperAdmin { get; set; }
    public bool MustChangePassword { get; set; }
    public DateTimeOffset? LastSeenAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedByName { get; set; }

    /// <summary>Optional professional detail, absent when never filled in.</summary>
    public ProfessionalProfileDto? ProfessionalProfile { get; set; }

    /// <summary>Optional sales targets, absent for non-sales designations.</summary>
    public EmployeeTargetsDto? Targets { get; set; }

    /// <summary>
    /// The activation link, present only in the response to creating this person - and only
    /// while outbound email is unconfigured. Never returned when reading an employee.
    /// </summary>
    public InvitationLinkResponse? Invitation { get; set; }

    /// <summary>Permission grants held by this employee, with their provenance.</summary>
    public IReadOnlyList<EmployeePermissionResponse> Permissions { get; set; } = [];

    /// <summary>
    /// What the calling user is allowed to do with this account, so the UI can disable
    /// buttons the API would reject anyway (spec sections 5.3 and 5.6).
    /// </summary>
    public EmployeeCapabilities Capabilities { get; set; } = new();
}

/// <summary>Server-computed answer to the question of what the caller may do here.</summary>
public sealed class EmployeeCapabilities
{
    /// <summary>True when the caller may edit this account.</summary>
    public bool CanEdit { get; set; }

    /// <summary>True when the caller may suspend, reinstate or deactivate this account.</summary>
    public bool CanChangeStatus { get; set; }

    /// <summary>True when the caller may resend the invite (status must be Invited).</summary>
    public bool CanResendInvite { get; set; }

    /// <summary>True when the caller may trigger a password reset email.</summary>
    public bool CanResetPassword { get; set; }

    /// <summary>True when the caller may change the permission set of this account.</summary>
    public bool CanManagePermissions { get; set; }

    /// <summary>True when the caller may read the statutory record (spec section 5.5).</summary>
    public bool CanViewStatutory { get; set; }
}

/// <summary>Fields accepted when creating a person (Add Person, spec section 6.2).</summary>
public sealed class CreateEmployeeRequest
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>Must be unique - it is the login identifier.</summary>
    /// <example>asha.nair@ibs.example.com</example>
    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    [Phone, MaxLength(20)]
    public string? Mobile { get; set; }

    public string? PhotoUrl { get; set; }

    /// <summary>Leave null to auto-generate the next code in sequence.</summary>
    /// <example>EMP-0007</example>
    [MaxLength(30)]
    public string? EmployeeCode { get; set; }

    [Required]
    public DateOnly DateOfJoining { get; set; }

    [Required]
    public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime;

    [Required]
    public Guid DepartmentId { get; set; }

    [Required]
    public Guid DesignationId { get; set; }

    [Required]
    public Guid BranchId { get; set; }

    /// <summary>Rejected when the assignment would create a reporting cycle.</summary>
    public Guid? ReportingManagerId { get; set; }

    /// <summary>Optional professional detail (section 4 of the Add Person form).</summary>
    public ProfessionalProfileDto? ProfessionalProfile { get; set; }

    /// <summary>Optional sales targets, meaningful only for sales designations.</summary>
    public EmployeeTargetsDto? Targets { get; set; }

    /// <summary>Optional statutory record. Requires view_sensitive_data or Super Admin.</summary>
    public StatutoryDto? Statutory { get; set; }

    /// <summary>
    /// Permission codes to grant at creation. Granting manage_permissions or
    /// view_sensitive_data additionally requires the caller to hold manage_permissions
    /// (spec section 5.4).
    /// </summary>
    public IReadOnlyList<string> PermissionCodes { get; set; } = [];
}

/// <summary>Fields accepted when an administrator edits a person.</summary>
public sealed class UpdateEmployeeRequest
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Phone, MaxLength(20)]
    public string? Mobile { get; set; }

    public string? PhotoUrl { get; set; }

    [Required, MaxLength(30)]
    public string EmployeeCode { get; set; } = string.Empty;

    [Required]
    public DateOnly DateOfJoining { get; set; }

    [Required]
    public EmploymentType EmploymentType { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }

    [Required]
    public Guid DesignationId { get; set; }

    [Required]
    public Guid BranchId { get; set; }

    public Guid? ReportingManagerId { get; set; }

    public ProfessionalProfileDto? ProfessionalProfile { get; set; }

    public EmployeeTargetsDto? Targets { get; set; }
}

/// <summary>
/// The narrower set of fields an employee may change on their own profile.
/// Designation, permissions and status are deliberately absent (spec section 5.6).
/// </summary>
public sealed class UpdateMyProfileRequest
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Phone, MaxLength(20)]
    public string? Mobile { get; set; }

    public string? PhotoUrl { get; set; }

    public ProfessionalProfileDto? ProfessionalProfile { get; set; }
}

/// <summary>Optional professional detail (spec section 4.3).</summary>
public sealed class ProfessionalProfileDto
{
    /// <example>B.Arch</example>
    [MaxLength(200)] public string? Qualification { get; set; }

    /// <example>Residential interiors</example>
    [MaxLength(200)] public string? Specialisation { get; set; }

    [Range(0, 60)] public int? ExperienceYears { get; set; }

    public List<string> SoftwareSkills { get; set; } = [];

    public List<string> Certifications { get; set; } = [];

    [Url, MaxLength(500)] public string? PortfolioLink { get; set; }

    public List<string> Languages { get; set; } = [];
}

/// <summary>Optional sales targets (spec section 4.3).</summary>
public sealed class EmployeeTargetsDto
{
    [Range(0, double.MaxValue)] public decimal? MonthlyTarget { get; set; }

    [Range(0, 100)] public decimal? IncentivePercent { get; set; }

    [Range(0, 100)] public decimal? MaxDiscountBeforeEscalation { get; set; }

    public List<string> Territories { get; set; } = [];
}

/// <summary>Restricted statutory record (spec sections 4.3 and 5.5).</summary>
public sealed class StatutoryDto
{
    /// <example>ABCDE1234F</example>
    [MaxLength(10)] public string? Pan { get; set; }

    /// <example>1234 5678 9012</example>
    [MaxLength(20)] public string? Aadhaar { get; set; }

    [MaxLength(30)] public string? PfUan { get; set; }

    [MaxLength(30)] public string? Esic { get; set; }

    [MaxLength(500)] public string? BankDetails { get; set; }

    [Range(0, double.MaxValue)] public decimal? Ctc { get; set; }
}

/// <summary>Filters for the Team list. All are optional and combine with AND.</summary>
public sealed class EmployeeQuery
{
    /// <summary>Restrict to one lifecycle state.</summary>
    public EmployeeStatus? Status { get; set; }

    public Guid? DepartmentId { get; set; }

    public Guid? BranchId { get; set; }

    public Guid? DesignationId { get; set; }

    /// <summary>Free-text match over name, email and employee code.</summary>
    /// <example>nair</example>
    [MaxLength(100)]
    public string? Search { get; set; }

    /// <summary>1-based page number.</summary>
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    /// <summary>Rows per page, capped at 200.</summary>
    [Range(1, 200)]
    public int PageSize { get; set; } = 25;
}

/// <summary>Reason recorded alongside a status change.</summary>
public sealed class StatusChangeRequest
{
    /// <summary>Optional note stored in the audit log.</summary>
    /// <example>Long leave of absence</example>
    [MaxLength(500)]
    public string? Reason { get; set; }
}

/// <summary>
/// Result of a deactivation, including the open-work check other modules will eventually
/// fill in (spec section 7 - stubbed as a no-op for now).
/// </summary>
public sealed class DeactivationResponse
{
    public Guid EmployeeId { get; set; }

    public EmployeeStatus Status { get; set; }

    /// <summary>True when open work was found and must be reassigned first.</summary>
    public bool ReassignmentRequired { get; set; }

    /// <summary>Human-readable description of what still needs reassigning.</summary>
    public IReadOnlyList<string> OpenWorkItems { get; set; } = [];
}

/// <summary>What a hard delete removed, so the caller can report it honestly.</summary>
public sealed class DeleteEmployeeResponse
{
    /// <summary>The employee that no longer exists.</summary>
    public Guid EmployeeId { get; set; }

    /// <summary>Their email, kept here because the row is gone by the time this is returned.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Rows removed by cascade, keyed by what they were.</summary>
    public IReadOnlyDictionary<string, int> DeletedRelated { get; set; } =
        new Dictionary<string, int>();

    /// <summary>
    /// References that were detached rather than deleted: direct reports whose reporting line
    /// was cleared, permission grants issued by this person, and audit entries they authored.
    /// </summary>
    public IReadOnlyDictionary<string, int> Detached { get; set; } =
        new Dictionary<string, int>();

    /// <summary>Blob Storage files that could not be removed, if any. Empty in the normal case.</summary>
    public IReadOnlyList<string> OrphanedFiles { get; set; } = [];
}
