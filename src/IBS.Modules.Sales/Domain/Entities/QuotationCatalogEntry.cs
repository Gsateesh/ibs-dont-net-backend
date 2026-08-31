using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One selectable entry in the quotation's item picker: what can be added to a room, under
/// which category, and how it is measured.
/// </summary>
/// <remarks>
/// <para>
/// Held in the database rather than in a frontend constants file, unlike the Requirements
/// catalogue. The difference is that these keys carry money: every entry here has to stay
/// joined to <see cref="QuotationRate"/>, and a rate needs an effective date and an admin
/// screen. A list that only decides what appears in a dropdown can live in code; a list that
/// decides what a client is charged cannot.
/// </para>
/// <para>
/// This catalogue is a different axis from the Requirements one and does not map onto it. That
/// list records what the client asked for ("Wardrobe", "Wallpaper"); this one records what the
/// studio builds and bills ("Base Units", "Wall Units - Glass").
/// </para>
/// </remarks>
public class QuotationCatalogEntry : AuditableEntity
{
    /// <summary>
    /// Room this entry is offered in, e.g. <c>kitchen</c>. Empty means every room - most
    /// furniture and services are not room-specific.
    /// </summary>
    public string RoomKey { get; set; } = string.Empty;

    /// <summary>Grouping key, e.g. <c>modular</c>, <c>custom-work</c>, <c>furniture</c>.</summary>
    public string CategoryKey { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string ItemKey { get; set; } = string.Empty;

    public string ItemName { get; set; } = string.Empty;

    /// <summary>
    /// Empty for an item offered as itself. Where an item has variants, there is one row per
    /// variant sharing the <see cref="ItemKey"/> - which is what lets the picker collapse them
    /// under one expandable heading while each still adds its own priced line.
    /// </summary>
    public string VariantKey { get; set; } = string.Empty;

    /// <summary>Variant label, e.g. "Wooden". Empty when there is no variant.</summary>
    public string VariantName { get; set; } = string.Empty;

    public QuotationPricingType PricingType { get; set; } = QuotationPricingType.Parametric;

    public QuotationUnitOfMeasure UnitOfMeasure { get; set; } = QuotationUnitOfMeasure.SquareFeet;

    /// <summary>Listed price for a <see cref="QuotationPricingType.Catalog"/> item. Null otherwise.</summary>
    public decimal? BasePrice { get; set; }

    public int SortOrder { get; set; }

    /// <summary>Retired entries stay for the sake of old quotations that reference them.</summary>
    public bool IsActive { get; set; } = true;
}
