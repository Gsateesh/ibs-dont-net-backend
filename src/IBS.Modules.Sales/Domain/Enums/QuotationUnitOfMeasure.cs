namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// How a line's billable quantity is derived from its dimensions. Which one applies is a
/// property of the catalogue item, not of the room - a wardrobe is billed by shutter area
/// whatever room it stands in.
/// </summary>
public enum QuotationUnitOfMeasure
{
    /// <summary>Width x Height. Shutter and panel work - wardrobes, wall units, ceilings.</summary>
    SquareFeet = 1,

    /// <summary>Length only. Counters, lofts, skirting.</summary>
    RunningFeet = 2,

    /// <summary>Width x Height x Depth. Solid-volume fabrication.</summary>
    CubicFeet = 3,

    /// <summary>Counted, not measured. Bought-out items and fixed-size products.</summary>
    Number = 4
}
