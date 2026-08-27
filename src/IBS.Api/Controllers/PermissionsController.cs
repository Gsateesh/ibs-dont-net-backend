using IBS.Api.Security;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// The permission catalogue (spec sections 4.4 and 7).
/// </summary>
/// <remarks>
/// Entries come into existence only through a migration, alongside the feature they gate.
/// This API can rename, redescribe and regroup them; it can never create or delete one.
/// </remarks>
[ApiController]
[Route("api/permissions")]
[Produces("application/json")]
[Tags("Permissions")]
public sealed class PermissionsController(IPermissionService permissions, ICurrentUser currentUser) : ControllerBase
{
    /// <summary>The catalogue, grouped as the checklist UI renders it.</summary>
    /// <remarks>Each entry carries how many people hold it, which is the Settings page tally.</remarks>
    /// <response code="200">The catalogue.</response>
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<PermissionGroupResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PermissionGroupResponse>>> GetCatalogue(CancellationToken ct) =>
        Ok(await permissions.GetCatalogueAsync(ct));

    /// <summary>Renames, redescribes or regroups one catalogue entry.</summary>
    /// <remarks>The code is not editable: it is what the codebase checks against.</remarks>
    /// <param name="id">Catalogue entry id.</param>
    /// <param name="request">New label, description and group.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="200">The updated entry.</response>
    /// <response code="404">No such permission.</response>
    [HttpPut("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManagePermissions)]
    [ProducesResponseType<PermissionResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermissionResponse>> Update(
        Guid id, UpdatePermissionRequest request, CancellationToken ct) =>
        Ok(await permissions.UpdateCatalogueEntryAsync(id, request, currentUser.RequireEmployeeId(), ct));
}
