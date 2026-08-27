using System.ComponentModel.DataAnnotations;

namespace IBS.Api.Security;

/// <summary>
/// Tunables for JWT bearer authentication, bound from the <c>Jwt</c> configuration section.
/// <para>
/// The signing key is a secret - it lives in <c>appsettings.Local.json</c> locally and in
/// App Service Application Settings in Azure, the same pattern already used for
/// <c>ConnectionStrings:IbsDatabase</c>. Dev and Prod use different keys, the same way they
/// use different SQL logins: a key leaked from one environment must not forge tokens for
/// the other.
/// </para>
/// </summary>
public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    /// <summary>
    /// The HMAC-SHA256 signing secret. Guarded at a minimum length so a blank or weak value
    /// fails fast at startup rather than producing a token anyone could forge.
    /// </summary>
    [Required, MinLength(32)]
    public string SigningKey { get; set; } = string.Empty;

    /// <summary>Issuer claim written into and validated on every token.</summary>
    [Required]
    public string Issuer { get; set; } = string.Empty;

    /// <summary>Audience claim written into and validated on every token.</summary>
    [Required]
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// How long an access token is valid. There is no refresh token (see spec discussion on
    /// why - a refresh token would need an HttpOnly cookie, reintroducing the cross-origin
    /// problem JWT was chosen to avoid for Dev) - so this is the full re-authentication
    /// interval, not just a rolling window.
    /// </summary>
    public TimeSpan AccessTokenLifetime { get; set; } = TimeSpan.FromMinutes(30);
}
