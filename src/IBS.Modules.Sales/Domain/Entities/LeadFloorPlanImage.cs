using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One floor plan image uploaded against a lead.
/// </summary>
/// <remarks>
/// A table rather than the five columns this used to be on <see cref="Lead"/>: a flat is
/// rarely one drawing - there is a floor plan, a furniture layout, a scanned brochure page -
/// and replacing the single image every time meant the earlier ones were simply lost.
/// </remarks>
public class LeadFloorPlanImage : AuditableEntity
{
    public Guid LeadId { get; set; }

    public Lead? Lead { get; set; }

    /// <summary>Storage reference. Never handed to the browser; the bytes stream through the API.</summary>
    public string BlobUrl { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public long? SizeInBytes { get; set; }

    public DateTimeOffset UploadedAt { get; set; }

    /// <summary>Display order, so the viewer's arrows step through them predictably.</summary>
    public int SortOrder { get; set; }
}
