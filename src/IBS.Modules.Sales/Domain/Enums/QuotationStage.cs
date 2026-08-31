namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// Which of the two quotations in the studio journey a version belongs to.
/// <para>
/// One entity carries both rather than two parallel features: the final quotation is the same
/// document priced against an approved design, and every rule about versions, rooms, lines,
/// GST and PDFs is identical. <see cref="LeadPhase"/> already distinguishes the two stages'
/// lifecycles (20-23 against 40-44), so nothing else here needs to.
/// </para>
/// </summary>
public enum QuotationStage
{
    /// <summary>Priced before any design work, from the Requirements brief.</summary>
    Initial = 1,

    /// <summary>Priced against the approved design.</summary>
    Final = 2
}
