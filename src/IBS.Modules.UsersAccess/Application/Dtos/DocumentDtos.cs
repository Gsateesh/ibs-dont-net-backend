using System.ComponentModel.DataAnnotations;
using IBS.Modules.UsersAccess.Domain.Enums;

namespace IBS.Modules.UsersAccess.Application.Dtos;

/// <summary>An uploaded employee document.</summary>
public sealed class EmployeeDocumentResponse
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public EmployeeDocumentType Type { get; set; }

    /// <example>offer-letter.pdf</example>
    public string FileName { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public long SizeInBytes { get; set; }

    /// <summary>Short-lived read URL, regenerated on each response.</summary>
    public string Url { get; set; } = string.Empty;

    public DateOnly? ExpiryDate { get; set; }

    public DateTimeOffset UploadedAt { get; set; }

    public string? UploadedByName { get; set; }
}

/// <summary>Metadata accompanying a document upload. The file itself is a multipart part.</summary>
public sealed class UploadDocumentRequest
{
    [Required]
    public EmployeeDocumentType Type { get; set; } = EmployeeDocumentType.Other;

    /// <summary>Optional expiry, for documents that lapse.</summary>
    public DateOnly? ExpiryDate { get; set; }
}
