using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One room (or outdoor area) a lead wants worked on, holding the items requested for it.
/// </summary>
/// <remarks>
/// <see cref="RoomKey"/> and the item keys below are catalogue keys held in the frontend
/// rather than an enum here, deliberately: the room and item catalogue grows constantly, and
/// storing the key as text means a new room type is a one-line frontend change instead of a
/// migration. A room the catalogue does not offer is captured with <see cref="IsCustom"/>.
/// </remarks>
public class LeadRoom : AuditableEntity
{
    public Guid LeadId { get; set; }

    public Lead? Lead { get; set; }

    /// <summary>Catalogue key, e.g. <c>living-room</c>. Empty for a room typed in by hand.</summary>
    public string RoomKey { get; set; } = string.Empty;

    /// <summary>Display name, from the catalogue or typed in by the user.</summary>
    public string RoomName { get; set; } = string.Empty;

    /// <summary>True when the room itself was typed in rather than picked from the catalogue.</summary>
    public bool IsCustom { get; set; }

    /// <summary>Free text about this room as a whole.</summary>
    public string? Notes { get; set; }

    /// <summary>Display order, so the form round-trips in the order it was filled in.</summary>
    public int SortOrder { get; set; }

    public ICollection<LeadRoomRequirement> Requirements { get; set; } = [];
}
