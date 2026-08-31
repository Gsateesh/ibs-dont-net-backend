using IBS.Modules.Sales.Domain.Enums;

namespace IBS.Modules.Sales.Application.Dtos;

/// <summary>One row in the version selector. Deliberately without rooms or lines.</summary>
public sealed class QuotationSummaryResponse
{
    public Guid Id { get; set; }

    public QuotationStage Stage { get; set; }

    public int VersionNumber { get; set; }

    public QuotationStatus Status { get; set; }

    public bool IsCurrent { get; set; }

    public string? Title { get; set; }

    /// <summary>Read straight off the row, which is why the totals are stored rather than derived.</summary>
    public decimal GrandTotal { get; set; }

    public DateTimeOffset? SharedAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public string? PreparedByName { get; set; }
}

/// <summary>One quotation version in full: rooms, lines and the totals they roll up to.</summary>
public sealed class QuotationDetailResponse
{
    public Guid Id { get; set; }

    public Guid LeadId { get; set; }

    public QuotationStage Stage { get; set; }

    public int VersionNumber { get; set; }

    public Guid? ClonedFromQuotationId { get; set; }

    public bool IsCurrent { get; set; }

    public QuotationStatus Status { get; set; }

    public string? Title { get; set; }

    public decimal Subtotal { get; set; }

    public decimal? DiscountPercent { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxableValue { get; set; }

    public decimal GstRatePercent { get; set; }

    public decimal GstAmount { get; set; }

    public decimal TransportCharges { get; set; }

    public decimal InstallationCharges { get; set; }

    public decimal GrandTotal { get; set; }

    public DateTimeOffset? SharedAt { get; set; }

    public DateTimeOffset? ApprovedAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public string? PreparedByName { get; set; }

    public List<QuotationRoomResponse> Rooms { get; set; } = [];

    public List<QuotationDocumentResponse> Documents { get; set; } = [];

    public QuotationCapabilities Capabilities { get; set; } = new();
}

/// <summary>One room on a version, with its lines.</summary>
public sealed class QuotationRoomResponse
{
    public Guid Id { get; set; }

    public string RoomKey { get; set; } = string.Empty;

    public string RoomName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    public Guid? SourceLeadRoomId { get; set; }

    public string? DefaultCarcassMaterial { get; set; }

    public string? DefaultShutterMaterial { get; set; }

    public string? DefaultFinish { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }

    public decimal RoomTotal { get; set; }

    public List<QuotationLineItemResponse> LineItems { get; set; } = [];
}

/// <summary>One priced row. Flat by design - nothing nests under a line item.</summary>
public sealed class QuotationLineItemResponse
{
    public Guid Id { get; set; }

    public string CategoryKey { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string ItemKey { get; set; } = string.Empty;

    public string ItemName { get; set; } = string.Empty;

    public string VariantKey { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    public int SortOrder { get; set; }

    public QuotationPricingType PricingType { get; set; }

    public string? CarcassMaterial { get; set; }

    public string? ShutterMaterial { get; set; }

    public string? Finish { get; set; }

    public decimal? WidthFeet { get; set; }

    public decimal? HeightFeet { get; set; }

    public decimal? DepthFeet { get; set; }

    public QuotationUnitOfMeasure UnitOfMeasure { get; set; }

    public decimal BillableQuantity { get; set; }

    public int Quantity { get; set; }

    public decimal Rate { get; set; }

    public bool IsRateOverridden { get; set; }

    public decimal BaseAmount { get; set; }

    public decimal HardwareAmount { get; set; }

    public decimal AccessoryAmount { get; set; }

    public decimal Amount { get; set; }

    public string? Notes { get; set; }

    /// <summary>
    /// Only populated for a caller holding manage_quotations. It is the estimator's margin
    /// working, and nothing that reaches a client is allowed to carry it.
    /// </summary>
    public string? InternalNotes { get; set; }
}

/// <summary>A generated PDF against a version.</summary>
public sealed class QuotationDocumentResponse
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public long SizeInBytes { get; set; }

    public DateTimeOffset GeneratedAt { get; set; }

    public string? GeneratedByName { get; set; }

    public bool IsSent { get; set; }
}

/// <summary>
/// What this caller may do with this version, computed from their permissions and the
/// version's status. The API enforces all of it regardless - this only spares the UI from
/// offering a button that would come back 403 or 409.
/// </summary>
public sealed class QuotationCapabilities
{
    /// <summary>Holds manage_quotations, and the version is still a draft.</summary>
    public bool CanEdit { get; set; }

    public bool CanCreateVersion { get; set; }

    public bool CanDelete { get; set; }

    public bool CanGeneratePdf { get; set; }

    /// <summary>Holds approve_quotations, and there is a client address to send to.</summary>
    public bool CanSendToClient { get; set; }

    public bool CanRecordDecision { get; set; }

    /// <summary>False when the mail sender is the development one that only logs.</summary>
    public bool EmailDeliveryEnabled { get; set; }
}

// --- Requests -------------------------------------------------------------------

/// <summary>
/// Creates the first version for a lead and stage. Rooms are copied from the lead's
/// Requirements unless the caller opts out - a quotation for a lead with no brief captured
/// starts empty rather than failing.
/// </summary>
public sealed class CreateQuotationRequest
{
    public QuotationStage Stage { get; set; } = QuotationStage.Initial;

    public bool SeedRoomsFromRequirements { get; set; } = true;

    public string? Title { get; set; }
}

/// <summary>
/// Replaces a draft version wholesale - rooms, lines and the quotation-level figures in one
/// call, the same idiom the lead's own PUT uses. A partial save would need the client to know
/// which rows it had deleted, and the form edits the whole document at once anyway.
/// </summary>
public sealed class SaveQuotationRequest
{
    public string? Title { get; set; }

    /// <summary>Mutually exclusive with <see cref="DiscountAmount"/>; percent wins if both arrive.</summary>
    public decimal? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    /// <summary>Omitted means "keep what this version was already priced at".</summary>
    public decimal? GstRatePercent { get; set; }

    public decimal TransportCharges { get; set; }

    public decimal InstallationCharges { get; set; }

    public List<SaveQuotationRoomRequest> Rooms { get; set; } = [];
}

/// <summary>One room in a save. Removing a room here removes it from the quotation only.</summary>
public sealed class SaveQuotationRoomRequest
{
    /// <summary>Null for a room being added. Unknown ids are rejected rather than silently created.</summary>
    public Guid? Id { get; set; }

    public string RoomKey { get; set; } = string.Empty;

    public string RoomName { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    public Guid? SourceLeadRoomId { get; set; }

    public string? DefaultCarcassMaterial { get; set; }

    public string? DefaultShutterMaterial { get; set; }

    public string? DefaultFinish { get; set; }

    public string? Notes { get; set; }

    public int SortOrder { get; set; }

    public List<SaveQuotationLineItemRequest> LineItems { get; set; } = [];
}

/// <summary>
/// One line in a save. The client sends the specification; the server derives the billable
/// quantity, resolves the rate and computes every amount. Figures the client calculated are
/// ignored on purpose - a grand total worked out by a browser is not one worth defending.
/// </summary>
public sealed class SaveQuotationLineItemRequest
{
    public Guid? Id { get; set; }

    public string CategoryKey { get; set; } = string.Empty;

    public string ItemKey { get; set; } = string.Empty;

    /// <summary>Required only for a custom line; otherwise taken from the catalogue.</summary>
    public string? ItemName { get; set; }

    public string VariantKey { get; set; } = string.Empty;

    public bool IsCustom { get; set; }

    public int SortOrder { get; set; }

    public string? CarcassMaterial { get; set; }

    public string? ShutterMaterial { get; set; }

    public string? Finish { get; set; }

    public decimal? WidthFeet { get; set; }

    public decimal? HeightFeet { get; set; }

    public decimal? DepthFeet { get; set; }

    public int Quantity { get; set; } = 1;

    /// <summary>
    /// Set only when the estimator typed over the card, or on a custom line where there is no
    /// card to consult. Left null, the rate card decides.
    /// </summary>
    public decimal? RateOverride { get; set; }

    public decimal HardwareAmount { get; set; }

    public decimal AccessoryAmount { get; set; }

    public string? Notes { get; set; }

    public string? InternalNotes { get; set; }
}

/// <summary>Clones the current version into the next one, as a fresh draft.</summary>
public sealed class CreateQuotationVersionRequest
{
    public string? Title { get; set; }
}

/// <summary>Emails a version to the client with its PDF attached.</summary>
public sealed class SendQuotationRequest
{
    /// <summary>Defaults to the lead's own email address when omitted.</summary>
    public string? ToEmail { get; set; }

    public string? Subject { get; set; }

    /// <summary>Plain text; the template wraps it. Empty falls back to a standard covering note.</summary>
    public string? Message { get; set; }
}

/// <summary>Records what the client said about a version they were sent.</summary>
public sealed class RecordQuotationDecisionRequest
{
    /// <summary>Only Approved and RevisionRequired are accepted here.</summary>
    public QuotationStatus Status { get; set; }

    public string? Notes { get; set; }
}

// --- Catalogue ------------------------------------------------------------------

/// <summary>
/// Everything the item picker needs, in one call: which categories exist, what each offers,
/// and the material options the rate card actually has rates for.
/// </summary>
public sealed class QuotationCatalogResponse
{
    public List<QuotationCategoryResponse> Categories { get; set; } = [];

    /// <summary>
    /// The rate card in force today, so the tab can price a line the moment a dimension is
    /// typed rather than after a round trip.
    /// <para>
    /// This does mean the resolution rule exists in two places. That is a real cost, accepted
    /// deliberately: an estimator adjusting a width needs the total to move as they type. The
    /// server recomputes everything on save regardless and its figures are the ones stored, so
    /// a divergence shows up as a corrected total, never as a wrong number in the database.
    /// </para>
    /// </summary>
    public List<QuotationRateResponse> Rates { get; set; } = [];

    public List<string> CarcassMaterials { get; set; } = [];

    public List<string> ShutterMaterials { get; set; } = [];

    public List<string> Finishes { get; set; } = [];

    /// <summary>The rate the studio is currently on, so a new version defaults to it.</summary>
    public decimal DefaultGstRatePercent { get; set; }
}

/// <summary>One tab of the item picker.</summary>
public sealed class QuotationCategoryResponse
{
    public string CategoryKey { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public List<QuotationCatalogItemResponse> Items { get; set; } = [];
}

/// <summary>
/// One entry in the picker. Where <see cref="Variants"/> is non-empty the picker shows an
/// expandable heading, and each variant the estimator chooses adds its own priced line.
/// </summary>
public sealed class QuotationCatalogItemResponse
{
    public string ItemKey { get; set; } = string.Empty;

    public string ItemName { get; set; } = string.Empty;

    /// <summary>
    /// The rooms this item is offered in. Empty means every room - furniture, furnishings and
    /// services are not room-specific, and repeating them under all twenty-one rooms would make
    /// the payload mostly duplication.
    /// </summary>
    public List<string> RoomKeys { get; set; } = [];

    public QuotationPricingType PricingType { get; set; }

    public QuotationUnitOfMeasure UnitOfMeasure { get; set; }

    public decimal? BasePrice { get; set; }

    /// <summary>Empty for an item offered as itself.</summary>
    public List<QuotationCatalogVariantResponse> Variants { get; set; } = [];
}

/// <summary>One variant of a catalogue item.</summary>
public sealed class QuotationCatalogVariantResponse
{
    public string VariantKey { get; set; } = string.Empty;

    public string VariantName { get; set; } = string.Empty;
}

/// <summary>
/// One cell of the rate card. An empty material or finish means "any", and the most specific
/// matching row wins - the same rule the server applies when it reprices on save.
/// </summary>
public sealed class QuotationRateResponse
{
    public string ItemKey { get; set; } = string.Empty;

    public string VariantKey { get; set; } = string.Empty;

    public string CarcassMaterial { get; set; } = string.Empty;

    public string ShutterMaterial { get; set; } = string.Empty;

    public string Finish { get; set; } = string.Empty;

    public QuotationUnitOfMeasure UnitOfMeasure { get; set; }

    public decimal RatePerUnit { get; set; }
}
