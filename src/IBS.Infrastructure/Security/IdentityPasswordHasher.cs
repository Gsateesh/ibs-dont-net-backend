using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IBS.Infrastructure.Security;

/// <summary>
/// Password hashing over the ASP.NET Core Identity hasher (PBKDF2, per-password salt,
/// versioned format). Both the API and the seed tool resolve this same implementation,
/// which is what lets a hash produced by IBS.SeedSuperAdmin verify at login (spec section 6.1).
/// </summary>
public sealed class IdentityPasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<Employee> _inner = new();

    // The hasher takes a user object only to support custom implementations; the default
    // ignores it, so one throwaway instance is enough.
    private static readonly Employee Placeholder = new();

    public string Hash(string password) => _inner.HashPassword(Placeholder, password);

    public PasswordVerificationOutcome Verify(string hash, string password) =>
        _inner.VerifyHashedPassword(Placeholder, hash, password) switch
        {
            PasswordVerificationResult.Success => PasswordVerificationOutcome.Success,
            PasswordVerificationResult.SuccessRehashNeeded => PasswordVerificationOutcome.SuccessRehashNeeded,
            _ => PasswordVerificationOutcome.Failed
        };
}
