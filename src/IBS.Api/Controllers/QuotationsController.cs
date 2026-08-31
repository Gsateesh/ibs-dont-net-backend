using IBS.Api.Security;
using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Application.Services;
using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// Quotations against a lead - the versions, their contents, and issuing them to the client.
/// </summary>
/// <remarks>
/// <para>
/// Nested under the lead because a quotation only exists in relation to one, and because the
/// lead decides who may see it: reading needs whichever leads permission opened the lead, and a
/// lead outside the caller's reach answers 404 exactly as it does elsewhere.
/// </para>
/// <para>
/// Beyond that, building needs manage_quotations and issuing needs approve_quotations. The
/// service enforces all of it; the attributes here are the coarse gate and the documentation.
/// </para>
/// </remarks>
[ApiController]
[Route("api/leads/{leadId:guid}/quotations")]
[Produces("application/json")]
[Tags("Quotations")]
public sealed class QuotationsController(
    IQuotationService quotations,
    IQuotationDeliveryService delivery,
    ICurrentUser currentUser) : ControllerBase
{
    /// <summary>Every version for a lead, newest first.</summary>
    /// <response code="200">The versions, without their rooms or lines.</response>
    [HttpGet]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<IReadOnlyList<QuotationSummaryResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<QuotationSummaryResponse>>> List(
        Guid leadId, [FromQuery] QuotationStage? stage, CancellationToken ct) =>
        Ok(await quotations.ListAsync(leadId, stage, currentUser.RequireEmployeeId(), ct));

    /// <summary>The version the workspace should open for a stage.</summary>
    /// <remarks>
    /// Answers 204 when the lead has no quotation at this stage yet. That is an ordinary state,
    /// not an error - it is what the tab's empty state exists for.
    /// </remarks>
    /// <response code="200">The current version, in full.</response>
    /// <response code="204">No quotation at this stage yet.</response>
    [HttpGet("current")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<QuotationDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<QuotationDetailResponse>> GetCurrent(
        Guid leadId, [FromQuery] QuotationStage stage = QuotationStage.Initial,
        CancellationToken ct = default)
    {
        var current = await quotations.GetCurrentAsync(leadId, stage, currentUser.RequireEmployeeId(), ct);

        return current is null ? NoContent() : Ok(current);
    }

    /// <summary>One version, with its rooms, lines and totals.</summary>
    /// <response code="200">The version.</response>
    /// <response code="404">No such quotation, or the lead is not visible to you.</response>
    [HttpGet("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<QuotationDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QuotationDetailResponse>> Get(
        Guid leadId, Guid id, CancellationToken ct) =>
        Ok(await quotations.GetAsync(leadId, id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Starts version 1 for a stage.</summary>
    /// <remarks>
    /// Rooms are copied from the lead's Requirements by default. They are a copy from that point
    /// on: removing one here never touches the brief.
    /// </remarks>
    /// <response code="201">Created.</response>
    /// <response code="409">This lead already has a quotation at this stage.</response>
    [HttpPost]
    [RequiresPermission(PermissionCodes.ManageQuotations)]
    [ProducesResponseType<QuotationDetailResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<QuotationDetailResponse>> Create(
        Guid leadId, CreateQuotationRequest request, CancellationToken ct)
    {
        var created = await quotations.CreateAsync(leadId, request, currentUser.RequireEmployeeId(), ct);

        return CreatedAtAction(nameof(Get), new { leadId, id = created.Id }, created);
    }

    /// <summary>Replaces a draft version's rooms, lines and figures.</summary>
    /// <remarks>
    /// The whole document in one call. Rates and amounts sent by the client are ignored: the
    /// server derives every figure from the specification and its own rate card.
    /// </remarks>
    /// <response code="200">The saved version, repriced.</response>
    /// <response code="409">The version has been issued and can no longer be edited.</response>
    [HttpPut("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageQuotations)]
    [ProducesResponseType<QuotationDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<QuotationDetailResponse>> Save(
        Guid leadId, Guid id, SaveQuotationRequest request, CancellationToken ct) =>
        Ok(await quotations.SaveAsync(leadId, id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Clones a version into the next one, as a fresh draft.</summary>
    /// <remarks>
    /// The new version becomes the current one. The old one stops being current and is marked
    /// superseded, unless the client had already approved it.
    /// </remarks>
    /// <response code="201">The new version.</response>
    [HttpPost("{id:guid}/versions")]
    [RequiresPermission(PermissionCodes.ManageQuotations)]
    [ProducesResponseType<QuotationDetailResponse>(StatusCodes.Status201Created)]
    public async Task<ActionResult<QuotationDetailResponse>> CreateVersion(
        Guid leadId, Guid id, CreateQuotationVersionRequest request, CancellationToken ct)
    {
        var created = await quotations.CreateVersionAsync(
            leadId, id, request, currentUser.RequireEmployeeId(), ct);

        return CreatedAtAction(nameof(Get), new { leadId, id = created.Id }, created);
    }

    /// <summary>Deletes a draft version.</summary>
    /// <response code="204">Deleted.</response>
    /// <response code="409">Only a draft can be deleted.</response>
    [HttpDelete("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageQuotations)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Delete(Guid leadId, Guid id, CancellationToken ct)
    {
        await quotations.DeleteAsync(leadId, id, currentUser.RequireEmployeeId(), ct);

        return NoContent();
    }

    /// <summary>Generates the PDF for a version and returns it.</summary>
    /// <remarks>Also stored against the version, so what was produced stays retrievable.</remarks>
    /// <response code="200">The PDF.</response>
    [HttpPost("{id:guid}/pdf")]
    [RequiresPermission(PermissionCodes.ManageQuotations, PermissionCodes.ApproveQuotations)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileResult))]
    public async Task<IActionResult> GeneratePdf(Guid leadId, Guid id, CancellationToken ct)
    {
        var file = await delivery.GeneratePdfAsync(leadId, id, currentUser.RequireEmployeeId(), ct);

        return File(file.Content, file.ContentType, file.FileName);
    }

    /// <summary>Downloads a previously generated PDF.</summary>
    /// <response code="200">The PDF.</response>
    /// <response code="404">No such document.</response>
    [HttpGet("{id:guid}/documents/{documentId:guid}")]
    [RequiresPermission(PermissionCodes.ManageQuotations, PermissionCodes.ApproveQuotations)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileResult))]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDocument(
        Guid leadId, Guid id, Guid documentId, CancellationToken ct)
    {
        var file = await delivery.GetDocumentAsync(
            leadId, id, documentId, currentUser.RequireEmployeeId(), ct);

        return File(file.Content, file.ContentType, file.FileName);
    }

    /// <summary>Emails a version to the client with its PDF attached.</summary>
    /// <remarks>
    /// Never automatic - this only happens when somebody asks for it. The version freezes on
    /// success and the lead moves to the quotation-shared phase. Where mail is not configured
    /// the response says the message was suppressed rather than implying it was sent.
    /// </remarks>
    /// <response code="200">What happened, and the version as it now stands.</response>
    /// <response code="400">There is no address to send to, or nothing priced to send.</response>
    [HttpPost("{id:guid}/send")]
    [RequiresPermission(PermissionCodes.ApproveQuotations)]
    [ProducesResponseType<SendQuotationResult>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SendQuotationResult>> Send(
        Guid leadId, Guid id, SendQuotationRequest request, CancellationToken ct) =>
        Ok(await delivery.SendAsync(leadId, id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Records the client's answer to a version they were sent.</summary>
    /// <response code="200">The updated version.</response>
    /// <response code="409">This version has not been sent to the client.</response>
    [HttpPost("{id:guid}/decision")]
    [RequiresPermission(PermissionCodes.ApproveQuotations)]
    [ProducesResponseType<QuotationDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<QuotationDetailResponse>> RecordDecision(
        Guid leadId, Guid id, RecordQuotationDecisionRequest request, CancellationToken ct) =>
        Ok(await quotations.RecordDecisionAsync(leadId, id, request, currentUser.RequireEmployeeId(), ct));
}

/// <summary>The quotation item picker and its material options.</summary>
/// <remarks>
/// Its own controller because the catalogue belongs to no single lead: the tab fetches it once
/// and reuses it across every quotation the user opens.
/// </remarks>
[ApiController]
[Route("api/quotation-catalog")]
[Produces("application/json")]
[Tags("Quotations")]
public sealed class QuotationCatalogController(
    IQuotationService quotations, ICurrentUser currentUser) : ControllerBase
{
    /// <summary>Categories, items, variants, and the materials the rate card supports.</summary>
    /// <response code="200">The catalogue.</response>
    [HttpGet]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<QuotationCatalogResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<QuotationCatalogResponse>> Get(CancellationToken ct) =>
        Ok(await quotations.GetCatalogAsync(currentUser.RequireEmployeeId(), ct));
}
