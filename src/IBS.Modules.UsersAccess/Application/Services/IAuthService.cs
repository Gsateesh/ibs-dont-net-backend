using IBS.Modules.UsersAccess.Application.Dtos;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>Sign-in, activation and password flows (spec section 6).</summary>
public interface IAuthService
{
    /// <summary>
    /// Verifies credentials and returns the session payload. Throws
    /// <see cref="SharedKernel.Exceptions.BusinessRuleException"/> with a deliberately
    /// generic message when the pair does not match.
    /// </summary>
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken ct = default);

    /// <summary>Records a sign-out in the audit log. Cookie removal is the responsibility of the API layer.</summary>
    Task LogoutAsync(Guid employeeId, CancellationToken ct = default);

    /// <summary>
    /// Issues a reset token when the email matches an account. Always completes quietly,
    /// so the response cannot be used to test whether an address exists (spec section 6.4).
    /// </summary>
    Task ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken ct = default);

    /// <summary>Validates an invite or reset link and returns the greeting context.</summary>
    Task<ActivationTokenContextResponse> GetActivationContextAsync(string rawToken, CancellationToken ct = default);

    /// <summary>
    /// Sets the password chosen by the employee, marks the token used and, for an invite,
    /// flips the account to Active (spec section 6.2).
    /// </summary>
    Task CompleteActivationAsync(string rawToken, CompleteActivationRequest request, CancellationToken ct = default);

    /// <summary>Changes the password of the signed-in employee after verifying the current one.</summary>
    Task ChangeOwnPasswordAsync(Guid employeeId, ChangePasswordRequest request, CancellationToken ct = default);

    /// <summary>Builds the session payload for an already-authenticated employee.</summary>
    Task<CurrentUserResponse> GetCurrentUserAsync(Guid employeeId, CancellationToken ct = default);

    /// <summary>Stamps LastSeenAt for the signed-in employee.</summary>
    Task TouchLastSeenAsync(Guid employeeId, CancellationToken ct = default);
}
