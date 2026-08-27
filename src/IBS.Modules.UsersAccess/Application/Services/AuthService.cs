using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Options;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <inheritdoc cref="IAuthService" />
public sealed class AuthService(
    IUsersAccessDbContext db,
    IPasswordHasher passwordHasher,
    ITokenGenerator tokenGenerator,
    IEmailSender emailSender,
    IPermissionChecker permissions,
    IAuditLogWriter audit,
    IClock clock,
    IOptions<UsersAccessOptions> options,
    ILogger<AuthService> logger) : IAuthService
{
    private readonly UsersAccessOptions _options = options.Value;

    /// <summary>
    /// Deliberately identical for a wrong email and a wrong password, so the endpoint
    /// cannot be used to enumerate accounts (spec section 6.5).
    /// </summary>
    private const string GenericLoginFailure = "Email or password is incorrect.";

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var now = clock.UtcNow;
        var email = request.Email.Trim().ToLowerInvariant();

        var employee = await db.Employees
            .Include(e => e.Department)
            .Include(e => e.Designation)
            .Include(e => e.Branch)
            .FirstOrDefaultAsync(e => e.Email == email, ct);

        if (employee is null)
        {
            // Still hash something so a missing account is not detectably faster than a wrong password.
            passwordHasher.Hash(request.Password);
            throw new BusinessRuleException(GenericLoginFailure, "invalid_credentials");
        }

        if (employee.IsLockedOut(now))
        {
            throw new BusinessRuleException(
                "Too many failed attempts. Try again in a few minutes or contact your administrator.",
                "account_locked");
        }

        switch (employee.Status)
        {
            case EmployeeStatus.Suspended:
                throw new BusinessRuleException(
                    "This account has been suspended, contact your administrator.", "account_suspended");
            case EmployeeStatus.Invited:
                throw new BusinessRuleException(
                    "Finish setting up your account using the invite link we emailed you.", "account_invited");
            case EmployeeStatus.Inactive:
            case EmployeeStatus.Exited:
                throw new BusinessRuleException(
                    "This account is no longer active, contact your administrator.", "account_inactive");
        }

        if (string.IsNullOrEmpty(employee.PasswordHash))
        {
            throw new BusinessRuleException(
                "Finish setting up your account using the invite link we emailed you.", "account_invited");
        }

        var outcome = passwordHasher.Verify(employee.PasswordHash, request.Password);
        if (outcome == PasswordVerificationOutcome.Failed)
        {
            await RegisterFailedAttemptAsync(employee, now, ct);
            throw new BusinessRuleException(GenericLoginFailure, "invalid_credentials");
        }

        if (outcome == PasswordVerificationOutcome.SuccessRehashNeeded)
        {
            employee.PasswordHash = passwordHasher.Hash(request.Password);
        }

        employee.FailedLoginAttempts = 0;
        employee.FirstFailedLoginAt = null;
        employee.LockoutEndsAt = null;
        employee.LastSeenAt = now;

        await audit.WriteAsync(AuditActions.LoginSucceeded, nameof(Employee), employee.Id, employee.Id, null, ct);
        await db.SaveChangesAsync(ct);

        var user = await BuildCurrentUserAsync(employee, ct);

        return new LoginResponse
        {
            User = user,
            MustChangePassword = employee.MustChangePassword,
            // Land on the team list for anyone who can manage users, otherwise their own profile.
            LandingRoute = user.Permissions.Contains(PermissionCodes.ManageUsers) ? "/team" : "/me"
        };
    }

    private async Task RegisterFailedAttemptAsync(Employee employee, DateTimeOffset now, CancellationToken ct)
    {
        // Attempts are counted within a rolling window; an old, stale streak starts over.
        if (employee.FirstFailedLoginAt is null || now - employee.FirstFailedLoginAt > _options.FailedLoginWindow)
        {
            employee.FirstFailedLoginAt = now;
            employee.FailedLoginAttempts = 0;
        }

        employee.FailedLoginAttempts++;

        if (employee.FailedLoginAttempts >= _options.MaxFailedLoginAttempts)
        {
            employee.LockoutEndsAt = now.Add(_options.LockoutDuration);
            employee.FailedLoginAttempts = 0;
            employee.FirstFailedLoginAt = null;

            await audit.WriteAsync(
                AuditActions.AccountLocked, nameof(Employee), employee.Id, null,
                new { lockedUntil = employee.LockoutEndsAt }, ct);
        }
        else
        {
            await audit.WriteAsync(
                AuditActions.LoginFailed, nameof(Employee), employee.Id, null,
                new { attempts = employee.FailedLoginAttempts }, ct);
        }

        await db.SaveChangesAsync(ct);
    }

    public async Task LogoutAsync(Guid employeeId, CancellationToken ct = default)
    {
        await audit.WriteAsync(AuditActions.Logout, nameof(Employee), employeeId, employeeId, null, ct);
        await db.SaveChangesAsync(ct);
    }

    public async Task ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken ct = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var employee = await db.Employees.FirstOrDefaultAsync(e => e.Email == email, ct);

        // No such account, or an account that cannot sign in anyway: return quietly either way.
        if (employee is null || employee.Status is EmployeeStatus.Inactive or EmployeeStatus.Exited)
        {
            logger.LogInformation("Password reset requested for an address with no eligible account.");
            return;
        }

        var purpose = employee.Status == EmployeeStatus.Invited
            ? ActivationTokenPurpose.Invite
            : ActivationTokenPurpose.Reset;

        var (raw, link) = await IssueTokenAsync(employee, purpose, actorEmployeeId: null, ct);

        if (purpose == ActivationTokenPurpose.Invite)
        {
            await emailSender.SendInviteAsync(employee.Email, employee.FirstName, link, ct);
        }
        else
        {
            await emailSender.SendPasswordResetAsync(employee.Email, employee.FirstName, link, ct);
        }

        await audit.WriteAsync(
            AuditActions.PasswordResetRequested, nameof(Employee), employee.Id, null,
            new { selfService = true, purpose = purpose.ToString() }, ct);

        await db.SaveChangesAsync(ct);
        logger.LogInformation("Issued a {Purpose} link for employee {EmployeeId}.", purpose, employee.Id);
        _ = raw;
    }

    /// <summary>
    /// Creates a token, invalidating any earlier unused one for the same employee and purpose,
    /// and returns both the raw value and the link that carries it (spec section 4.5).
    /// </summary>
    internal async Task<(string RawToken, string Link)> IssueTokenAsync(
        Employee employee, ActivationTokenPurpose purpose, Guid? actorEmployeeId, CancellationToken ct)
    {
        var now = clock.UtcNow;

        var superseded = await db.ActivationTokens
            .Where(t => t.EmployeeId == employee.Id
                        && t.Purpose == purpose
                        && t.UsedAt == null
                        && t.InvalidatedAt == null)
            .ToListAsync(ct);

        foreach (var token in superseded)
        {
            token.InvalidatedAt = now;
        }

        var raw = tokenGenerator.CreateRawToken();
        var lifetime = purpose == ActivationTokenPurpose.Invite
            ? _options.InviteTokenLifetime
            : _options.ResetTokenLifetime;

        db.ActivationTokens.Add(new ActivationToken
        {
            EmployeeId = employee.Id,
            TokenHash = tokenGenerator.Hash(raw),
            Purpose = purpose,
            ExpiresAt = now.Add(lifetime),
            CreatedAt = now,
            CreatedByEmployeeId = actorEmployeeId
        });

        var path = purpose == ActivationTokenPurpose.Invite
            ? _options.ActivationPath
            : _options.PasswordResetPath;

        var link = $"{_options.AppBaseUrl.TrimEnd('/')}{path}?token={Uri.EscapeDataString(raw)}";
        return (raw, link);
    }

    public async Task<ActivationTokenContextResponse> GetActivationContextAsync(string rawToken, CancellationToken ct = default)
    {
        var token = await FindRedeemableTokenAsync(rawToken, ct);

        return new ActivationTokenContextResponse
        {
            FirstName = token.Employee!.FirstName,
            LastName = token.Employee.LastName,
            Email = token.Employee.Email,
            Purpose = token.Purpose,
            ExpiresAt = token.ExpiresAt
        };
    }

    public async Task CompleteActivationAsync(string rawToken, CompleteActivationRequest request, CancellationToken ct = default)
    {
        ValidatePasswordLength(request.NewPassword);

        var now = clock.UtcNow;
        var token = await FindRedeemableTokenAsync(rawToken, ct);
        var employee = token.Employee!;

        employee.PasswordHash = passwordHasher.Hash(request.NewPassword);
        employee.MustChangePassword = false;
        employee.FailedLoginAttempts = 0;
        employee.FirstFailedLoginAt = null;
        employee.LockoutEndsAt = null;

        // An invite is what turns an Invited row into a usable account (spec section 6.2).
        // A reset on a suspended or inactive account must not quietly reactivate it.
        if (employee.Status == EmployeeStatus.Invited)
        {
            employee.Status = EmployeeStatus.Active;
        }

        token.UsedAt = now;

        await audit.WriteAsync(
            token.Purpose == ActivationTokenPurpose.Invite
                ? AuditActions.InviteCompleted
                : AuditActions.PasswordResetCompleted,
            nameof(Employee), employee.Id, employee.Id, null, ct);

        await db.SaveChangesAsync(ct);
    }

    public async Task ChangeOwnPasswordAsync(Guid employeeId, ChangePasswordRequest request, CancellationToken ct = default)
    {
        ValidatePasswordLength(request.NewPassword);

        var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == employeeId, ct)
                       ?? throw new NotFoundException("Employee", employeeId);

        if (string.IsNullOrEmpty(employee.PasswordHash) ||
            passwordHasher.Verify(employee.PasswordHash, request.CurrentPassword) == PasswordVerificationOutcome.Failed)
        {
            throw new BusinessRuleException("Your current password is incorrect.", "invalid_current_password");
        }

        employee.PasswordHash = passwordHasher.Hash(request.NewPassword);
        employee.MustChangePassword = false;

        await audit.WriteAsync(AuditActions.PasswordChanged, nameof(Employee), employee.Id, employee.Id, null, ct);
        await db.SaveChangesAsync(ct);
    }

    public async Task<CurrentUserResponse> GetCurrentUserAsync(Guid employeeId, CancellationToken ct = default)
    {
        var employee = await db.Employees
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Designation)
            .Include(e => e.Branch)
            .FirstOrDefaultAsync(e => e.Id == employeeId, ct)
            ?? throw new NotFoundException("Employee", employeeId);

        return await BuildCurrentUserAsync(employee, ct);
    }

    public async Task TouchLastSeenAsync(Guid employeeId, CancellationToken ct = default)
    {
        await db.Employees
            .Where(e => e.Id == employeeId)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.LastSeenAt, clock.UtcNow), ct);
    }

    private async Task<CurrentUserResponse> BuildCurrentUserAsync(Employee employee, CancellationToken ct)
    {
        var held = await permissions.GetEffectivePermissionsAsync(employee.Id, ct);

        return new CurrentUserResponse
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Email = employee.Email,
            PhotoUrl = employee.PhotoUrl,
            Designation = employee.Designation?.Name,
            Department = employee.Department?.Name,
            Branch = employee.Branch?.Name,
            Status = employee.Status,
            IsSuperAdmin = employee.IsSuperAdmin,
            Permissions = held.OrderBy(c => c, StringComparer.Ordinal).ToList()
        };
    }

    private async Task<ActivationToken> FindRedeemableTokenAsync(string rawToken, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(rawToken))
        {
            throw new BusinessRuleException("This link is not valid.", "invalid_token");
        }

        var hash = tokenGenerator.Hash(rawToken);

        var token = await db.ActivationTokens
            .Include(t => t.Employee)
            .FirstOrDefaultAsync(t => t.TokenHash == hash, ct);

        if (token?.Employee is null || !token.IsRedeemable(clock.UtcNow))
        {
            // One message for missing, spent, superseded and expired alike.
            throw new BusinessRuleException(
                "This link is no longer valid. Ask an administrator to send a new one.", "invalid_token");
        }

        return token;
    }

    private void ValidatePasswordLength(string password)
    {
        if (password.Length < _options.MinimumPasswordLength)
        {
            throw new BusinessRuleException(
                $"Password must be at least {_options.MinimumPasswordLength} characters.", "password_too_short");
        }
    }
}
