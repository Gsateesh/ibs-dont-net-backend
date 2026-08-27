using System.ComponentModel.DataAnnotations;
using IBS.Modules.Sales.Domain.Enums;

namespace IBS.Modules.Sales.Application.Dtos;

/// <summary>One row of the Leads list.</summary>
public sealed class LeadListItemResponse
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string PropertyName { get; set; } = string.Empty;

    public string PropertyAddress { get; set; } = string.Empty;

    public PropertyType PropertyType { get; set; }

    public decimal? BudgetMin { get; set; }

    public decimal? BudgetMax { get; set; }

    public LeadStatus Status { get; set; }

    public Guid? AssignedToEmployeeId { get; set; }

    public string? AssignedToName { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
}

/// <summary>The Lead Detail view of one lead.</summary>
public sealed class LeadDetailResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? SecondaryPhone { get; set; }
    public string? Notes { get; set; }

    public string PropertyName { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
    public PropertyType PropertyType { get; set; }
    public decimal? BudgetMin { get; set; }
    public decimal? BudgetMax { get; set; }
    public LeadStatus Status { get; set; }

    /// <summary>
    /// Current assignment, with provenance. Populated only for callers who hold manage_leads
    /// (or are Super Admin) - see <see cref="LeadCapabilities.CanViewAssignmentHistory"/>.
    /// </summary>
    public Guid? AssignedToEmployeeId { get; set; }
    public string? AssignedToName { get; set; }
    public Guid? AssignedByEmployeeId { get; set; }
    public string? AssignedByName { get; set; }
    public DateTimeOffset? AssignedAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedByName { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedByName { get; set; }

    /// <summary>
    /// What the calling employee is allowed to do with this lead, so the UI can disable
    /// buttons the API would reject anyway.
    /// </summary>
    public LeadCapabilities Capabilities { get; set; } = new();
}

/// <summary>Server-computed answer to the question of what the caller may do here.</summary>
public sealed class LeadCapabilities
{
    public bool CanEdit { get; set; }
    public bool CanDelete { get; set; }
    public bool CanReassign { get; set; }
    public bool CanViewAssignmentHistory { get; set; }
}

/// <summary>Fields accepted when creating a lead.</summary>
public sealed class CreateLeadRequest
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required, Phone, MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Phone, MaxLength(20)]
    public string? SecondaryPhone { get; set; }

    [MaxLength(2000)]
    public string? Notes { get; set; }

    [Required, MaxLength(200)]
    public string PropertyName { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string PropertyAddress { get; set; } = string.Empty;

    [Required]
    public PropertyType PropertyType { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMin { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMax { get; set; }

    /// <summary>
    /// Optional assignment at creation. Ignored (the lead is created unassigned) unless the
    /// caller holds manage_leads - a plain employee cannot assign a lead to anyone, including
    /// themself, by way of this field.
    /// </summary>
    public Guid? AssignedToEmployeeId { get; set; }
}

/// <summary>
/// Fields accepted when editing a lead. Assignment is deliberately excluded - reassigning a
/// lead only ever happens through the dedicated assign/unassign/bulk-assign endpoints.
/// </summary>
public sealed class UpdateLeadRequest
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required, Phone, MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Phone, MaxLength(20)]
    public string? SecondaryPhone { get; set; }

    [MaxLength(2000)]
    public string? Notes { get; set; }

    [Required, MaxLength(200)]
    public string PropertyName { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string PropertyAddress { get; set; } = string.Empty;

    [Required]
    public PropertyType PropertyType { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMin { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMax { get; set; }

    [Required]
    public LeadStatus Status { get; set; }
}

/// <summary>Filters for the Leads list. All are optional and combine with AND.</summary>
public sealed class LeadQuery
{
    public LeadStatus? Status { get; set; }

    public PropertyType? PropertyType { get; set; }

    /// <summary>
    /// Restrict to one assignee. Only effective for callers who hold manage_leads - for anyone
    /// else the list is always forced to their own assigned leads regardless of this value.
    /// </summary>
    public Guid? AssignedToEmployeeId { get; set; }

    /// <summary>Free-text match over name, email, property name and property address.</summary>
    [MaxLength(100)]
    public string? Search { get; set; }

    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    [Range(1, 200)]
    public int PageSize { get; set; } = 25;
}

/// <summary>Assigns one lead to one employee.</summary>
public sealed class AssignLeadRequest
{
    [Required]
    public Guid AssignedToEmployeeId { get; set; }
}

/// <summary>Assigns many leads to one employee in a single action.</summary>
public sealed class BulkAssignLeadsRequest
{
    [Required, MinLength(1)]
    public List<Guid> LeadIds { get; set; } = [];

    [Required]
    public Guid AssignedToEmployeeId { get; set; }
}

/// <summary>Outcome of a bulk assignment.</summary>
public sealed class BulkAssignResult
{
    public int UpdatedCount { get; set; }

    /// <summary>Requested lead ids that did not exist and were skipped.</summary>
    public IReadOnlyList<Guid> SkippedLeadIds { get; set; } = [];
}

/// <summary>One employee selectable as a lead's assignee.</summary>
public sealed class AssignableEmployeeResponse
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}

/// <summary>One entry in a lead's assignment history.</summary>
public sealed class LeadAssignmentHistoryEntry
{
    public Guid Id { get; set; }

    public string Action { get; set; } = string.Empty;

    public Guid? ActorEmployeeId { get; set; }

    public string? ActorName { get; set; }

    public DateTimeOffset Timestamp { get; set; }

    public string? MetadataJson { get; set; }
}
