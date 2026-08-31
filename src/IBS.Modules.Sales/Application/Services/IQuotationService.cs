using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Domain.Enums;

namespace IBS.Modules.Sales.Application.Services;

/// <summary>
/// Quotations for a lead: the versions, their contents, and the transitions between them.
/// </summary>
/// <remarks>
/// Reading a quotation needs only the leads permission that let the caller open the lead;
/// building one needs <c>manage_quotations</c>, and issuing one needs <c>approve_quotations</c>.
/// Sending and PDF generation live on <see cref="IQuotationDeliveryService"/> so that this
/// service stays free of storage and mail concerns.
/// </remarks>
public interface IQuotationService
{
    /// <summary>Every version for a lead, newest first, without rooms or lines.</summary>
    Task<IReadOnlyList<QuotationSummaryResponse>> ListAsync(
        Guid leadId, QuotationStage? stage, Guid actorId, CancellationToken ct = default);

    /// <summary>One version in full.</summary>
    Task<QuotationDetailResponse> GetAsync(
        Guid leadId, Guid quotationId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// The version the workspace should open, or null when the lead has no quotation at this
    /// stage yet. Null is an ordinary answer here, not an error - it is what the empty state
    /// on the tab is for.
    /// </summary>
    Task<QuotationDetailResponse?> GetCurrentAsync(
        Guid leadId, QuotationStage stage, Guid actorId, CancellationToken ct = default);

    /// <summary>Starts version 1, optionally seeded with the rooms from the lead's Requirements.</summary>
    Task<QuotationDetailResponse> CreateAsync(
        Guid leadId, CreateQuotationRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Replaces a draft version's rooms, lines and figures, then reprices it.</summary>
    Task<QuotationDetailResponse> SaveAsync(
        Guid leadId, Guid quotationId, SaveQuotationRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Clones a version into the next one as a fresh draft, and makes it current.</summary>
    Task<QuotationDetailResponse> CreateVersionAsync(
        Guid leadId, Guid quotationId, CreateQuotationVersionRequest request, Guid actorId,
        CancellationToken ct = default);

    /// <summary>Deletes a draft version. Issued versions are kept as the record of what was sent.</summary>
    Task DeleteAsync(Guid leadId, Guid quotationId, Guid actorId, CancellationToken ct = default);

    /// <summary>Records the client's answer to a version they were sent, and moves the lead's phase.</summary>
    Task<QuotationDetailResponse> RecordDecisionAsync(
        Guid leadId, Guid quotationId, RecordQuotationDecisionRequest request, Guid actorId,
        CancellationToken ct = default);

    /// <summary>The item picker's contents and the material options the rate card supports.</summary>
    Task<QuotationCatalogResponse> GetCatalogAsync(Guid actorId, CancellationToken ct = default);
}
