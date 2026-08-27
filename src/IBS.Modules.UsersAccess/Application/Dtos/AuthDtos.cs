using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IBS.Modules.UsersAccess.Domain.Enums;

namespace IBS.Modules.UsersAccess.Application.Dtos;

/// <summary>Credentials submitted to the sign-in endpoint.</summary>
public sealed class LoginRequest
{
    /// <summary>Work email, the only login identifier.</summary>
    /// <example>asha.nair@ibs.example.com</example>
    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    /// <summary>Plaintext password, over TLS only.</summary>
    /// <example>correct-horse-battery-staple</example>
    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}

/// <summary>Outcome of a sign-in attempt.</summary>
public sealed class LoginResponse
{
    /// <summary>Signed-in employee, including the permissions the frontend uses to build the menu.</summary>
    public CurrentUserResponse User { get; set; } = new();

    /// <summary>True when the password must be changed before anything else is allowed.</summary>
    public bool MustChangePassword { get; set; }

    /// <summary>
    /// Where the frontend should land: <c>/team</c> when the user holds manage_users,
    /// otherwise <c>/me</c> (spec section 6.5).
    /// </summary>
    /// <example>/team</example>
    public string LandingRoute { get; set; } = "/me";

    /// <summary>
    /// The bearer token. Store it (sessionStorage) and send it back as
    /// <c>Authorization: Bearer &lt;token&gt;</c> on every request - there is no cookie
    /// carrying this for you.
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// When <see cref="AccessToken"/> stops working. There is no refresh token - past this
    /// point the only way back in is signing in again.
    /// </summary>
    public DateTimeOffset ExpiresAt { get; set; }
}

/// <summary>The signed-in employee as the frontend needs them.</summary>
public sealed class CurrentUserResponse
{
    public Guid Id { get; set; }

    /// <example>Asha Nair</example>
    public string FullName { get; set; } = string.Empty;

    /// <example>asha.nair@ibs.example.com</example>
    public string Email { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }

    /// <example>Design Head</example>
    public string? Designation { get; set; }

    /// <example>Design</example>
    public string? Department { get; set; }

    /// <example>Bengaluru</example>
    public string? Branch { get; set; }

    public EmployeeStatus Status { get; set; }

    /// <summary>True when every permission check short-circuits to allowed (spec section 5.2).</summary>
    public bool IsSuperAdmin { get; set; }

    /// <summary>Effective permission codes. A Super Admin resolves to the full catalogue.</summary>
    public IReadOnlyList<string> Permissions { get; set; } = [];
}

/// <summary>Self-service password reset request.</summary>
public sealed class ForgotPasswordRequest
{
    /// <example>asha.nair@ibs.example.com</example>
    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; } = string.Empty;
}

/// <summary>
/// Context returned when an activation or reset link is opened, so the confirmation screen
/// can greet the person by name before they choose a password.
/// </summary>
public sealed class ActivationTokenContextResponse
{
    /// <example>Asha</example>
    public string FirstName { get; set; } = string.Empty;

    /// <example>Nair</example>
    public string LastName { get; set; } = string.Empty;

    /// <example>asha.nair@ibs.example.com</example>
    public string Email { get; set; } = string.Empty;

    /// <summary>Whether this link sets a first password or replaces an existing one.</summary>
    public ActivationTokenPurpose Purpose { get; set; }

    /// <summary>When the link stops working.</summary>
    public DateTimeOffset ExpiresAt { get; set; }
}

/// <summary>The password chosen by the employee when redeeming an activation or reset link.</summary>
public sealed class CompleteActivationRequest
{
    /// <summary>New password. Length is validated against the configured minimum.</summary>
    [Required, DataType(DataType.Password), MinLength(10), MaxLength(256)]
    public string NewPassword { get; set; } = string.Empty;

    /// <summary>Must match <see cref="NewPassword"/>.</summary>
    [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
    public string ConfirmPassword { get; set; } = string.Empty;
}

/// <summary>Self-service password change for a signed-in employee.</summary>
public sealed class ChangePasswordRequest
{
    [Required, DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = string.Empty;

    [Required, DataType(DataType.Password), MinLength(10), MaxLength(256)]
    public string NewPassword { get; set; } = string.Empty;

    [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
    public string ConfirmPassword { get; set; } = string.Empty;
}

/// <summary>A deliberately non-committal acknowledgement.</summary>
public sealed class MessageResponse
{
    public MessageResponse() { }

    public MessageResponse(string message) => Message = message;

    /// <example>If that email matches an account, a reset link is on its way.</example>
    [DefaultValue("Done.")]
    public string Message { get; set; } = "Done.";
}

/// <summary>
/// An activation or reset link handed back to the caller.
/// <para>
/// The link carries a working credential, so it is only ever populated while outbound email
/// is unconfigured - without it there would be no way to onboard anyone. As soon as a real
/// mail sender is wired up, <see cref="Link"/> comes back null and the link goes to the
/// person it belongs to instead.
/// </para>
/// </summary>
public sealed class InvitationLinkResponse
{
    /// <summary>Who the link is for.</summary>
    /// <example>priya.raman@example.com</example>
    public string Email { get; set; } = string.Empty;

    /// <summary>Whether it sets a first password or replaces an existing one.</summary>
    public ActivationTokenPurpose Purpose { get; set; }

    /// <summary>True when the link was emailed and is therefore not repeated here.</summary>
    public bool DeliveredByEmail { get; set; }

    /// <summary>
    /// The full link to pass on by hand. Null whenever <see cref="DeliveredByEmail"/> is true.
    /// </summary>
    public string? Link { get; set; }

    /// <summary>When the link stops working.</summary>
    public DateTimeOffset ExpiresAt { get; set; }
}
