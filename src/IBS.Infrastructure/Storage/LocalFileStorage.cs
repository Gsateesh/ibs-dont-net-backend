using IBS.Modules.UsersAccess.Application.Abstractions;
using Microsoft.Extensions.Options;

namespace IBS.Infrastructure.Storage;

/// <summary>
/// Development stand-in for <see cref="BlobFileStorage"/>: writes under a local folder so
/// uploads work with no storage account. Registered only when no connection string is present.
/// </summary>
public sealed class LocalFileStorage(IOptions<StorageOptions> options) : IFileStorage
{
    private readonly StorageOptions _options = options.Value;

    public async Task<string> UploadAsync(
        string container, string fileName, Stream content, string? contentType, CancellationToken ct = default)
    {
        var relative = Path.Combine(container, fileName).Replace(Path.DirectorySeparatorChar, '/');
        var fullPath = Path.Combine(_options.LocalRoot, relative);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

        await using var file = File.Create(fullPath);
        await content.CopyToAsync(file, ct);

        _ = contentType;
        return $"{_options.LocalBaseUrl.TrimEnd('/')}/{relative}";
    }

    public Task DeleteAsync(string blobUrl, CancellationToken ct = default)
    {
        var relative = blobUrl.Replace(_options.LocalBaseUrl, string.Empty).TrimStart('/');
        var fullPath = Path.Combine(_options.LocalRoot, relative);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        _ = ct;
        return Task.CompletedTask;
    }

    public Task<string> GetReadUrlAsync(string blobUrl, TimeSpan validFor, CancellationToken ct = default)
    {
        _ = validFor;
        _ = ct;
        return Task.FromResult(blobUrl);
    }
}
