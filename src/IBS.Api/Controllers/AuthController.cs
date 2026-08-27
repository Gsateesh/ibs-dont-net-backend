using System.Security.Claims;
using IBS.Api.Security;
using IBS.Api.Swagger;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Services;
using IBS.SharedKernel.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Controllers;

/// <summary>
/// Sign-in, sign-out, and the invite and password-reset links (spec sections 6 and 7).
/// </summary>
[ApiController]
[Route("api/auth")]
[Produces("application/json")]
[Tags("Auth")]
public sealed class AuthController(IAuthService auth, ICurrentUser currentUser, IJwtTokenService tokens) : ControllerBase
{
    /// <summary>Signs in with email and password.</summary>
    /// <remarks>
    /// On success the response carries a bearer access token, valid for 30 minutes, and says
    /// where to land: the team list for anyone holding manage_users, otherwise their own profile.
    /// Store the token yourself (sessionStorage) and send it back as
    /// <c>Authorization: Bearer &lt;token&gt;</c> - there is no cookie to carry it for you.
    ///
    /// A wrong email and a wrong password produce the same message on purpose. Suspended and
    /// not-yet-activated accounts are told apart, because that is actionable rather than
    /// account-enumerating. Five failures inside the window locks the account for fifteen minutes.
    /// </remarks>
    /// <response code="200">Signed in; the response carries the access token.</response>
    /// <response code="400">Credentials rejected, or the account cannot sign in right now.</response>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken ct)
    {
        var result = await auth.LoginAsync(request, ct);

        var claims = new List<Claim>
        {
            new(CurrentUser.EmployeeIdClaim, result.User.Id.ToString()),
            new(CurrentUser.SuperAdminClaim, result.User.IsSuperAdmin.ToString()),
            new(ClaimTypes.Email, result.User.Email),
            new(ClaimTypes.Name, result.User.FullName)
        };

        var token = tokens.CreateAccessToken(claims);
        result.AccessToken = token.AccessToken;
        result.ExpiresAt = token.ExpiresAt;

        return Ok(result);
    }

    /// <summary>Records a sign-out and tells the caller to discard their token.</summary>
    /// <remarks>
    /// A bearer token is stateless - there is nothing server-side to revoke, so this does not
    /// invalidate the token itself. A token used after "logout" remains valid until its natural
    /// expiry, same as it would if the tab were simply closed without calling this. What this
    /// endpoint actually does: writes the audit-log entry that someone deliberately signed out,
    /// and gives the frontend a clean 204 to react to by clearing its stored token.
    /// </remarks>
    /// <response code="204">Recorded. Discard your stored token now.</response>
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Logout(CancellationToken ct)
    {
        if (currentUser.EmployeeId is { } employeeId)
        {
            await auth.LogoutAsync(employeeId, ct);
        }

        return NoContent();
    }

    /// <summary>The signed-in employee, including their effective permissions.</summary>
    /// <remarks>Called on app start to decide which navigation the frontend should build.</remarks>
    /// <response code="200">The current session.</response>
    [HttpGet("me")]
    [ProducesResponseType<CurrentUserResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurrentUserResponse>> Me(CancellationToken ct) =>
        Ok(await auth.GetCurrentUserAsync(currentUser.RequireEmployeeId(), ct));

    /// <summary>Requests a password-reset link.</summary>
    /// <remarks>
    /// Always answers the same way, whether or not the address matches an account. This
    /// endpoint is deliberately useless for finding out who has an account here.
    /// </remarks>
    /// <response code="200">Acknowledged, regardless of whether an account matched.</response>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [ProducesResponseType<MessageResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<MessageResponse>> ForgotPassword(ForgotPasswordRequest request, CancellationToken ct)
    {
        await auth.ForgotPasswordAsync(request, ct);
        return Ok(new MessageResponse("If that email matches an account, a reset link is on its way."));
    }

    /// <summary>Validates an invite or reset link and returns who it belongs to.</summary>
    /// <remarks>Backs the confirmation screen, which greets the person before they choose a password.</remarks>
    /// <param name="token">The raw token from the emailed link.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="200">The link is valid.</response>
    /// <response code="400">The link is expired, already used, superseded or unknown.</response>
    [HttpGet("activation-tokens/{token}")]
    [AllowAnonymous]
    [ProducesResponseType<ActivationTokenContextResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ActivationTokenContextResponse>> GetActivationContext(
        string token, CancellationToken ct) =>
        Ok(await auth.GetActivationContextAsync(token, ct));

    /// <summary>Sets the password behind an invite or reset link.</summary>
    /// <remarks>
    /// For an invite this is the moment the account becomes usable: the password is stored,
    /// the token is spent and the status flips to Active. It is also the only point at which a
    /// regular employee password is ever set, and only they ever know it.
    /// </remarks>
    /// <param name="token">The raw token from the emailed link.</param>
    /// <param name="request">The chosen password.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <response code="204">Password set.</response>
    /// <response code="400">The link is no longer valid, or the password is too short.</response>
    [HttpPost("activation-tokens/{token}/complete")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CompleteActivation(
        string token, CompleteActivationRequest request, CancellationToken ct)
    {
        await auth.CompleteActivationAsync(token, request, ct);
        return NoContent();
    }
}
