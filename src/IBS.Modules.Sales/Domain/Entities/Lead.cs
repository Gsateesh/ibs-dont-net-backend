using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// A prospective customer captured against a property interest. Assigned to at most one
/// employee at a time; deliberately no navigation property to Employee, which lives in the
/// UsersAccess module - the assignment columns are plain, unconstrained ids (see IEmployeeDirectory).
/// </summary>
public class Lead : AuditableEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    /// <summary>Convenience projection, not mapped to a column.</summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string? SecondaryPhone { get; set; }

    public string? Notes { get; set; }

    public string PropertyName { get; set; } = string.Empty;

    public string PropertyAddress { get; set; } = string.Empty;

    public PropertyType PropertyType { get; set; }

    public decimal? BudgetMin { get; set; }

    public decimal? BudgetMax { get; set; }

    public LeadStatus Status { get; set; } = LeadStatus.New;

    /// <summary>The employee this lead is currently assigned to. Null when unassigned.</summary>
    public Guid? AssignedToEmployeeId { get; set; }

    /// <summary>Who made the current assignment.</summary>
    public Guid? AssignedByEmployeeId { get; set; }

    /// <summary>When the current assignment was made.</summary>
    public DateTimeOffset? AssignedAt { get; set; }
}
