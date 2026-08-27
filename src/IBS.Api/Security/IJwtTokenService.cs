using System.Security.Claims;

namespace IBS.Api.Security;

/// <summary>Issues the access tokens <see cref="Controllers.AuthController"/> hands back on login.</summary>
public interface IJwtTokenService
{
    /// <summary>Builds a signed access token carrying the given claims.</summary>
    JwtTokenResult CreateAccessToken(IEnumerable<Claim> claims);
}

/// <summary>A freshly issued access token and when it stops being valid.</summary>
public sealed record JwtTokenResult(string AccessToken, DateTimeOffset ExpiresAt);
