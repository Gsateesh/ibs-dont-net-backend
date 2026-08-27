namespace IBS.Modules.UsersAccess.Application.Abstractions;

/// <summary>
/// Password hashing. The API and the IBS.SeedSuperAdmin console tool resolve the same
/// implementation, so a hash produced by the seed tool verifies at login (spec section 6.1).
/// </summary>
public interface IPasswordHasher
{
    /// <summary>Hashes a plaintext password for storage.</summary>
    string Hash(string password);

    /// <summary>Verifies a plaintext password against a stored hash.</summary>
    PasswordVerificationOutcome Verify(string hash, string password);
}

/// <summary>Result of verifying a password against a stored hash.</summary>
public enum PasswordVerificationOutcome
{
    /// <summary>Wrong password.</summary>
    Failed = 0,

    /// <summary>Correct password.</summary>
    Success = 1,

    /// <summary>Correct password, but the hash uses outdated parameters and should be rewritten.</summary>
    SuccessRehashNeeded = 2
}
