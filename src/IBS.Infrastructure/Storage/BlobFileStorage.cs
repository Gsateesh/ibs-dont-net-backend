using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using IBS.Modules.UsersAccess.Application.Abstractions;
using Microsoft.Extensions.Options;

namespace IBS.Infrastructure.Storage;

/// <summary>
/// Employee photos and documents in Azure Blob Storage (spec section 1). Containers are
/// private; reads go through a short-lived SAS URL minted per response.
/// </summary>
public sealed class BlobFileStorage(IOptions<StorageOptions> options) : IFileStorage
{
    private readonly BlobServiceClient _client = new(options.Value.ConnectionString);

    public async Task<string> UploadAsync(
        string container, string fileName, Stream content, string? contentType, CancellationToken ct = default)
    {
        var containerClient = _client.GetBlobContainerClient(container);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.None, cancellationToken: ct);

        var blob = containerClient.GetBlobClient(fileName);

        await blob.UploadAsync(
            content,
            new BlobUploadOptions { HttpHeaders = new BlobHttpHeaders { ContentType = contentType } },
            ct);

        return blob.Uri.ToString();
    }

    public async Task DeleteAsync(string blobUrl, CancellationToken ct = default)
    {
        var blob = new BlobClient(new Uri(blobUrl));
        var containerClient = _client.GetBlobContainerClient(blob.BlobContainerName);
        await containerClient.GetBlobClient(blob.Name).DeleteIfExistsAsync(cancellationToken: ct);
    }

    public Task<string> GetReadUrlAsync(string blobUrl, TimeSpan validFor, CancellationToken ct = default)
    {
        var reference = new BlobClient(new Uri(blobUrl));
        var blob = _client.GetBlobContainerClient(reference.BlobContainerName).GetBlobClient(reference.Name);

        if (!blob.CanGenerateSasUri)
        {
            // Managed identity rather than a shared key: hand back the plain URI and let
            // storage-level authorization decide.
            return Task.FromResult(blobUrl);
        }

        var builder = new BlobSasBuilder
        {
            BlobContainerName = reference.BlobContainerName,
            BlobName = reference.Name,
            Resource = "b",
            ExpiresOn = DateTimeOffset.UtcNow.Add(validFor)
        };

        builder.SetPermissions(BlobSasPermissions.Read);

        _ = ct;
        return Task.FromResult(blob.GenerateSasUri(builder).ToString());
    }
}
