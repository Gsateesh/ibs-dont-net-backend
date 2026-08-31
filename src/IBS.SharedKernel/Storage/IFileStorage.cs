namespace IBS.SharedKernel.Storage;

/// <summary>
/// Blob storage for photos, documents and drawings (spec section 1). Implemented in
/// IBS.Infrastructure over an Azure Storage account; a local-disk implementation backs
/// development. Lives in the shared kernel because more than one module stores files.
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

    /// <summary>
    /// Opens a stored file for reading, so an API endpoint can stream the bytes back itself
    /// rather than handing out a URL. This is the only way to serve a private upload behind
    /// the API's own permission checks - a local-disk reference is not a servable URL at all,
    /// and a blob URL would bypass them.
    /// </summary>
    /// <returns>The content stream, or null when the file no longer exists.</returns>
    Task<Stream?> OpenReadAsync(string blobUrl, CancellationToken ct = default);
}
