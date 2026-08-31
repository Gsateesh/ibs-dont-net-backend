using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Options;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Storage;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>Employee documents, stored in Blob Storage (spec sections 4.3 and 7).</summary>
public interface IDocumentService
{
    Task<IReadOnlyList<EmployeeDocumentResponse>> ListAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);

    Task<EmployeeDocumentResponse> UploadAsync(
        Guid employeeId,
        UploadDocumentRequest metadata,
        string fileName,
        string? contentType,
        Stream content,
        Guid actorId,
        CancellationToken ct = default);

    Task DeleteAsync(Guid employeeId, Guid documentId, Guid actorId, CancellationToken ct = default);
}

/// <inheritdoc cref="IDocumentService" />
public sealed class DocumentService(
    IUsersAccessDbContext db,
    IFileStorage storage,
    IPermissionChecker permissions,
    IAuditLogWriter audit,
    IClock clock,
    IOptions<UsersAccessOptions> options) : IDocumentService
{
    private static readonly TimeSpan ReadUrlLifetime = TimeSpan.FromMinutes(15);
    private readonly UsersAccessOptions _options = options.Value;

    public async Task<IReadOnlyList<EmployeeDocumentResponse>> ListAsync(
        Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        await RequireVisibilityAsync(employeeId, actorId, ct);

        var documents = await db.EmployeeDocuments
            .AsNoTracking()
            .Where(d => d.EmployeeId == employeeId)
            .OrderByDescending(d => d.UploadedAt)
            .ToListAsync(ct);

        var uploaderNames = await ResolveUploaderNamesAsync(documents, ct);

        var result = new List<EmployeeDocumentResponse>(documents.Count);
        foreach (var document in documents)
        {
            result.Add(await MapAsync(document, uploaderNames, ct));
        }

        return result;
    }

    public async Task<EmployeeDocumentResponse> UploadAsync(
        Guid employeeId,
        UploadDocumentRequest metadata,
        string fileName,
        string? contentType,
        Stream content,
        Guid actorId,
        CancellationToken ct = default)
    {
        // Uploading is a mutation of the account of someone else, so it goes through CanManageAccount
        // unless the employee is managing their own file cabinet.
        if (actorId != employeeId)
        {
            await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);
        }

        if (!await db.Employees.AnyAsync(e => e.Id == employeeId, ct))
        {
            throw new NotFoundException("Employee", employeeId);
        }

        var now = clock.UtcNow;
        var safeName = Path.GetFileName(fileName);
        var blobName = $"{employeeId}/{Guid.NewGuid():N}-{safeName}";

        var blobUrl = await storage.UploadAsync(_options.DocumentContainer, blobName, content, contentType, ct);

        var document = new EmployeeDocument
        {
            EmployeeId = employeeId,
            Type = metadata.Type,
            FileName = safeName,
            ContentType = contentType,
            SizeInBytes = content.CanSeek ? content.Length : 0,
            BlobUrl = blobUrl,
            ExpiryDate = metadata.ExpiryDate,
            UploadedAt = now,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        db.EmployeeDocuments.Add(document);

        await audit.WriteAsync(
            AuditActions.DocumentUploaded, nameof(EmployeeDocument), document.Id, actorId,
            new { employeeId, document.FileName, document.Type }, ct);

        await db.SaveChangesAsync(ct);

        var names = await ResolveUploaderNamesAsync([document], ct);
        return await MapAsync(document, names, ct);
    }

    public async Task DeleteAsync(Guid employeeId, Guid documentId, Guid actorId, CancellationToken ct = default)
    {
        if (actorId != employeeId)
        {
            await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);
        }

        var document = await db.EmployeeDocuments
            .FirstOrDefaultAsync(d => d.Id == documentId && d.EmployeeId == employeeId, ct)
            ?? throw new NotFoundException("Document", documentId);

        await storage.DeleteAsync(document.BlobUrl, ct);
        db.EmployeeDocuments.Remove(document);

        await audit.WriteAsync(
            AuditActions.DocumentDeleted, nameof(EmployeeDocument), documentId, actorId,
            new { employeeId, document.FileName }, ct);

        await db.SaveChangesAsync(ct);
    }

    private async Task RequireVisibilityAsync(Guid employeeId, Guid actorId, CancellationToken ct)
    {
        if (actorId == employeeId)
        {
            return;
        }

        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageUsers, ct);
    }

    private async Task<Dictionary<Guid, string>> ResolveUploaderNamesAsync(
        IReadOnlyCollection<EmployeeDocument> documents, CancellationToken ct)
    {
        var ids = documents
            .Where(d => d.CreatedByEmployeeId is not null)
            .Select(d => d.CreatedByEmployeeId!.Value)
            .Distinct()
            .ToList();

        if (ids.Count == 0)
        {
            return [];
        }

        return await db.Employees
            .AsNoTracking()
            .Where(e => ids.Contains(e.Id))
            .ToDictionaryAsync(e => e.Id, e => e.FirstName + " " + e.LastName, ct);
    }

    private async Task<EmployeeDocumentResponse> MapAsync(
        EmployeeDocument document, Dictionary<Guid, string> uploaderNames, CancellationToken ct) =>
        new()
        {
            Id = document.Id,
            EmployeeId = document.EmployeeId,
            Type = document.Type,
            FileName = document.FileName,
            ContentType = document.ContentType,
            SizeInBytes = document.SizeInBytes,
            // Never the raw blob path: a short-lived read URL, minted per response.
            Url = await storage.GetReadUrlAsync(document.BlobUrl, ReadUrlLifetime, ct),
            ExpiryDate = document.ExpiryDate,
            UploadedAt = document.UploadedAt,
            UploadedByName = document.CreatedByEmployeeId is not null &&
                             uploaderNames.TryGetValue(document.CreatedByEmployeeId.Value, out var name)
                ? name
                : null
        };
}
