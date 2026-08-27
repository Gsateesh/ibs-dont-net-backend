using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IBS.Api.Security;

/// <inheritdoc cref="IJwtTokenService" />
public sealed class JwtTokenService(IOptions<JwtOptions> options) : IJwtTokenService
{
    private readonly JwtOptions _options = options.Value;
    private static readonly JwtSecurityTokenHandler Handler = new();

    public JwtTokenResult CreateAccessToken(IEnumerable<Claim> claims)
    {
        var now = DateTimeOffset.UtcNow;
        var expiresAt = now.Add(_options.AccessTokenLifetime);

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now.UtcDateTime,
            expires: expiresAt.UtcDateTime,
            signingCredentials: credentials);

        return new JwtTokenResult(Handler.WriteToken(token), expiresAt);
    }
}
