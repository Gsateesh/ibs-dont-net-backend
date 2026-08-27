namespace IBS.SharedKernel.Auditing;

/// <summary>One audit row, with the actor's name resolved for display.</summary>
public sealed record AuditLogEntry(
    Guid Id,
    Guid? ActorEmployeeId,
    string? ActorName,
    string Action,
    DateTimeOffset Timestamp,
    string? MetadataJson);

/// <summary>
/// Read side of <see cref="IAuditLogWriter"/>, scoped to one target. Exists so a module that
/// cannot call the manage_users/view_audit_log-gated audit endpoints (e.g. a manage_leads-only
/// caller) can still show the history of the one record it owns.
/// </summary>
public interface IAuditLogReader
{
    /// <summary>All audit rows recorded against one target, newest first.</summary>
    Task<IReadOnlyList<AuditLogEntry>> GetForTargetAsync(Guid targetId, CancellationToken ct = default);
}
