namespace IBS.Infrastructure.Email;

/// <summary>Azure Communication Services email settings, bound from the <c>Email</c> section.</summary>
public sealed class EmailOptions
{
    public const string SectionName = "Email";

    /// <summary>
    /// ACS connection string. Sourced from Key Vault in Azure and left empty on developer
    /// machines, where the logging sender takes over (spec section 1).
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>Verified sender address on the ACS email domain.</summary>
    public string SenderAddress { get; set; } = "DoNotReply@ibs.example.com";

    /// <summary>Display name on outgoing mail.</summary>
    public string SenderName { get; set; } = "IBS";

    /// <summary>True when a real ACS client should be used.</summary>
    public bool IsConfigured => !string.IsNullOrWhiteSpace(ConnectionString);
}
