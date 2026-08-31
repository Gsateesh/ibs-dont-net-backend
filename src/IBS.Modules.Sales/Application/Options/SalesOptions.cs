namespace IBS.Modules.Sales.Application.Options;

/// <summary>
/// Tunables for the sales module, bound from the <c>Sales</c> configuration section.
/// </summary>
public sealed class SalesOptions
{
    public const string SectionName = "Sales";

    /// <summary>Blob container holding lead floor plans.</summary>
    public string FloorPlanContainer { get; set; } = "lead-floor-plans";

    /// <summary>Largest floor plan accepted, in bytes. Mirrored by the controller's request limit.</summary>
    public long MaxFloorPlanSizeInBytes { get; set; } = 10 * 1024 * 1024;

    /// <summary>Blob container holding generated quotation PDFs.</summary>
    public string QuotationDocumentContainer { get; set; } = "quotation-documents";

    /// <summary>
    /// GST a new quotation version starts at. Only a default - the rate is snapshotted onto each
    /// version when it is created, so changing this never restates a quotation already issued.
    /// </summary>
    public decimal DefaultGstRatePercent { get; set; } = 18m;

    /// <summary>Name the client sees on the quotation PDF and in the covering email.</summary>
    public string StudioName { get; set; } = "Interiors by Surya";
}
