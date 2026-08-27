namespace IBS.Infrastructure;

/// <summary>
/// The one user-secrets store shared by the API, the EF design-time factory and the seed tool.
/// <para>
/// Local connection strings and keys go here rather than into appsettings, so nothing secret
/// is ever committed. In Azure the same values come from Key Vault instead (spec section 1).
/// </para>
/// <example>
/// <code>
/// dotnet user-secrets --project src/IBS.Api set "ConnectionStrings:IbsDatabase" "&lt;connection string&gt;"
/// </code>
/// </example>
/// </summary>
public static class IbsSecrets
{
    /// <summary>
    /// Matches the UserSecretsId in IBS.Api, IBS.Infrastructure and IBS.SeedSuperAdmin,
    /// which is what makes all three read the same store.
    /// </summary>
    public const string UserSecretsId = "ibs-backend-service";
}
