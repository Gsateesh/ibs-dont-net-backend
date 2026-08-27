namespace IBS.Modules.UsersAccess.Application.Abstractions;

/// <summary>
/// Blob storage for photos and documents (spec section 1). Implemented in IBS.Infrastructure
/// over an Azure Storage account; a local-disk implementation backs development.
/// </summary>
public interface IFileStorage
{
    /// <summary>Uploads a file and returns the stored reference (a blob URL or path).</summary>
    Task<string> UploadAsync(
        string container,
        string fileName,
        Stream content,
        string? contentType,
        CancellationToken ct = default);

    /// <summary>Deletes a previously uploaded file. Missing blobs are not an error.</summary>
    Task DeleteAsync(string blobUrl, CancellationToken ct = default);

    /// <summary>Returns a short-lived read URL for a stored blob.</summary>
    Task<string> GetReadUrlAsync(string blobUrl, TimeSpan validFor, CancellationToken ct = default);
}
