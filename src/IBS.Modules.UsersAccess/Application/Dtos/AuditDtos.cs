using System.ComponentModel.DataAnnotations;

namespace IBS.Modules.UsersAccess.Application.Dtos;

/// <summary>One audit entry.</summary>
public sealed class AuditLogResponse
{
    public Guid Id { get; set; }

    public Guid? ActorEmployeeId { get; set; }

    /// <summary>Name of the actor, or null for system and seed actions.</summary>
    public string? ActorName { get; set; }

    /// <example>employee.suspended</example>
    public string Action { get; set; } = string.Empty;

    /// <example>Employee</example>
    public string TargetType { get; set; } = string.Empty;

    public Guid? TargetId { get; set; }

    public DateTimeOffset Timestamp { get; set; }

    /// <summary>Structured detail captured at the time of the action.</summary>
    public string? MetadataJson { get; set; }
}

/// <summary>Filters for the audit log. All optional, combined with AND.</summary>
public sealed class AuditLogQuery
{
    /// <summary>Only entries about this target row.</summary>
    public Guid? TargetId { get; set; }

    /// <summary>Only entries produced by this actor.</summary>
    public Guid? ActorId { get; set; }

    /// <summary>Only entries with this exact action verb.</summary>
    /// <example>employee.suspended</example>
    [MaxLength(100)]
    public string? Action { get; set; }

    /// <summary>Inclusive lower bound on the timestamp.</summary>
    public DateTimeOffset? From { get; set; }

    /// <summary>Exclusive upper bound on the timestamp.</summary>
    public DateTimeOffset? To { get; set; }

    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    [Range(1, 200)]
    public int PageSize { get; set; } = 50;
}
