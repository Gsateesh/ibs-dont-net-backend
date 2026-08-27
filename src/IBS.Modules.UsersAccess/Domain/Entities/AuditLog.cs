namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// An append-only record of who did what to which row (spec section 4.5).
/// Readable by holders of view_audit_log or manage_users.
/// </summary>
public class AuditLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Who acted. Null for system and seed actions.</summary>
    public Guid? ActorEmployeeId { get; set; }

    public Employee? ActorEmployee { get; set; }

    /// <summary>Verb from <c>AuditActions</c>, e.g. <c>employee.suspended</c>.</summary>
    public string Action { get; set; } = string.Empty;

    /// <summary>Entity type acted upon, e.g. <c>Employee</c>.</summary>
    public string TargetType { get; set; } = string.Empty;

    public Guid? TargetId { get; set; }

    public DateTimeOffset Timestamp { get; set; }

    /// <summary>Free-form JSON payload: before/after values, reason, request correlation id.</summary>
    public string? MetadataJson { get; set; }
}
