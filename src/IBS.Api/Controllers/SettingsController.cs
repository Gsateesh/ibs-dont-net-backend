using IBS.Api.Security;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// Company profile, branches, departments and designations (spec sections 4.1 and 7).
/// </summary>
/// <remarks>
/// Reading is open to any signed-in employee, because the Add Person form needs these lists.
/// Writing requires manage_company_settings. A lookup row still referenced by an employee
/// cannot be deleted until every one of them is reassigned.
/// </remarks>
[ApiController]
[Route("api/settings")]
[Produces("application/json")]
[Tags("Settings")]
public sealed class SettingsController(ISettingsService settings, ICurrentUser currentUser) : ControllerBase
{
    /// <summary>The company profile.</summary>
    /// <response code="200">The company.</response>
    [HttpGet("company")]
    [ProducesResponseType<CompanyResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<CompanyResponse>> GetCompany(CancellationToken ct) =>
        Ok(await settings.GetCompanyAsync(ct));

    /// <summary>Updates the company profile.</summary>
    /// <response code="200">The updated company.</response>
    [HttpPut("company")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<CompanyResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<CompanyResponse>> UpdateCompany(
        UpdateCompanyRequest request, CancellationToken ct) =>
        Ok(await settings.UpdateCompanyAsync(request, currentUser.RequireEmployeeId(), ct));

    // --- branches -----------------------------------------------------------------

    /// <summary>Lists branches, each with how many people are posted there.</summary>
    /// <response code="200">The branches.</response>
    [HttpGet("branches")]
    [ProducesResponseType<IReadOnlyList<BranchResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<BranchResponse>>> GetBranches(CancellationToken ct) =>
        Ok(await settings.GetBranchesAsync(ct));

    /// <summary>Adds a branch.</summary>
    /// <response code="201">Created.</response>
    /// <response code="409">A branch with that name already exists.</response>
    [HttpPost("branches")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<BranchResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BranchResponse>> CreateBranch(BranchRequest request, CancellationToken ct)
    {
        var created = await settings.CreateBranchAsync(request, currentUser.RequireEmployeeId(), ct);
        return CreatedAtAction(nameof(GetBranches), new { }, created);
    }

    /// <summary>Updates a branch.</summary>
    /// <response code="200">The updated branch.</response>
    [HttpPut("branches/{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<BranchResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<BranchResponse>> UpdateBranch(
        Guid id, BranchRequest request, CancellationToken ct) =>
        Ok(await settings.UpdateBranchAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Deletes a branch.</summary>
    /// <remarks>Blocked while anyone is still posted there.</remarks>
    /// <response code="204">Deleted.</response>
    /// <response code="409">Still in use; reassign those employees first.</response>
    [HttpDelete("branches/{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteBranch(Guid id, CancellationToken ct)
    {
        await settings.DeleteBranchAsync(id, currentUser.RequireEmployeeId(), ct);
        return NoContent();
    }

    // --- departments --------------------------------------------------------------

    /// <summary>Lists departments, each with its headcount.</summary>
    /// <response code="200">The departments.</response>
    [HttpGet("departments")]
    [ProducesResponseType<IReadOnlyList<DepartmentResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<DepartmentResponse>>> GetDepartments(CancellationToken ct) =>
        Ok(await settings.GetDepartmentsAsync(ct));

    /// <summary>Adds a department.</summary>
    /// <response code="201">Created.</response>
    /// <response code="409">A department with that name already exists.</response>
    [HttpPost("departments")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<DepartmentResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<DepartmentResponse>> CreateDepartment(
        DepartmentRequest request, CancellationToken ct)
    {
        var created = await settings.CreateDepartmentAsync(request, currentUser.RequireEmployeeId(), ct);
        return CreatedAtAction(nameof(GetDepartments), new { }, created);
    }

    /// <summary>Renames a department.</summary>
    /// <response code="200">The updated department.</response>
    [HttpPut("departments/{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<DepartmentResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<DepartmentResponse>> UpdateDepartment(
        Guid id, DepartmentRequest request, CancellationToken ct) =>
        Ok(await settings.UpdateDepartmentAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Deletes a department.</summary>
    /// <remarks>Blocked while anyone still belongs to it.</remarks>
    /// <response code="204">Deleted.</response>
    /// <response code="409">Still in use; reassign those employees first.</response>
    [HttpDelete("departments/{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteDepartment(Guid id, CancellationToken ct)
    {
        await settings.DeleteDepartmentAsync(id, currentUser.RequireEmployeeId(), ct);
        return NoContent();
    }

    // --- designations -------------------------------------------------------------

    /// <summary>Lists designations.</summary>
    /// <remarks>Descriptive only: a designation grants nothing at all (spec section 5.1).</remarks>
    /// <response code="200">The designations.</response>
    [HttpGet("designations")]
    [ProducesResponseType<IReadOnlyList<DesignationResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<DesignationResponse>>> GetDesignations(CancellationToken ct) =>
        Ok(await settings.GetDesignationsAsync(ct));

    /// <summary>Adds a designation.</summary>
    /// <response code="201">Created.</response>
    /// <response code="409">A designation with that name already exists.</response>
    [HttpPost("designations")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<DesignationResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<DesignationResponse>> CreateDesignation(
        DesignationRequest request, CancellationToken ct)
    {
        var created = await settings.CreateDesignationAsync(request, currentUser.RequireEmployeeId(), ct);
        return CreatedAtAction(nameof(GetDesignations), new { }, created);
    }

    /// <summary>Updates a designation.</summary>
    /// <response code="200">The updated designation.</response>
    [HttpPut("designations/{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType<DesignationResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<DesignationResponse>> UpdateDesignation(
        Guid id, DesignationRequest request, CancellationToken ct) =>
        Ok(await settings.UpdateDesignationAsync(id, request, currentUser.RequireEmployeeId(), ct));

    /// <summary>Deletes a designation.</summary>
    /// <remarks>Blocked while anyone still holds it.</remarks>
    /// <response code="204">Deleted.</response>
    /// <response code="409">Still in use; reassign those employees first.</response>
    [HttpDelete("designations/{id:guid}")]
    [RequiresPermission(PermissionCodes.ManageCompanySettings)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteDesignation(Guid id, CancellationToken ct)
    {
        await settings.DeleteDesignationAsync(id, currentUser.RequireEmployeeId(), ct);
        return NoContent();
    }
}
