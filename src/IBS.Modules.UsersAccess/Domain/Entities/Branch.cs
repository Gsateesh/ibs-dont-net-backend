using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// A physical office. Seeded with Bengaluru, Chennai and Pune (spec section 4.1).
/// Editable in Settings by anyone holding manage_company_settings; deletion is blocked
/// while any employee still references it.
/// </summary>
public class Branch : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string? City { get; set; }

    public string? Address { get; set; }

    /// <summary>IANA timezone id, e.g. Asia/Kolkata.</summary>
    public string Timezone { get; set; } = "Asia/Kolkata";

    /// <summary>Employees posted to this branch. Used for the in-use check before deletion.</summary>
    public ICollection<Employee> Employees { get; set; } = [];
}
