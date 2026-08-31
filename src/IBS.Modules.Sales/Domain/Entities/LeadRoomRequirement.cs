using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One item requested inside a room - a wardrobe, a TV unit, wallpaper, or anything the
/// client asked for that the catalogue does not list (<see cref="IsCustom"/>).
/// </summary>
public class LeadRoomRequirement : AuditableEntity
{
    public Guid LeadRoomId { get; set; }

    public LeadRoom? Room { get; set; }

    /// <summary>Catalogue key, e.g. <c>wardrobe</c>. Empty for a custom "Others" entry.</summary>
    public string ItemKey { get; set; } = string.Empty;

    /// <summary>Display name, from the catalogue or typed in under "Others".</summary>
    public string ItemName { get; set; } = string.Empty;

    /// <summary>True when the item was typed in under "Others" rather than picked.</summary>
    public bool IsCustom { get; set; }

    public int? Quantity { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }
}
