using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One cell of the rate card: what a given item, in a given specification, costs per unit.
/// </summary>
/// <remarks>
/// <para>
/// Keyed by item and variant as well as by material and finish, because the rate genuinely
/// varies by what is being built and not only by what it is built from - base units and wall
/// units in identical BWP / HDHMR / Acrylic are different rates per square foot, and no
/// two-dimensional material-by-finish grid can express that.
/// </para>
/// <para>
/// Rows are never edited in place once used: a price change is a new row with a later
/// <see cref="EffectiveFrom"/>. Quotations copy the rate onto the line anyway, so this history
/// is for answering "what were we charging in March", not for repricing anything.
/// </para>
/// </remarks>
public class QuotationRate : AuditableEntity
{
    public string ItemKey { get; set; } = string.Empty;

    /// <summary>Empty when the item has no variants.</summary>
    public string VariantKey { get; set; } = string.Empty;

    /// <summary>Empty where the item's rate does not depend on this axis.</summary>
    public string CarcassMaterial { get; set; } = string.Empty;

    public string ShutterMaterial { get; set; } = string.Empty;

    public string Finish { get; set; } = string.Empty;

    public QuotationUnitOfMeasure UnitOfMeasure { get; set; } = QuotationUnitOfMeasure.SquareFeet;

    public decimal RatePerUnit { get; set; }

    public DateOnly EffectiveFrom { get; set; }

    public bool IsActive { get; set; } = true;
}
