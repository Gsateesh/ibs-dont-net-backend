namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// How one line item arrived at its rate. Stored on the line rather than inferred from the
/// catalogue, because the catalogue can change after the line was priced.
/// </summary>
public enum QuotationPricingType
{
    /// <summary>
    /// Size-driven: billable quantity computed from the entered dimensions, rate looked up
    /// from the rate card by item, carcass, shutter and finish. Most modular work.
    /// </summary>
    Parametric = 1,

    /// <summary>Fixed-size catalogue product at a listed price, varying only by selected options.</summary>
    Catalog = 2,

    /// <summary>One-off line with no formula behind it - the estimator types the rate in.</summary>
    Custom = 3
}
