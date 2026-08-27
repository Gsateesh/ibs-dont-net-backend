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
/// Reading (list/detail) is open to every signed-in employee: the service scopes the result to
/// the caller's own assigned leads unless they hold manage_leads, in which case they see and
/// manage everything. Every mutating action, plus the assignable-employees lookup and the
/// assignment history, requires manage_leads. The checks live in the service layer.
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
    [ProducesResponseType<LeadDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeadDetailResponse>> Get(Guid id, CancellationToken ct) =>
        Ok(await leads.GetAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Creates a lead.</summary>
    /// <remarks>Starts at Status = New. May optionally be assigned at creation.</remarks>
    /// <response code="201">Created.</response>
    [HttpPost]
    [RequiresPermission(PermissionCodes.ManageLeads)]
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
    [RequiresPermission(PermissionCodes.ManageLeads)]
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
