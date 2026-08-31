namespace IBS.Infrastructure.Storage;

/// <summary>Azure Storage settings, bound from the <c>Storage</c> section.</summary>
public sealed class StorageOptions
{
    public const string SectionName = "Storage";

    /// <summary>
    /// Storage account connection string. Required in every environment - there is no
    /// local-disk fallback, and startup fails when this is missing (see
    /// InfrastructureRegistration). Comes from appsettings.Local.json on a developer machine
    /// and from the Storage__ConnectionString app setting in Azure.
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>True when a Blob client can be constructed.</summary>
    public bool IsConfigured => !string.IsNullOrWhiteSpace(ConnectionString);
}
