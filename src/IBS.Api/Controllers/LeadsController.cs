using IBS.Api.Security;
using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Application.Services;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// Lead capture and assignment.
/// </summary>
/// <remarks>
/// Two permissions open this module. manage_own_leads sees and edits only the leads assigned
/// to the caller; manage_leads sees and edits every lead and additionally may assign, reassign
/// and delete. A caller holding neither is refused outright. A lead outside the caller's reach
/// answers 404 rather than 403, so ids cannot be probed. The checks live in the service layer -
/// the attributes below only document them.
/// </remarks>
[ApiController]
[Route("api/leads")]
[Produces("application/json")]
[Tags("Leads")]
public sealed class LeadsController(ILeadService leads, ICurrentUser currentUser) : ControllerBase
{
    /// <summary>Lists leads, filtered and paged.</summary>
    /// <remarks>
    /// Callers without manage_leads always see only leads assigned to themself, regardless of
    /// the assignedToEmployeeId filter.
    /// </remarks>
    /// <response code="200">A page of leads.</response>
    [HttpGet]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<PagedResult<LeadListItemResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<LeadListItemResponse>>> List(
        [FromQuery] LeadQuery query, CancellationToken ct) =>
        Ok(await leads.ListAsync(query, currentUser.RequireEmployeeId(), ct));

    /// <summary>One lead, with what you are allowed to do with it.</summary>
    /// <param name="id">Lead id.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="200">The lead.</response>
    /// <response code="404">No such lead, or it is not visible to you.</response>
    [HttpGet("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeadDetailResponse>> Get(Guid id, CancellationToken ct) =>
        Ok(await leads.GetAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Creates a lead.</summary>
    /// <remarks>
    /// Starts at Status = New. A manage_leads holder may assign it to anyone at creation; a
    /// manage_own_leads holder always gets it assigned to themself.
    /// </remarks>
    /// <response code="201">Created.</response>
    [HttpPost]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status201Created)]
    public async Task<ActionResult<LeadDetailResponse>> Create(CreateLeadRequest request, CancellationToken ct)
    {
        var created = await leads.CreateAsync(request, currentUser.RequireEmployeeId(), ct);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    /// <summary>Updates a lead's contact, property and status detail.</summary>
    /// <remarks>Assignment is not part of this payload - use assign/unassign/bulk-assign.</remarks>
    /// <response code="200">The updated lead.</response>
    /// <response code="404">No such lead.</response>
    [HttpPut("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeadDetailResponse>> Update(
        Guid id, UpdateLeadRequest request, CancellationToken ct) =>
        Ok(await leads.UpdateAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Permanently deletes a lead.</summary>
    /// <response code="204">Deleted.</response>
    /// <response code="404">No such lead.</response>
    [HttpDelete("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageLeads)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await leads.DeleteAsync(id, currentUser.RequireEmployeeId(), ct);
        return NoContent();
    }

    /// <summary>Assigns (or reassigns) a lead to one employee.</summary>
    /// <response code="200">The updated lead.</response>
    [HttpPost("{id:guid}/assign")]
    [RequiresPermission(PermissionCodes.ManageLeads)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<LeadDetailResponse>> Assign(
        Guid id, AssignLeadRequest request, CancellationToken ct) =>
        Ok(await leads.AssignAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Clears a lead's assignment.</summary>
    /// <response code="200">The updated lead.</response>
    /// <response code="400">The lead was not assigned to begin with.</response>
    [HttpPost("{id:guid}/unassign")]
    [RequiresPermission(PermissionCodes.ManageLeads)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LeadDetailResponse>> Unassign(Guid id, CancellationToken ct) =>
        Ok(await leads.UnassignAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Assigns many leads to one employee in a single action.</summary>
    /// <response code="200">How many leads were updated, and which requested ids were not found.</response>
    [HttpPost("bulk-assign")]
    [RequiresPermission(PermissionCodes.ManageLeads)]
    [ProducesResponseType<BulkAssignResult>(StatusCodes.Status200OK)]
    public async Task<ActionResult<BulkAssignResult>> BulkAssign(BulkAssignLeadsRequest request, CancellationToken ct) =>
        Ok(await leads.BulkAssignAsync(request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Returns the lead's floor plan image.</summary>
    /// <remarks>
    /// Streamed through the API rather than served from a storage URL, so the image is exactly
    /// as visible as the lead itself: an owner can fetch the plan of a lead assigned to them and
    /// gets a 404 for anyone else's.
    /// </remarks>
    /// <response code="200">The image bytes.</response>
    /// <response code="404">No such lead, it is not visible to you, or it has no floor plan.</response>
    // Deliberately no [Produces] listing the image types: it would also constrain the
    // ProblemDetails this action returns on a miss, which is JSON.
    [HttpGet("{id:guid}/floor-plan")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFloorPlan(Guid id, CancellationToken ct)
    {
        var plan = await leads.OpenFloorPlanAsync(id, currentUser.RequireEmployeeId(), ct);

        if (plan is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "No floor plan",
                Detail = "This lead has no floor plan on file."
            });
        }

        // Inline rather than as an attachment: the form and the detail page show it as an image.
        return File(plan.Content, plan.ContentType, enableRangeProcessing: true);
    }

    /// <summary>Uploads a floor plan, replacing any image already on file.</summary>
    /// <param name="id">Lead id.</param>
    /// <param name="file">A PNG, JPEG, WebP or GIF image.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="200">The updated lead.</response>
    /// <response code="400">No file was supplied, or it is not an accepted image type.</response>
    /// <response code="404">No such lead.</response>
    [HttpPost("{id:guid}/floor-plan")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(10 * 1024 * 1024)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeadDetailResponse>> UploadFloorPlan(Guid id, IFormFile file, CancellationToken ct)
    {
        if (file is null || file.Length == 0)
        {
            return BadRequest(new ProblemDetails { Title = "No file", Detail = "Attach an image to upload." });
        }

        await using var stream = file.OpenReadStream();

        return Ok(await leads.UploadFloorPlanAsync(
            id, file.FileName, file.ContentType, stream, currentUser.RequireEmployeeId(), ct));
    }

    /// <summary>Removes the lead's floor plan, from both the database and storage.</summary>
    /// <response code="200">The updated lead.</response>
    /// <response code="400">The lead had no floor plan to begin with.</response>
    /// <response code="404">No such lead.</response>
    [HttpDelete("{id:guid}/floor-plan")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeadDetailResponse>> DeleteFloorPlan(Guid id, CancellationToken ct) =>
        Ok(await leads.DeleteFloorPlanAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Lead counts per phase, for the quick-filter chips above the Leads list.</summary>
    /// <remarks>Scoped the same way the list is: an owner is counted only their own leads.</remarks>
    /// <response code="200">A count for every phase that currently has at least one lead.</response>
    [HttpGet("phase-counts")]
    [RequiresPermission(PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads)]
    [ProducesResponseType<IReadOnlyList<LeadPhaseCountResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<LeadPhaseCountResponse>>> GetPhaseCounts(CancellationToken ct) =>
        Ok(await leads.GetPhaseCountsAsync(currentUser.RequireEmployeeId(), ct));

    /// <summary>Employees selectable as a lead's assignee, for the assignment dropdown.</summary>
    /// <response code="200">Active employees.</response>
    [HttpGet("assignable-employees")]
    [RequiresPermission(PermissionCodes.ManageLeads)]
    [ProducesResponseType<IReadOnlyList<AssignableEmployeeResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AssignableEmployeeResponse>>> GetAssignableEmployees(CancellationToken ct) =>
        Ok(await leads.GetAssignableEmployeesAsync(currentUser.RequireEmployeeId(), ct));

    /// <summary>The full history of who assigned this lead, to whom, and when.</summary>
    /// <response code="200">History entries, newest first.</response>
    /// <response code="404">No such lead.</response>
    [HttpGet("{id:guid}/assignment-history")]
    [RequiresPermission(PermissionCodes.ManageLeads)]
    [ProducesResponseType<IReadOnlyList<LeadAssignmentHistoryEntry>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyList<LeadAssignmentHistoryEntry>>> GetAssignmentHistory(
        Guid id, CancellationToken ct) =>
        Ok(await leads.GetAssignmentHistoryAsync(id, currentUser.RequireEmployeeId(), ct));
}
