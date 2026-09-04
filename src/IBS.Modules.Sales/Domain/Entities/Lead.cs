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

    /// <summary>Optional: plenty of enquiries arrive with a first name and a phone number only.</summary>
    public string? LastName { get; set; }

    /// <summary>Convenience projection, not mapped to a column.</summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string? SecondaryPhone { get; set; }

    public string? Notes { get; set; }

    public string PropertyName { get; set; } = string.Empty;

    // --- Property address -----------------------------------------------------------

    /// <summary>
    /// Door or flat number and street - the part that identifies the unit. Was a single
    /// free-text PropertyAddress; split so the list can show "Iris by Raghava, B-10" on one
    /// line without dragging the city and pin code onto it.
    /// </summary>
    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Free text, offered as a dropdown of the cities the studio already has branches in. Not
    /// a foreign key: a lead can sit in a city with no branch yet, and pinning it to the
    /// branch list would block capturing that enquiry.
    /// </summary>
    public string? City { get; set; }

    public string? PinCode { get; set; }

    public string? State { get; set; }

    public PropertyType PropertyType { get; set; }

    /// <summary>Size of the property, in <see cref="PropertySizeUnit"/>.</summary>
    public decimal? PropertySize { get; set; }

    public PropertySizeUnit? PropertySizeUnit { get; set; }

    /// <summary>Layout shorthand (2BHK, 3BHK, ...), independent of <see cref="PropertyType"/>.</summary>
    public PropertyConfiguration? PropertyConfiguration { get; set; }

    public decimal? BudgetMin { get; set; }

    public decimal? BudgetMax { get; set; }

    /// <summary>Where the lead has reached in the studio journey.</summary>
    public LeadPhase Phase { get; set; } = LeadPhase.NewClient;

    // --- follow-up tracking ---------------------------------------------------------

    /// <summary>When the lead was actually spoken to, which is not when the row was created.</summary>
    public DateOnly? ContactedDate { get; set; }

    /// <summary>The next call or visit the owner has committed to.</summary>
    public DateOnly? NextFollowUpDate { get; set; }

    /// <summary>
    /// When a quotation was last sent to the client. Stored rather than read off the phase:
    /// a lost lead may well have been quoted, and its phase can no longer say so.
    /// </summary>
    public DateOnly? QuotationSharedAt { get; set; }

    /// <summary>Whether the client has expressed interest, as judged by whoever owns the lead.</summary>
    public bool IsInterested { get; set; }

    // --- floor plan -----------------------------------------------------------------

    /// <summary>
    /// The floor plan images on file, in display order. Never handed to the browser directly -
    /// the bytes are streamed back through the API so the same permission checks apply to the
    /// images as to the lead itself (see LeadsController).
    /// </summary>
    public ICollection<LeadFloorPlanImage> FloorPlans { get; set; } = [];

    // --- assignment -----------------------------------------------------------------

    /// <summary>The employee this lead is currently assigned to. Null when unassigned.</summary>
    public Guid? AssignedToEmployeeId { get; set; }

    /// <summary>Who made the current assignment.</summary>
    public Guid? AssignedByEmployeeId { get; set; }

    /// <summary>When the current assignment was made.</summary>
    public DateTimeOffset? AssignedAt { get; set; }

    /// <summary>
    /// The rooms captured under Requirements, each with its own list of items. Replaced
    /// wholesale on every save rather than diffed - the form edits the whole section at once.
    /// </summary>
    public ICollection<LeadRoom> Rooms { get; set; } = [];
}
