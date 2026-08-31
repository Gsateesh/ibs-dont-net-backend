using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Domain.Entities;

/// <summary>
/// One room on a quotation version, holding the priced lines for it.
/// </summary>
/// <remarks>
/// <para>
/// Seeded from the lead's Requirements rooms when a version is created, then owned entirely by
/// the quotation: removing a room here must never touch the brief the client gave us, so
/// <see cref="SourceLeadRoomId"/> is a record of where the room came from and nothing more -
/// there is no foreign key and no write path back to <see cref="LeadRoom"/>.
/// </para>
/// <para>
/// The three material defaults below apply to lines added afterwards, not retrospectively.
/// Repricing existing lines when a room default changes would silently overwrite rates an
/// estimator had deliberately negotiated; doing it on purpose is a separate explicit action.
/// </para>
/// </remarks>
public class QuotationRoom : AuditableEntity
{
    public Guid QuotationId { get; set; }

    public Quotation? Quotation { get; set; }

    /// <summary>Catalogue key, e.g. <c>kitchen</c>. Empty for a room typed in by hand.</summary>
    public string RoomKey { get; set; } = string.Empty;

    public string RoomName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    /// <summary>
    /// The Requirements room this was copied from, when it was. Null for a room added directly
    /// on the quotation. Advisory only - the source row may since have been deleted.
    /// </summary>
    public Guid? SourceLeadRoomId { get; set; }

    public string? DefaultCarcassMaterial { get; set; }

    public string? DefaultShutterMaterial { get; set; }

    public string? DefaultFinish { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }

    /// <summary>Sum of this room's line amounts. Stored for the same reason the quotation totals are.</summary>
    public decimal RoomTotal { get; set; }

    public ICollection<QuotationLineItem> LineItems { get; set; } = [];
}
