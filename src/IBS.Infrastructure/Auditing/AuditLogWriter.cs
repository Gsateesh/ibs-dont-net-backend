using System.Text.Json;
using IBS.Infrastructure.Persistence;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Time;

namespace IBS.Infrastructure.Auditing;

/// <summary>
/// Appends audit rows to the same change tracker as the work being audited, so the entry and
/// the change it describes commit or roll back together (spec section 4.5).
/// </summary>
public sealed class AuditLogWriter(IbsDbContext db, IClock clock) : IAuditLogWriter
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public Task WriteAsync(
        string action,
        string targetType,
        Guid? targetId,
        Guid? actorEmployeeId,
        object? metadata = null,
        CancellationToken ct = default)
    {
        db.AuditLogs.Add(new AuditLog
        {
            Action = action,
            TargetType = targetType,
            TargetId = targetId,
            ActorEmployeeId = actorEmployeeId,
            Timestamp = clock.UtcNow,
            MetadataJson = metadata is null ? null : JsonSerializer.Serialize(metadata, JsonOptions)
        });

        // No SaveChanges here on purpose: the caller decides the transaction boundary.
        _ = ct;
        return Task.CompletedTask;
    }
}
