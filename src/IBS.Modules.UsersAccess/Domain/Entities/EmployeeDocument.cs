using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// A file attached to an employee, stored in Blob Storage (spec section 4.3).
/// The row holds the reference; the bytes never touch the database.
/// </summary>
public class EmployeeDocument : AuditableEntity
{
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public EmployeeDocumentType Type { get; set; } = EmployeeDocumentType.Other;

    /// <summary>Original file name as uploaded.</summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>MIME type recorded at upload time.</summary>
    public string? ContentType { get; set; }

    /// <summary>Size in bytes.</summary>
    public long SizeInBytes { get; set; }

    /// <summary>Blob Storage reference.</summary>
    public string BlobUrl { get; set; } = string.Empty;

    /// <summary>Expiry date for documents that lapse, e.g. a contract or a visa.</summary>
    public DateOnly? ExpiryDate { get; set; }

    public DateTimeOffset UploadedAt { get; set; }
}
