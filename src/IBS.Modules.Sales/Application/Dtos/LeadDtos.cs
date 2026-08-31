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

    public LeadPhase Phase { get; set; }

    public LeadOverallStatus OverallStatus { get; set; }

    public bool IsInterested { get; set; }

    /// <summary>Whether a floor plan is on file, without carrying the image or its reference.</summary>
    public bool HasFloorPlan { get; set; }

    public DateOnly? NextFollowUpDate { get; set; }

    /// <summary>Null when no quotation has gone out. The list shows this as a tick.</summary>
    public DateOnly? QuotationSharedAt { get; set; }

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
    public decimal? PropertySize { get; set; }
    public PropertySizeUnit? PropertySizeUnit { get; set; }
    public PropertyConfiguration? PropertyConfiguration { get; set; }
    public decimal? BudgetMin { get; set; }
    public decimal? BudgetMax { get; set; }
    public LeadPhase Phase { get; set; }

    public DateOnly? ContactedDate { get; set; }
    public DateOnly? NextFollowUpDate { get; set; }
    public DateOnly? QuotationSharedAt { get; set; }
    public bool IsInterested { get; set; }
    public LeadOverallStatus OverallStatus { get; set; }

    /// <summary>The floor plan on file, or null when none has been uploaded.</summary>
    public LeadFloorPlanResponse? FloorPlan { get; set; }

    /// <summary>Requirements, room by room, in the order they were captured.</summary>
    public IReadOnlyList<LeadRoomResponse> Rooms { get; set; } = [];

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

/// <summary>Metadata for an uploaded floor plan.</summary>
/// <remarks>
/// Carries no direct storage URL on purpose: the image is private to the lead, so it is
/// fetched from <see cref="Url"/> - an endpoint on this API that repeats the lead's own
/// visibility check - rather than from a link that would bypass it.
/// </remarks>
public sealed class LeadFloorPlanResponse
{
    /// <example>ground-floor.png</example>
    public string FileName { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public long? SizeInBytes { get; set; }

    public DateTimeOffset? UploadedAt { get; set; }

    /// <summary>API path the image is fetched from, with the caller's own token.</summary>
    public string Url { get; set; } = string.Empty;
}

/// <summary>One room captured under Requirements, with the items requested for it.</summary>
public sealed class LeadRoomResponse
{
    public Guid Id { get; set; }

    /// <summary>Catalogue key, empty for a room typed in by hand.</summary>
    public string RoomKey { get; set; } = string.Empty;

    public string RoomName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }

    public IReadOnlyList<LeadRoomRequirementResponse> Requirements { get; set; } = [];
}

/// <summary>One item requested inside a room.</summary>
public sealed class LeadRoomRequirementResponse
{
    public Guid Id { get; set; }

    /// <summary>Catalogue key, empty for an "Others" entry typed in by hand.</summary>
    public string ItemKey { get; set; } = string.Empty;

    public string ItemName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    public int? Quantity { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }
}

/// <summary>Server-computed answer to the question of what the caller may do here.</summary>
public sealed class LeadCapabilities
{
    public bool CanEdit { get; set; }
    public bool CanDelete { get; set; }
    public bool CanReassign { get; set; }
    public bool CanViewAssignmentHistory { get; set; }
}

/// <summary>
/// A room and its items as submitted by the form. Rooms are replaced wholesale on every
/// save, so ids are not carried: the client sends the section as it should end up.
/// </summary>
public sealed class LeadRoomRequest
{
    [MaxLength(100)]
    public string? RoomKey { get; set; }

    [Required, MaxLength(150)]
    public string RoomName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public List<LeadRoomRequirementRequest> Requirements { get; set; } = [];
}

/// <summary>One requested item, as submitted by the form.</summary>
public sealed class LeadRoomRequirementRequest
{
    [MaxLength(100)]
    public string? ItemKey { get; set; }

    [Required, MaxLength(200)]
    public string ItemName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    [Range(1, 1000)]
    public int? Quantity { get; set; }

    [MaxLength(1000)]
    public string? Notes { get; set; }
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
    public decimal? PropertySize { get; set; }

    public PropertySizeUnit? PropertySizeUnit { get; set; }

    public PropertyConfiguration? PropertyConfiguration { get; set; }

    /// <summary>
    /// A resolved rupee amount. The shorthand a salesperson types (50K, 10L, 2Cr) is expanded
    /// by the client before it gets here, so the API only ever sees a number.
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? BudgetMin { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMax { get; set; }

    public DateOnly? ContactedDate { get; set; }

    public DateOnly? NextFollowUpDate { get; set; }

    /// <summary>Stamped automatically when the phase first implies a quotation went out.</summary>
    public DateOnly? QuotationSharedAt { get; set; }

    /// <summary>Optional at creation; a new lead starts at NewEnquiry when omitted.</summary>
    public LeadPhase Phase { get; set; } = LeadPhase.NewEnquiry;

    public bool IsInterested { get; set; }

    public LeadOverallStatus OverallStatus { get; set; } = LeadOverallStatus.Active;

    /// <summary>Requirements, room by room. The floor plan is uploaded separately.</summary>
    public List<LeadRoomRequest> Rooms { get; set; } = [];

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
    public decimal? PropertySize { get; set; }

    public PropertySizeUnit? PropertySizeUnit { get; set; }

    public PropertyConfiguration? PropertyConfiguration { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMin { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? BudgetMax { get; set; }

    [Required]
    public LeadPhase Phase { get; set; }

    public DateOnly? ContactedDate { get; set; }

    public DateOnly? NextFollowUpDate { get; set; }

    /// <summary>Stamped automatically when the phase first implies a quotation went out.</summary>
    public DateOnly? QuotationSharedAt { get; set; }

    public bool IsInterested { get; set; }

    [Required]
    public LeadOverallStatus OverallStatus { get; set; }

    /// <summary>
    /// The Requirements section as it should end up. Rooms and items are replaced wholesale:
    /// omitting a room deletes it, and an empty list clears the section.
    /// </summary>
    public List<LeadRoomRequest> Rooms { get; set; } = [];
}

/// <summary>Filters for the Leads list. All are optional and combine with AND.</summary>
public sealed class LeadQuery
{
    /// <summary>
    /// Restrict to these phases. Repeat the parameter for several - the quick-filter chips
    /// send a whole group at once (?phases=DesignInProgress&phases=DesignShared&...).
    /// </summary>
    public List<LeadPhase>? Phases { get; set; }

    /// <summary>
    /// Column to order by: name, property, budget, phase, overallStatus, interested,
    /// assignee, nextFollowUp, or createdAt. Anything unrecognised falls back to createdAt.
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>Defaults to true, so the newest leads lead the list.</summary>
    public bool SortDescending { get; set; } = true;

    public PropertyType? PropertyType { get; set; }

    public LeadOverallStatus? OverallStatus { get; set; }

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

/// <summary>How many leads sit in one phase, for the quick-filter chips.</summary>
public sealed class LeadPhaseCountResponse
{
    public LeadPhase Phase { get; set; }

    public int Count { get; set; }
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

/// <summary>A floor plan's bytes, ready to be streamed back by the controller.</summary>
public sealed class LeadFloorPlanContent
{
    public required Stream Content { get; init; }

    public required string FileName { get; init; }

    public string ContentType { get; init; } = "application/octet-stream";
}
