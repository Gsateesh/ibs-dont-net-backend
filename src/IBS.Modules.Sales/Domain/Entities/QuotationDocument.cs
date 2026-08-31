using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// A generated PDF of one quotation version, held in blob storage.
/// </summary>
/// <remarks>
/// A row per generation rather than one row overwritten: regenerating a draft after an edit
/// produces a different document, and the one actually emailed to the client
/// (<see cref="IsSent"/>) has to stay identifiable afterwards. As with the lead's floor plan,
/// <see cref="BlobUrl"/> is never handed to the browser - the bytes stream back through the
/// API so the same permission check covers the file as covers the quotation.
/// </remarks>
public class QuotationDocument : AuditableEntity
{
    public Guid QuotationId { get; set; }

    public Quotation? Quotation { get; set; }

    public string BlobUrl { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = "application/pdf";

    public long SizeInBytes { get; set; }

    public DateTimeOffset GeneratedAt { get; set; }

    public Guid? GeneratedByEmployeeId { get; set; }

    /// <summary>True for the copy that was attached to the client email.</summary>
    public bool IsSent { get; set; }
}
