using IBS.Api.Security;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>The record of who did what, and when (spec sections 4.5 and 7).</summary>
[ApiController]
[Route("api/audit-log")]
[Produces("application/json")]
[Tags("Audit log")]
public sealed class AuditLogController(IAuditService audit, ICurrentUser currentUser) : ControllerBase
{
    /// <summary>Queries the audit log.</summary>
    /// <remarks>
    /// Filters combine with AND, and results come back newest first. Pass a target id to see
    /// the history of one account, or an actor id to see everything one person has done.
    /// </remarks>
    /// <response code="200">A page of entries.</response>
    [HttpGet]
    [RequiresPermission(PermissionCodes.ViewAuditLog, PermissionCodes.ManageUsers)]
    [ProducesResponseType<PagedResult<AuditLogResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<AuditLogResponse>>> Query(
        [FromQuery] AuditLogQuery query, CancellationToken ct) =>
        Ok(await audit.QueryAsync(query, currentUser.RequireEmployeeId(), ct));
}
