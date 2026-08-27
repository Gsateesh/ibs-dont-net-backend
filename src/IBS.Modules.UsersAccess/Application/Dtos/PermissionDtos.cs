using System.ComponentModel.DataAnnotations;

namespace IBS.Modules.UsersAccess.Application.Dtos;

/// <summary>One catalogue entry as returned by the permissions endpoint.</summary>
public sealed class PermissionResponse
{
    public Guid Id { get; set; }

    /// <summary>Stable machine code. Never editable.</summary>
    /// <example>manage_users</example>
    public string Code { get; set; } = string.Empty;

    /// <example>Can manage users</example>
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    /// <example>People and access</example>
    public string GroupName { get; set; } = string.Empty;

    /// <summary>True for manage_permissions and view_sensitive_data (spec section 5.4).</summary>
    public bool IsHighImpact { get; set; }

    /// <summary>How many employees currently hold it - the Settings page tally.</summary>
    public int HolderCount { get; set; }
}

/// <summary>The catalogue arranged by group, as the checklist UI renders it.</summary>
public sealed class PermissionGroupResponse
{
    /// <example>People and access</example>
    public string GroupName { get; set; } = string.Empty;

    public IReadOnlyList<PermissionResponse> Permissions { get; set; } = [];
}

/// <summary>Editable fields of a catalogue entry. Code is deliberately absent.</summary>
public sealed class UpdatePermissionRequest
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required, MaxLength(100)]
    public string GroupName { get; set; } = string.Empty;
}

/// <summary>A permission held by an employee, with the provenance shown on the Access tab.</summary>
public sealed class EmployeePermissionResponse
{
    public Guid PermissionId { get; set; }

    /// <example>manage_users</example>
    public string Code { get; set; } = string.Empty;

    /// <example>Can manage users</example>
    public string Name { get; set; } = string.Empty;

    public string GroupName { get; set; } = string.Empty;

    public bool IsHighImpact { get; set; }

    /// <summary>Who granted it. Null when seeded or when the holder is Super Admin.</summary>
    public string? GrantedByName { get; set; }

    public DateTimeOffset? GrantedAt { get; set; }

    /// <summary>
    /// True when the permission is implied by the Super Admin flag rather than by an
    /// EmployeePermission row (spec section 5.2).
    /// </summary>
    public bool IsImplicitFromSuperAdmin { get; set; }
}

/// <summary>The full desired permission set for an employee. Absent codes are revoked.</summary>
public sealed class UpdateEmployeePermissionsRequest
{
    /// <summary>
    /// Complete list of codes the employee should hold after this call.
    /// Adding manage_permissions or view_sensitive_data requires the caller to hold
    /// manage_permissions (spec section 5.4).
    /// </summary>
    /// <example>["manage_users","view_reports"]</example>
    [Required]
    public IReadOnlyList<string> PermissionCodes { get; set; } = [];
}
