using IBS.Modules.UsersAccess.Domain.Enums;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// A single-use, time-limited token backing invite and password-reset links (spec section 4.5).
/// Only a hash of the token is stored, on the same principle as a password: a database leak
/// must not hand out working links. Issuing a new token for the same employee and purpose
/// invalidates any prior unused one.
/// </summary>
public class ActivationToken
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    /// <summary>SHA-256 hash of the raw token. The raw value exists only in the emailed link.</summary>
    public string TokenHash { get; set; } = string.Empty;

    public ActivationTokenPurpose Purpose { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }

    /// <summary>Set the moment the token is redeemed. Non-null means spent.</summary>
    public DateTimeOffset? UsedAt { get; set; }

    /// <summary>Set when superseded by a newer token for the same employee and purpose.</summary>
    public DateTimeOffset? InvalidatedAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>Who triggered the issue. Null for self-service forgot-password.</summary>
    public Guid? CreatedByEmployeeId { get; set; }

    /// <summary>True when the token can still be redeemed at <paramref name="now"/>.</summary>
    public bool IsRedeemable(DateTimeOffset now) =>
        UsedAt is null && InvalidatedAt is null && ExpiresAt > now;
}
