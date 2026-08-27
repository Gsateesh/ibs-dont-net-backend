using System.Security.Cryptography;
using System.Text;
using IBS.Modules.UsersAccess.Application.Abstractions;

namespace IBS.Infrastructure.Security;

/// <summary>
/// Creates 256 bits of randomness per token and stores only its SHA-256 hash, so a leaked
/// database yields no working invite or reset links (spec section 4.5).
/// </summary>
public sealed class ActivationTokenGenerator : ITokenGenerator
{
    public string CreateRawToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        // URL-safe base64: these values travel in a query string.
        return Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    public string Hash(string rawToken)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawToken));
        return Convert.ToHexString(bytes);
    }
}
