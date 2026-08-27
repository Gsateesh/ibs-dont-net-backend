using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// One entry in the permission catalogue (spec section 4.4). Rows come into existence only
/// through a migration, alongside the feature they gate. The UI may rename, redescribe or
/// regroup an entry - it may never create or delete one.
/// </summary>
public class Permission : AuditableEntity
{
    /// <summary>Stable machine code, e.g. <c>manage_users</c>. Unique and never edited.</summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>Human label, e.g. "Can manage users". Editable.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Longer explanation shown next to the checkbox. Editable.</summary>
    public string? Description { get; set; }

    /// <summary>Cosmetic grouping for the checklist UI, e.g. "People &amp; access". Editable.</summary>
    public string GroupName { get; set; } = string.Empty;

    /// <summary>Sort order within the group.</summary>
    public int SortOrder { get; set; }

    /// <summary>Grants of this permission. Counting these powers the Settings page tally.</summary>
    public ICollection<EmployeePermission> EmployeePermissions { get; set; } = [];
}
