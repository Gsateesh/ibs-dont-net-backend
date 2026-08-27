namespace IBS.Modules.UsersAccess.Application.Abstractions;

/// <summary>
/// Generates and hashes activation tokens. The raw token goes into the emailed link and is
/// never persisted; only <see cref="Hash"/> of it is stored (spec section 4.5).
/// </summary>
public interface ITokenGenerator
{
    /// <summary>Creates a cryptographically random, URL-safe token.</summary>
    string CreateRawToken();

    /// <summary>Hashes a raw token for storage and lookup.</summary>
    string Hash(string rawToken);
}
