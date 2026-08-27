namespace IBS.Infrastructure.Storage;

/// <summary>Azure Storage settings, bound from the <c>Storage</c> section.</summary>
public sealed class StorageOptions
{
    public const string SectionName = "Storage";

    /// <summary>
    /// Storage account connection string, sourced from Key Vault in Azure. Empty on developer
    /// machines, where files are written to <see cref="LocalRoot"/> instead.
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>Folder used by the local-disk implementation.</summary>
    public string LocalRoot { get; set; } = "App_Data/uploads";

    /// <summary>Base URL the local-disk implementation prefixes to stored paths.</summary>
    public string LocalBaseUrl { get; set; } = "/uploads";

    /// <summary>True when a real Blob client should be used.</summary>
    public bool IsConfigured => !string.IsNullOrWhiteSpace(ConnectionString);
}
