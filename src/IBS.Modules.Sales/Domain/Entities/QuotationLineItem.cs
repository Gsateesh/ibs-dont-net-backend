using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One priced row on a quotation - the atomic unit of the whole model.
/// </summary>
/// <remarks>
/// <para>
/// Nothing nests below this. The hierarchy is room, then category, then line, and the category
/// is a grouping label carried on <see cref="CategoryKey"/> rather than a table: it has no
/// dimensions, no material and no rate of its own, so a row for it would exist only to be
/// skipped. Where a catalogue item offers variants - wall units in wood and in glass - each
/// selected variant becomes its own line, because they are measured, specified and rated
/// separately. A line with parts hanging under it is not a shape this model has.
/// </para>
/// <para>
/// The pricing inputs are snapshotted here, not joined to the rate card at read time.
/// <see cref="Rate"/> in particular is a copy: rate cards are edited, and a quotation sent in
/// March has to reprint in June with March's numbers or it is not evidence of anything.
/// </para>
/// </remarks>
public class QuotationLineItem : AuditableEntity
{
    public Guid QuotationRoomId { get; set; }

    public QuotationRoom? Room { get; set; }

    // --- Identity ----------------------------------------------------------------

    /// <summary>Catalogue key of the grouping, e.g. <c>modular</c>. Never empty.</summary>
    public string CategoryKey { get; set; } = string.Empty;

    /// <summary>Display name of the category, snapshotted so a catalogue rename cannot restyle an old PDF.</summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>Catalogue key of the item, e.g. <c>wall-units</c>. Empty for a custom line.</summary>
    public string ItemKey { get; set; } = string.Empty;

    /// <summary>
    /// What the client reads. Includes the variant where there is one - "Wall Units - Glass" -
    /// because the variant is part of the item's identity, not a separate column to reassemble.
    /// </summary>
    public string ItemName { get; set; } = string.Empty;

    /// <summary>Catalogue key of the variant, when the item has any. Empty otherwise.</summary>
    public string VariantKey { get; set; } = string.Empty;

    /// <summary>True when the estimator typed the item in rather than picking it.</summary>
    public bool IsCustom { get; set; }

    public int SortOrder { get; set; }

    // --- Specification -----------------------------------------------------------

    public QuotationPricingType PricingType { get; set; } = QuotationPricingType.Parametric;

    public string? CarcassMaterial { get; set; }

    public string? ShutterMaterial { get; set; }

    public string? Finish { get; set; }

    public decimal? WidthFeet { get; set; }

    public decimal? HeightFeet { get; set; }

    public decimal? DepthFeet { get; set; }

    public QuotationUnitOfMeasure UnitOfMeasure { get; set; } = QuotationUnitOfMeasure.SquareFeet;

    /// <summary>
    /// What the rate is charged against, derived from the dimensions and the unit of measure.
    /// Stored rather than recomputed on read so a change to the derivation rules cannot restate
    /// a quotation that has already gone out.
    /// </summary>
    public decimal BillableQuantity { get; set; }

    /// <summary>How many of this line. Multiplies the whole line, dimensions included.</summary>
    public int Quantity { get; set; } = 1;

    // --- Money -------------------------------------------------------------------

    /// <summary>Rate per <see cref="UnitOfMeasure"/>, copied from the rate card at pricing time.</summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// True when the estimator typed over the rate the card offered. Worth knowing: an
    /// overridden rate is where a negotiation happened, and it is the first thing a margin
    /// review wants to see.
    /// </summary>
    public bool IsRateOverridden { get; set; }

    /// <summary><see cref="BillableQuantity"/> x <see cref="Rate"/> x <see cref="Quantity"/>.</summary>
    public decimal BaseAmount { get; set; }

    public decimal HardwareAmount { get; set; }

    public decimal AccessoryAmount { get; set; }

    /// <summary>What this line contributes to the room and the subtotal.</summary>
    public decimal Amount { get; set; }

    // --- Notes -------------------------------------------------------------------

    /// <summary>Printed on the client's copy, under the line.</summary>
    public string? Notes { get; set; }

    /// <summary>
    /// The estimator's basis for the number. Never printed and never returned to a client-facing
    /// caller - it exists for margin review and for spotting a one-off worth adding to the catalogue.
    /// </summary>
    public string? InternalNotes { get; set; }
}
