using IBS.Infrastructure.Persistence;
using IBS.SharedKernel.Auditing;
using Microsoft.EntityFrameworkCore;

namespace IBS.Infrastructure.Auditing;

/// <inheritdoc cref="IAuditLogReader" />
public sealed class AuditLogReader(IbsDbContext db) : IAuditLogReader
{
    public async Task<IReadOnlyList<AuditLogEntry>> GetForTargetAsync(Guid targetId, CancellationToken ct = default) =>
        await db.AuditLogs
            .AsNoTracking()
            .Where(a => a.TargetId == targetId)
            .OrderByDescending(a => a.Timestamp)
            .Select(a => new AuditLogEntry(
                a.Id,
                a.ActorEmployeeId,
                a.ActorEmployee == null ? null : a.ActorEmployee.FirstName + " " + a.ActorEmployee.LastName,
                a.Action,
                a.Timestamp,
                a.MetadataJson))
            .ToListAsync(ct);
}
