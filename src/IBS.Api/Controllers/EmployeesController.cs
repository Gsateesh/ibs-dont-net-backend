using IBS.Api.Security;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// The Team list, Person Detail and the account lifecycle actions (spec section 7).
/// </summary>
/// <remarks>
/// Reading is open to anyone holding manage_users. Mutating is narrower: it runs through
/// CanManageAccount, which reaches every account except the one belonging to the Super Admin.
/// The checks live in the service layer, so hiding a button in the UI is never what stops a call.
/// </remarks>
[ApiController]
[Route("api/employees")]
[Produces("application/json")]
[Tags("Employees")]
public sealed class EmployeesController(
    IEmployeeService employees,
    IStatutoryService statutory,
    IPermissionService permissions,
    ICurrentUser currentUser) : ControllerBase
{
    /// <summary>Lists people, filtered and paged.</summary>
    /// <response code="200">A page of the team.</response>
    [HttpGet]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<PagedResult<EmployeeListItemResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<EmployeeListItemResponse>>> List(
        [FromQuery] EmployeeQuery query, CancellationToken ct) =>
        Ok(await employees.ListAsync(query, currentUser.RequireEmployeeId(), ct));

    /// <summary>Creates a person and emails them an invite.</summary>
    /// <remarks>
    /// The row is created with no password at all: the invite link is the only way it gets one,
    /// and the employee is the only person who ever knows it.
    ///
    /// Permission codes may be granted here in the same call, but granting manage_permissions or
    /// view_sensitive_data still requires the caller to hold manage_permissions.
    /// </remarks>
    /// <response code="201">Created; the invite has been queued.</response>
    /// <response code="409">The email or employee code is already taken.</response>
    [HttpPost]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<EmployeeDetailResponse>> Create(CreateEmployeeRequest request, CancellationToken ct)
    {
        var created = await employees.CreateAsync(request, currentUser.RequireEmployeeId(), ct);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    /// <summary>The profile of the signed-in employee.</summary>
    /// <response code="200">Your own profile.</response>
    [HttpGet("me")]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeDetailResponse>> GetOwnProfile(CancellationToken ct) =>
        Ok(await employees.GetOwnProfileAsync(currentUser.RequireEmployeeId(), ct));

    /// <summary>Updates your own personal and contact details.</summary>
    /// <remarks>
    /// Designation, permissions and status are not part of this payload. Changing those is
    /// the job of somebody else, acting through the endpoints below (spec section 5.6).
    /// </remarks>
    /// <response code="200">Updated profile.</response>
    [HttpPut("me")]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeDetailResponse>> UpdateOwnProfile(
        UpdateMyProfileRequest request, CancellationToken ct) =>
        Ok(await employees.UpdateOwnProfileAsync(currentUser.RequireEmployeeId(), request, ct));

    /// <summary>Changes your own password.</summary>
    /// <response code="204">Password changed.</response>
    /// <response code="400">The current password is wrong, or the new one is too short.</response>
    [HttpPut("me/password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeOwnPassword(
        [FromServices] IAuthService auth, ChangePasswordRequest request, CancellationToken ct)
    {
        await auth.ChangeOwnPasswordAsync(currentUser.RequireEmployeeId(), request, ct);
        return NoContent();
    }

    /// <summary>One person, with what you are allowed to do to their account.</summary>
    /// <param name="id">Employee id.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="200">The person.</response>
    /// <response code="404">No such employee.</response>
    [HttpGet("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeDetailResponse>> Get(Guid id, CancellationToken ct) =>
        Ok(await employees.GetAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Updates a person.</summary>
    /// <remarks>Rejects any reporting-manager assignment that would close a cycle.</remarks>
    /// <response code="200">The updated person.</response>
    /// <response code="403">Only the Super Admin may edit the Super Admin account.</response>
    [HttpPut("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<EmployeeDetailResponse>> Update(
        Guid id, UpdateEmployeeRequest request, CancellationToken ct) =>
        Ok(await employees.UpdateAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Sends the invite link again.</summary>
    /// <remarks>Only while the account is still awaiting activation. Any earlier unused invite stops working.</remarks>
    /// <response code="200">A fresh invite has been issued. Carries the link when email is off.</response>
    /// <response code="400">The account is past the invited stage.</response>
    [HttpPost("{id:guid}/resend-invite")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<InvitationLinkResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InvitationLinkResponse>> ResendInvite(Guid id, CancellationToken ct) =>
        Ok(await employees.ResendInviteAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Emails the person a password-reset link.</summary>
    /// <remarks>
    /// Never sets or displays a password. An administrator can start the reset, but only the
    /// employee ever chooses the value.
    /// </remarks>
    /// <response code="200">A reset link has been issued. Carries the link when email is off.</response>
    [HttpPost("{id:guid}/reset-password")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<InvitationLinkResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<InvitationLinkResponse>> ResetPassword(Guid id, CancellationToken ct) =>
        Ok(await employees.ResetPasswordAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Suspends an account, blocking sign-in.</summary>
    /// <response code="200">The suspended person.</response>
    [HttpPost("{id:guid}/suspend")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeDetailResponse>> Suspend(
        Guid id, StatusChangeRequest request, CancellationToken ct) =>
        Ok(await employees.SuspendAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Lifts a suspension.</summary>
    /// <remarks>
    /// Someone who never activated returns to Invited rather than Active - they still have no
    /// password, so there is nothing to sign in with yet.
    /// </remarks>
    /// <response code="200">The reinstated person.</response>
    [HttpPost("{id:guid}/reinstate")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<EmployeeDetailResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeDetailResponse>> Reinstate(
        Guid id, StatusChangeRequest request, CancellationToken ct) =>
        Ok(await employees.ReinstateAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Deactivates an account.</summary>
    /// <remarks>
    /// Runs the open-work check first. The other modules do not exist yet, so nothing is found
    /// today; when they land, this is where a reassignment step will surface.
    /// </remarks>
    /// <response code="200">Deactivated, or blocked pending reassignment - see the response body.</response>
    [HttpPost("{id:guid}/deactivate")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<DeactivationResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<DeactivationResponse>> Deactivate(
        Guid id, StatusChangeRequest request, CancellationToken ct) =>
        Ok(await employees.DeactivateAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Permanently deletes a person and everything their record owns.</summary>
    /// <remarks>
    /// **This cannot be undone.** Prefer `POST /employees/{id}/deactivate`, which keeps the row
    /// and the history attached to it.
    ///
    /// Removed by cascade: professional profile, sales targets, statutory record, documents
    /// (including the files in Blob Storage), permission grants and activation tokens.
    ///
    /// Kept, but detached: anyone reporting to this person has their reporting line cleared,
    /// permission grants they issued to other people lose the "granted by" name, and audit
    /// entries they authored are anonymised rather than deleted - those entries also record what
    /// they did to other people, and that history should outlive the account.
    ///
    /// The Super Admin account cannot be deleted, and nobody can delete themselves.
    /// </remarks>
    /// <param name="id">Employee to delete.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="200">Deleted, with a summary of what went and what was detached.</response>
    /// <response code="400">The target is the Super Admin, or is the caller.</response>
    /// <response code="403">Only the Super Admin may act on the Super Admin account.</response>
    /// <response code="404">No such employee.</response>
    [HttpDelete("{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<DeleteEmployeeResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeleteEmployeeResponse>> Delete(Guid id, CancellationToken ct) =>
        Ok(await employees.DeleteAsync(id, currentUser.RequireEmployeeId(), ct));

    // --- statutory (spec section 5.5) ---------------------------------------------

    /// <summary>The statutory record: PAN, Aadhaar, PF, ESIC, bank details and CTC.</summary>
    /// <remarks>
    /// Visible only to the Super Admin, holders of view_sensitive_data, and the employee
    /// themself. For anyone else the record is not returned at all - it is absent, not masked.
    /// PAN, Aadhaar and bank details are stored under Always Encrypted, so they are unreadable
    /// even to a database administrator without the column encryption key.
    /// </remarks>
    /// <response code="200">The statutory record, empty when nothing has been recorded yet.</response>
    /// <response code="403">You are not on the allow-list for this record.</response>
    [HttpGet("{id:guid}/statutory")]
    [RequiresPermission(PermissionCodes.ViewSensitiveData)]
    [ProducesResponseType<StatutoryDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<StatutoryDto>> GetStatutory(Guid id, CancellationToken ct) =>
        Ok(await statutory.GetAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Creates or replaces the statutory record.</summary>
    /// <response code="200">The stored record.</response>
    /// <response code="403">You are not on the allow-list for this record.</response>
    [HttpPut("{id:guid}/statutory")]
    [RequiresPermission(PermissionCodes.ViewSensitiveData)]
    [ProducesResponseType<StatutoryDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<StatutoryDto>> UpsertStatutory(
        Guid id, StatutoryDto request, CancellationToken ct) =>
        Ok(await statutory.UpsertAsync(id, request, currentUser.RequireEmployeeId(), ct));

    // --- permissions (Access tab) -------------------------------------------------

    /// <summary>The permissions held by one person, and who granted each.</summary>
    /// <remarks>A Super Admin holds no grant rows: the whole catalogue is reported as implicit.</remarks>
    /// <response code="200">The grants on the Access tab.</response>
    [HttpGet("{id:guid}/permissions")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<IReadOnlyList<EmployeePermissionResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<EmployeePermissionResponse>>> GetPermissions(
        Guid id, CancellationToken ct) =>
        Ok(await permissions.GetEmployeePermissionsAsync(id, currentUser.RequireEmployeeId(), ct));

    /// <summary>Replaces the permission set of one person.</summary>
    /// <remarks>
    /// Send the complete list: codes present are granted, codes absent are revoked.
    ///
    /// Adding manage_permissions or view_sensitive_data requires the caller to hold
    /// manage_permissions. Without that rule, any manage_users holder could grant themselves
    /// the very permission those two were split apart to protect (spec section 5.4).
    /// </remarks>
    /// <response code="200">The resulting grants.</response>
    /// <response code="403">Escalation blocked, or the target account is out of reach.</response>
    [HttpPut("{id:guid}/permissions")]
    [RequiresPermission(PermissionCodes.ManageUsers, PermissionCodes.ManagePermissions)]
    [ProducesResponseType<IReadOnlyList<EmployeePermissionResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IReadOnlyList<EmployeePermissionResponse>>> SetPermissions(
        Guid id, UpdateEmployeePermissionsRequest request, CancellationToken ct) =>
        Ok(await permissions.SetEmployeePermissionsAsync(id, request, currentUser.RequireEmployeeId(), ct));
}
