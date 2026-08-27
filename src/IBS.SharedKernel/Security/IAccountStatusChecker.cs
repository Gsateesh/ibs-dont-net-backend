namespace IBS.SharedKernel.Security;

/// <summary>
/// Answers one narrow question - "does this account still exist and get to sign in at
/// all" - kept separate from <see cref="IPermissionChecker"/>, which is specifically about
/// the permission model (spec section 5). Whether an account is still <c>Active</c> is a
/// different, earlier question than what it's allowed to do.
/// <para>
/// This exists to close a real gap: a JWT (or, previously, a cookie) issued before an
/// account was suspended stays cryptographically valid until it expires. Without a live
/// check, an already-signed-in suspended employee could keep working until their token's
/// natural expiry. The API layer calls this on every authenticated request so a status
/// change takes effect within one token lifetime, not "whenever they next log in."
/// </para>
/// </summary>
public interface IAccountStatusChecker
{
    /// <summary>True when the employee exists and their <c>Status</c> is <c>Active</c>.</summary>
    Task<bool> IsActiveAsync(Guid employeeId, CancellationToken ct = default);
}
