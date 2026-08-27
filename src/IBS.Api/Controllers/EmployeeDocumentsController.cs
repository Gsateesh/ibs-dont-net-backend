using IBS.Api.Security;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// Files attached to a person, held in Blob Storage (spec section 7).
/// </summary>
[ApiController]
[Route("api/employees/{employeeId:guid}/documents")]
[Produces("application/json")]
[Tags("Employee documents")]
public sealed class EmployeeDocumentsController(IDocumentService documents, ICurrentUser currentUser) : ControllerBase
{
    /// <summary>Lists the documents held against a person.</summary>
    /// <remarks>Each entry carries a short-lived read URL, minted fresh on every response.</remarks>
    /// <response code="200">The documents.</response>
    [HttpGet]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType<IReadOnlyList<EmployeeDocumentResponse>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<EmployeeDocumentResponse>>> List(
        Guid employeeId, CancellationToken ct) =>
        Ok(await documents.ListAsync(employeeId, currentUser.RequireEmployeeId(), ct));

    /// <summary>Uploads a document.</summary>
    /// <remarks>
    /// Multipart form: the file itself plus a type and an optional expiry date. The bytes go to
    /// Blob Storage; the database keeps only the reference.
    /// </remarks>
    /// <param name="employeeId">Whose file cabinet this is.</param>
    /// <param name="file">The file to upload.</param>
    /// <param name="metadata">Document type and optional expiry.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="201">Uploaded.</response>
    /// <response code="400">No file was supplied.</response>
    [HttpPost]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(25 * 1024 * 1024)]
    [ProducesResponseType<EmployeeDocumentResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmployeeDocumentResponse>> Upload(
        Guid employeeId,
        IFormFile file,
        [FromForm] UploadDocumentRequest metadata,
        CancellationToken ct)
    {
        if (file is null || file.Length == 0)
        {
            return BadRequest(new ProblemDetails { Title = "No file", Detail = "Attach a file to upload." });
        }

        await using var stream = file.OpenReadStream();

        var created = await documents.UploadAsync(
            employeeId, metadata, file.FileName, file.ContentType, stream, currentUser.RequireEmployeeId(), ct);

        return CreatedAtAction(nameof(List), new { employeeId }, created);
    }

    /// <summary>Deletes a document, from both the database and Blob Storage.</summary>
    /// <response code="204">Deleted.</response>
    /// <response code="404">No such document for this person.</response>
    [HttpDelete("{documentId:guid}")]
    [RequiresPermission(PermissionCodes.ManageUsers)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid employeeId, Guid documentId, CancellationToken ct)
    {
        await documents.DeleteAsync(employeeId, documentId, currentUser.RequireEmployeeId(), ct);
        return NoContent();
    }
}
