namespace IBS.SharedKernel.Primitives;

/// <summary>
/// Base type for entities that record who created them and when.
/// Every module inherits from this so audit columns are named identically across the monolith.
/// </summary>
public abstract class AuditableEntity
{
    /// <summary>Primary key.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>UTC timestamp of creation.</summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>Employee who created the row. Null for system/seed actions.</summary>
    public Guid? CreatedByEmployeeId { get; set; }

    /// <summary>UTC timestamp of the last update, null if never updated.</summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>Employee who last updated the row. Null for system actions.</summary>
    public Guid? UpdatedByEmployeeId { get; set; }
}
