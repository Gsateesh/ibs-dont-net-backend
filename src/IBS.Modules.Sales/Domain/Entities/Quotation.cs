using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One version of one quotation for a lead - the priced document itself, not a header over a
/// set of versions.
/// </summary>
/// <remarks>
/// <para>
/// Versions are rows here rather than children of a parent "quotation" row. A studio revises
/// the same quotation repeatedly rather than running several in parallel, so the parent would
/// carry no data of its own and buy nothing but a join. A version is identified by
/// (<see cref="LeadId"/>, <see cref="Stage"/>, <see cref="VersionNumber"/>), and exactly one
/// per lead and stage is flagged <see cref="IsCurrent"/>.
/// </para>
/// <para>
/// Every money figure below is stored, not computed on read. Two reasons: the totals are what
/// the client was sent, so they must survive any later change to the rate card or the GST
/// slab; and a list of versions can then show grand totals without loading every line.
/// </para>
/// </remarks>
public class Quotation : AuditableEntity
{
    public Guid LeadId { get; set; }

    public Lead? Lead { get; set; }

    public QuotationStage Stage { get; set; } = QuotationStage.Initial;

    /// <summary>1 for the first version, incremented by each "save as new version".</summary>
    public int VersionNumber { get; set; } = 1;

    /// <summary>
    /// The version this one was cloned from, null for v1. Kept so the revision trail is
    /// readable even after a version in the middle is deleted.
    /// </summary>
    public Guid? ClonedFromQuotationId { get; set; }

    /// <summary>
    /// The version the workspace opens by default. Exactly one per lead and stage; moving it
    /// is the only thing "save as new version" changes about the older rows besides their status.
    /// </summary>
    public bool IsCurrent { get; set; } = true;

    public QuotationStatus Status { get; set; } = QuotationStatus.Draft;

    /// <summary>Free text shown under the version selector, e.g. "after client call on 12th".</summary>
    public string? Title { get; set; }

    // --- Money -------------------------------------------------------------------

    /// <summary>Sum of every line amount across every room, before any quotation-level discount.</summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Discount as a percentage of <see cref="Subtotal"/>, when the estimator entered one that
    /// way. Null when a flat amount was entered instead; the two are mutually exclusive.
    /// </summary>
    public decimal? DiscountPercent { get; set; }

    /// <summary>The discount actually applied, whether typed as a flat figure or resolved from
    /// <see cref="DiscountPercent"/>. This is the number that appears on the PDF.</summary>
    public decimal DiscountAmount { get; set; }

    /// <summary><see cref="Subtotal"/> less <see cref="DiscountAmount"/>. What GST is charged on.</summary>
    public decimal TaxableValue { get; set; }

    /// <summary>
    /// The GST rate this version was priced at, snapshotted rather than read from settings.
    /// Slabs change; a version reprinted next year must still show the rate it was sent with.
    /// </summary>
    public decimal GstRatePercent { get; set; }

    public decimal GstAmount { get; set; }

    /// <summary>Charged after tax, and shown as their own lines on the PDF.</summary>
    public decimal TransportCharges { get; set; }

    public decimal InstallationCharges { get; set; }

    public decimal GrandTotal { get; set; }

    // --- Lifecycle ---------------------------------------------------------------

    /// <summary>Who built this version. Not necessarily who the lead is assigned to.</summary>
    public Guid? PreparedByEmployeeId { get; set; }

    /// <summary>When the version was emailed to the client. Also the moment it froze.</summary>
    public DateTimeOffset? SharedAt { get; set; }

    public Guid? SharedByEmployeeId { get; set; }

    public DateTimeOffset? ApprovedAt { get; set; }

    public Guid? ApprovedByEmployeeId { get; set; }

    /// <summary>Rooms carried on this version. Replaced wholesale on save, like the lead's own rooms.</summary>
    public ICollection<QuotationRoom> Rooms { get; set; } = [];

    /// <summary>Generated PDFs, newest last. Regenerating a draft adds a row rather than replacing one.</summary>
    public ICollection<QuotationDocument> Documents { get; set; } = [];

    /// <summary>True while the version may still be edited. The one rule the whole model rests on.</summary>
    public bool IsEditable => Status == QuotationStatus.Draft;
}
