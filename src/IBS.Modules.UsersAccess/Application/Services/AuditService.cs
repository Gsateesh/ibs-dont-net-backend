using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>Reading the audit log (spec section 7). Requires view_audit_log or manage_users.</summary>
public interface IAuditService
{
    Task<PagedResult<AuditLogResponse>> QueryAsync(AuditLogQuery query, Guid actorId, CancellationToken ct = default);
}

/// <inheritdoc cref="IAuditService" />
public sealed class AuditService(IUsersAccessDbContext db, IPermissionChecker permissions) : IAuditService
{
    public async Task<PagedResult<AuditLogResponse>> QueryAsync(
        AuditLogQuery query, Guid actorId, CancellationToken ct = default)
    {
        var allowed = await permissions.HasAnyPermissionAsync(
            actorId, [PermissionCodes.ViewAuditLog, PermissionCodes.ManageUsers], ct);

        if (!allowed)
        {
            throw new SharedKernel.Exceptions.ForbiddenException(
                "Reading the audit log requires the view_audit_log or manage_users permission.");
        }

        var q = db.AuditLogs.AsNoTracking().AsQueryable();

        if (query.TargetId is not null)
        {
            q = q.Where(a => a.TargetId == query.TargetId);
        }

        if (query.ActorId is not null)
        {
            q = q.Where(a => a.ActorEmployeeId == query.ActorId);
        }

        if (!string.IsNullOrWhiteSpace(query.Action))
        {
            var action = query.Action.Trim();
            q = q.Where(a => a.Action == action);
        }

        if (query.From is not null)
        {
            q = q.Where(a => a.Timestamp >= query.From);
        }

        if (query.To is not null)
        {
            q = q.Where(a => a.Timestamp < query.To);
        }

        var total = await q.CountAsync(ct);

        var items = await q
            .OrderByDescending(a => a.Timestamp)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(a => new AuditLogResponse
            {
                Id = a.Id,
                ActorEmployeeId = a.ActorEmployeeId,
                ActorName = a.ActorEmployee == null
                    ? null
                    : a.ActorEmployee.FirstName + " " + a.ActorEmployee.LastName,
                Action = a.Action,
                TargetType = a.TargetType,
                TargetId = a.TargetId,
                Timestamp = a.Timestamp,
                MetadataJson = a.MetadataJson
            })
            .ToListAsync(ct);

        return new PagedResult<AuditLogResponse>(items, query.Page, query.PageSize, total);
    }
}
