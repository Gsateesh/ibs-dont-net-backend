using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Application.Options;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <inheritdoc cref="IEmployeeService" />
public sealed class EmployeeService(
    IUsersAccessDbContext db,
    IPermissionChecker permissions,
    IPermissionService permissionService,
    IEmailSender emailSender,
    IFileStorage storage,
    IAuditLogWriter audit,
    IClock clock,
    AuthService authService,
    ILogger<EmployeeService> logger,
    IOptions<UsersAccessOptions> options) : IEmployeeService
{
    private readonly UsersAccessOptions _options = options.Value;

    public async Task<PagedResult<EmployeeListItemResponse>> ListAsync(
        EmployeeQuery query, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageUsers, ct);

        var q = db.Employees
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Designation)
            .Include(e => e.Branch)
            .Include(e => e.ReportingManager)
            .AsQueryable();

        if (query.Status is not null)
        {
            q = q.Where(e => e.Status == query.Status);
        }

        if (query.DepartmentId is not null)
        {
            q = q.Where(e => e.DepartmentId == query.DepartmentId);
        }

        if (query.BranchId is not null)
        {
            q = q.Where(e => e.BranchId == query.BranchId);
        }

        if (query.DesignationId is not null)
        {
            q = q.Where(e => e.DesignationId == query.DesignationId);
        }

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var term = query.Search.Trim();
            q = q.Where(e =>
                EF.Functions.Like(e.FirstName, $"%{term}%") ||
                EF.Functions.Like(e.LastName, $"%{term}%") ||
                EF.Functions.Like(e.Email, $"%{term}%") ||
                EF.Functions.Like(e.EmployeeCode, $"%{term}%"));
        }

        var total = await q.CountAsync(ct);

        var items = await q
            .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(e => new EmployeeListItemResponse
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.LastName,
                Email = e.Email,
                EmployeeCode = e.EmployeeCode,
                PhotoUrl = e.PhotoUrl,
                Designation = e.Designation!.Name,
                Department = e.Department!.Name,
                Branch = e.Branch!.Name,
                Status = e.Status,
                IsSuperAdmin = e.IsSuperAdmin,
                ReportingManagerName = e.ReportingManager == null
                    ? null
                    : e.ReportingManager.FirstName + " " + e.ReportingManager.LastName,
                LastSeenAt = e.LastSeenAt
            })
            .ToListAsync(ct);

        return new PagedResult<EmployeeListItemResponse>(items, query.Page, query.PageSize, total);
    }

    public async Task<EmployeeDetailResponse> GetAsync(Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        // Visibility is unrestricted for anyone who can manage users; only mutation is gated
        // by CanManageAccount (spec section 5.3). Self-view is always allowed.
        if (actorId != employeeId)
        {
            await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageUsers, ct);
        }

        var employee = await LoadDetailAsync(employeeId, ct);
        return await MapDetailAsync(employee, actorId, ct);
    }

    public async Task<EmployeeDetailResponse> CreateAsync(
        CreateEmployeeRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageUsers, ct);

        var now = clock.UtcNow;
        var email = request.Email.Trim().ToLowerInvariant();

        if (await db.Employees.AnyAsync(e => e.Email == email, ct))
        {
            throw new ConflictException($"An account already exists for {email}.");
        }

        await RequireLookupsExistAsync(request.DepartmentId, request.DesignationId, request.BranchId, ct);

        if (request.ReportingManagerId is not null &&
            !await db.Employees.AnyAsync(e => e.Id == request.ReportingManagerId, ct))
        {
            throw new NotFoundException("Reporting manager", request.ReportingManagerId);
        }

        var code = string.IsNullOrWhiteSpace(request.EmployeeCode)
            ? await GenerateEmployeeCodeAsync(ct)
            : request.EmployeeCode.Trim();

        if (await db.Employees.AnyAsync(e => e.EmployeeCode == code, ct))
        {
            throw new ConflictException($"Employee code {code} is already in use.");
        }

        var employee = new Employee
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = email,
            Mobile = request.Mobile?.Trim(),
            PhotoUrl = request.PhotoUrl,
            EmployeeCode = code,
            DateOfJoining = request.DateOfJoining,
            EmploymentType = request.EmploymentType,
            DepartmentId = request.DepartmentId,
            DesignationId = request.DesignationId,
            BranchId = request.BranchId,
            ReportingManagerId = request.ReportingManagerId,
            // Invited with no password: only the person themself ever sets it (spec section 6.2).
            Status = EmployeeStatus.Invited,
            PasswordHash = null,
            MustChangePassword = false,
            IsSuperAdmin = false,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        ApplyProfessionalProfile(employee, request.ProfessionalProfile);
        ApplyTargets(employee, request.Targets);

        if (request.Statutory is not null)
        {
            // The statutory record is restricted, so writing one at creation needs the same
            // clearance as reading one (spec section 5.5).
            var mayWriteStatutory = await permissions.HasPermissionAsync(actorId, PermissionCodes.ViewSensitiveData, ct);
            if (!mayWriteStatutory)
            {
                throw new ForbiddenException("Recording statutory details requires the view_sensitive_data permission.");
            }

            employee.Statutory = new EmployeeStatutory
            {
                EmployeeId = employee.Id,
                Pan = request.Statutory.Pan,
                Aadhaar = request.Statutory.Aadhaar,
                PfUan = request.Statutory.PfUan,
                Esic = request.Statutory.Esic,
                BankDetails = request.Statutory.BankDetails,
                Ctc = request.Statutory.Ctc
            };
        }

        // Validated before anything is written, and applying the escalation rule from spec
        // section 5.4. A bad permission code must not be able to leave a half-created person
        // behind - which is exactly what happens if the employee is saved first.
        foreach (var grant in await permissionService.PrepareGrantsAsync(request.PermissionCodes, actorId, ct))
        {
            employee.Permissions.Add(grant);
        }

        db.Employees.Add(employee);

        // The invite token is part of the same unit of work: an employee with no way to
        // activate is not a half-success, it is a failure that happens to have a row.
        var (_, link) = await authService.IssueTokenAsync(employee, ActivationTokenPurpose.Invite, actorId, ct);

        await audit.WriteAsync(
            AuditActions.EmployeeCreated, nameof(Employee), employee.Id, actorId,
            new { employee.Email, employee.EmployeeCode }, ct);
        await audit.WriteAsync(AuditActions.InviteSent, nameof(Employee), employee.Id, actorId, null, ct);

        // One save: person, optional detail, grants, token and audit all commit together or not at all.
        await db.SaveChangesAsync(ct);

        try
        {
            await emailSender.SendInviteAsync(employee.Email, employee.FirstName, link, ct);
        }
        catch (Exception ex)
        {
            // The person and their token are safely stored, so a mail outage must not fail the
            // request - the invite can be sent again from Person Detail.
            logger.LogError(ex,
                "Employee {EmployeeId} was created but the invite email could not be sent. Use resend-invite.",
                employee.Id);
        }

        var detail = await MapDetailAsync(await LoadDetailAsync(employee.Id, ct), actorId, ct);
        detail.Invitation = BuildInvitation(employee, ActivationTokenPurpose.Invite, link);
        return detail;
    }

    public async Task<EmployeeDetailResponse> UpdateAsync(
        Guid employeeId, UpdateEmployeeRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await LoadDetailAsync(employeeId, ct);

        await RequireLookupsExistAsync(request.DepartmentId, request.DesignationId, request.BranchId, ct);

        var code = request.EmployeeCode.Trim();
        if (await db.Employees.AnyAsync(e => e.EmployeeCode == code && e.Id != employeeId, ct))
        {
            throw new ConflictException($"Employee code {code} is already in use.");
        }

        await RequireNoReportingCycleAsync(employeeId, request.ReportingManagerId, ct);

        employee.FirstName = request.FirstName.Trim();
        employee.LastName = request.LastName.Trim();
        employee.Mobile = request.Mobile?.Trim();
        employee.PhotoUrl = request.PhotoUrl;
        employee.EmployeeCode = code;
        employee.DateOfJoining = request.DateOfJoining;
        employee.EmploymentType = request.EmploymentType;
        employee.DepartmentId = request.DepartmentId;
        employee.DesignationId = request.DesignationId;
        employee.BranchId = request.BranchId;
        employee.ReportingManagerId = request.ReportingManagerId;
        employee.UpdatedAt = clock.UtcNow;
        employee.UpdatedByEmployeeId = actorId;

        ApplyProfessionalProfile(employee, request.ProfessionalProfile);
        ApplyTargets(employee, request.Targets);

        await audit.WriteAsync(AuditActions.EmployeeUpdated, nameof(Employee), employee.Id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(await LoadDetailAsync(employeeId, ct), actorId, ct);
    }

    public async Task<InvitationLinkResponse> ResendInviteAsync(Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == employeeId, ct)
                       ?? throw new NotFoundException("Employee", employeeId);

        if (employee.Status != EmployeeStatus.Invited)
        {
            throw new BusinessRuleException(
                "An invite can only be resent while the account is still awaiting activation.",
                "not_invited");
        }

        var (_, link) = await authService.IssueTokenAsync(employee, ActivationTokenPurpose.Invite, actorId, ct);
        await emailSender.SendInviteAsync(employee.Email, employee.FirstName, link, ct);

        await audit.WriteAsync(AuditActions.InviteResent, nameof(Employee), employee.Id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return BuildInvitation(employee, ActivationTokenPurpose.Invite, link);
    }

    public async Task<InvitationLinkResponse> ResetPasswordAsync(Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == employeeId, ct)
                       ?? throw new NotFoundException("Employee", employeeId);

        // Emails a link and nothing else - a password is never set or shown here (spec section 6.3).
        var (_, link) = await authService.IssueTokenAsync(employee, ActivationTokenPurpose.Reset, actorId, ct);
        await emailSender.SendPasswordResetAsync(employee.Email, employee.FirstName, link, ct);

        await audit.WriteAsync(
            AuditActions.PasswordResetRequested, nameof(Employee), employee.Id, actorId,
            new { selfService = false }, ct);

        await db.SaveChangesAsync(ct);

        return BuildInvitation(employee, ActivationTokenPurpose.Reset, link);
    }

    public async Task<EmployeeDetailResponse> SuspendAsync(
        Guid employeeId, StatusChangeRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await LoadDetailAsync(employeeId, ct);

        if (employee.Status is EmployeeStatus.Inactive or EmployeeStatus.Exited)
        {
            throw new BusinessRuleException("This account is already deactivated.", "already_inactive");
        }

        employee.Status = EmployeeStatus.Suspended;
        employee.UpdatedAt = clock.UtcNow;
        employee.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.EmployeeSuspended, nameof(Employee), employee.Id, actorId,
            new { request.Reason }, ct);

        await db.SaveChangesAsync(ct);
        return await MapDetailAsync(employee, actorId, ct);
    }

    public async Task<EmployeeDetailResponse> ReinstateAsync(
        Guid employeeId, StatusChangeRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await LoadDetailAsync(employeeId, ct);

        // Someone who never activated goes back to Invited, not to Active - they still have no password.
        employee.Status = employee.PasswordHash is null ? EmployeeStatus.Invited : EmployeeStatus.Active;
        employee.LockoutEndsAt = null;
        employee.FailedLoginAttempts = 0;
        employee.FirstFailedLoginAt = null;
        employee.UpdatedAt = clock.UtcNow;
        employee.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.EmployeeReinstated, nameof(Employee), employee.Id, actorId,
            new { request.Reason, employee.Status }, ct);

        await db.SaveChangesAsync(ct);
        return await MapDetailAsync(employee, actorId, ct);
    }

    public async Task<DeactivationResponse> DeactivateAsync(
        Guid employeeId, StatusChangeRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await LoadDetailAsync(employeeId, ct);

        var openWork = await FindOpenWorkAsync(employeeId, ct);
        if (openWork.Count > 0)
        {
            return new DeactivationResponse
            {
                EmployeeId = employeeId,
                Status = employee.Status,
                ReassignmentRequired = true,
                OpenWorkItems = openWork
            };
        }

        employee.Status = EmployeeStatus.Inactive;
        employee.UpdatedAt = clock.UtcNow;
        employee.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.EmployeeDeactivated, nameof(Employee), employee.Id, actorId,
            new { request.Reason }, ct);

        await db.SaveChangesAsync(ct);

        return new DeactivationResponse
        {
            EmployeeId = employeeId,
            Status = employee.Status,
            ReassignmentRequired = false,
            OpenWorkItems = []
        };
    }

    /// <summary>
    /// Open-work check ahead of deactivation. The Sales, Design, Delivery, Procurement and
    /// Finance modules do not exist yet, so this is deliberately a no-op stub (spec section 7);
    /// each module adds its own probe here as it lands.
    /// </summary>
    private Task<IReadOnlyList<string>> FindOpenWorkAsync(Guid employeeId, CancellationToken ct)
    {
        _ = employeeId;
        _ = ct;
        return Task.FromResult<IReadOnlyList<string>>([]);
    }

    public async Task<DeleteEmployeeResponse> DeleteAsync(
        Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);

        var employee = await db.Employees
            .Include(e => e.Documents)
            .FirstOrDefaultAsync(e => e.Id == employeeId, ct)
            ?? throw new NotFoundException("Employee", employeeId);

        // The Super Admin is the one account that can lock everyone out of the system if it
        // disappears, and a filtered unique index means there is no second one to fall back on.
        if (employee.IsSuperAdmin)
        {
            throw new BusinessRuleException(
                "The Super Admin account cannot be deleted. Transfer the flag first if this person is leaving.",
                "super_admin_undeletable");
        }

        if (employeeId == actorId)
        {
            throw new BusinessRuleException(
                "You cannot delete your own account.", "cannot_delete_self");
        }

        // --- detach the three references SQL Server cannot cascade -----------------
        //
        // Employees -> EmployeePermissions already cascades on EmployeeId, so a second cascade
        // path on GrantedByEmployeeId is rejected (multiple cascade paths), and a self-reference
        // cannot cascade at all. The audit trail is deliberately kept: entries are anonymised
        // rather than deleted, because they also record what this person did to other people.

        var directReports = await db.Employees
            .Where(e => e.ReportingManagerId == employeeId)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.ReportingManagerId, (Guid?)null), ct);

        var grantsIssued = await db.EmployeePermissions
            .Where(ep => ep.GrantedByEmployeeId == employeeId)
            .ExecuteUpdateAsync(s => s.SetProperty(ep => ep.GrantedByEmployeeId, (Guid?)null), ct);

        var auditEntries = await db.AuditLogs
            .Where(a => a.ActorEmployeeId == employeeId)
            .ExecuteUpdateAsync(s => s.SetProperty(a => a.ActorEmployeeId, (Guid?)null), ct);

        // --- count what the cascade will take, before it takes it -------------------

        var deletedRelated = new Dictionary<string, int>
        {
            ["documents"] = employee.Documents.Count,
            ["permissionGrants"] = await db.EmployeePermissions.CountAsync(ep => ep.EmployeeId == employeeId, ct),
            ["activationTokens"] = await db.ActivationTokens.CountAsync(t => t.EmployeeId == employeeId, ct),
            ["professionalProfile"] = await db.EmployeeProfessionalProfiles.CountAsync(p => p.EmployeeId == employeeId, ct),
            ["targets"] = await db.EmployeeTargets.CountAsync(t => t.EmployeeId == employeeId, ct),
            ["statutoryRecord"] = await db.EmployeeStatutories.CountAsync(s => s.EmployeeId == employeeId, ct)
        };

        var blobUrls = employee.Documents.Select(d => d.BlobUrl).ToList();
        var email = employee.Email;

        db.Employees.Remove(employee);

        // Written before the removal commits, and with the identity in metadata, because after
        // this there is no row left to point at.
        await audit.WriteAsync(
            AuditActions.EmployeeDeleted, nameof(Employee), employeeId, actorId,
            new { email, employee.EmployeeCode, name = employee.FullName, deletedRelated }, ct);

        await db.SaveChangesAsync(ct);

        // Storage is not transactional, so the files go after the database says yes. A failure
        // here leaves an orphaned blob, which is reported rather than swallowed.
        var orphaned = new List<string>();

        foreach (var blobUrl in blobUrls)
        {
            try
            {
                await storage.DeleteAsync(blobUrl, ct);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Employee {EmployeeId} was deleted but blob {BlobUrl} remains.", employeeId, blobUrl);
                orphaned.Add(blobUrl);
            }
        }

        return new DeleteEmployeeResponse
        {
            EmployeeId = employeeId,
            Email = email,
            DeletedRelated = deletedRelated,
            Detached = new Dictionary<string, int>
            {
                ["directReports"] = directReports,
                ["permissionGrantsIssued"] = grantsIssued,
                ["auditEntriesAuthored"] = auditEntries
            },
            OrphanedFiles = orphaned
        };
    }

    public async Task<EmployeeDetailResponse> GetOwnProfileAsync(Guid employeeId, CancellationToken ct = default)
    {
        var employee = await LoadDetailAsync(employeeId, ct);
        return await MapDetailAsync(employee, employeeId, ct);
    }

    public async Task<EmployeeDetailResponse> UpdateOwnProfileAsync(
        Guid employeeId, UpdateMyProfileRequest request, CancellationToken ct = default)
    {
        var employee = await LoadDetailAsync(employeeId, ct);

        // Only personal and contact detail. Designation, permissions and status are not
        // reachable from this payload at all, by shape rather than by check (spec section 5.6).
        employee.FirstName = request.FirstName.Trim();
        employee.LastName = request.LastName.Trim();
        employee.Mobile = request.Mobile?.Trim();
        employee.PhotoUrl = request.PhotoUrl;
        employee.UpdatedAt = clock.UtcNow;
        employee.UpdatedByEmployeeId = employeeId;

        ApplyProfessionalProfile(employee, request.ProfessionalProfile);

        await audit.WriteAsync(AuditActions.EmployeeSelfUpdated, nameof(Employee), employeeId, employeeId, null, ct);
        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(await LoadDetailAsync(employeeId, ct), employeeId, ct);
    }

    /// <summary>
    /// Wraps a freshly issued link for the caller. The link itself is only included while
    /// outbound email is unconfigured - once mail is real, it belongs in the recipient inbox
    /// and nowhere else, so this hands back metadata only.
    /// </summary>
    private InvitationLinkResponse BuildInvitation(
        Employee employee, ActivationTokenPurpose purpose, string link)
    {
        var lifetime = purpose == ActivationTokenPurpose.Invite
            ? _options.InviteTokenLifetime
            : _options.ResetTokenLifetime;

        return new InvitationLinkResponse
        {
            Email = employee.Email,
            Purpose = purpose,
            DeliveredByEmail = emailSender.DeliversMail,
            Link = emailSender.DeliversMail ? null : link,
            ExpiresAt = clock.UtcNow.Add(lifetime)
        };
    }

    // --- helpers ------------------------------------------------------------------

    private async Task<Employee> LoadDetailAsync(Guid employeeId, CancellationToken ct) =>
        await db.Employees
            .Include(e => e.Department)
            .Include(e => e.Designation)
            .Include(e => e.Branch)
            .Include(e => e.ReportingManager)
            .Include(e => e.ProfessionalProfile)
            .Include(e => e.Targets)
            .Include(e => e.Permissions).ThenInclude(p => p.Permission)
            .Include(e => e.Permissions).ThenInclude(p => p.GrantedByEmployee)
            .FirstOrDefaultAsync(e => e.Id == employeeId, ct)
        ?? throw new NotFoundException("Employee", employeeId);

    private async Task<EmployeeDetailResponse> MapDetailAsync(Employee e, Guid actorId, CancellationToken ct)
    {
        var canManage = await permissions.CanManageAccountAsync(actorId, e.Id, ct);
        var canManagePermissions = canManage &&
                                   await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageUsers, ct);
        var canViewStatutory = actorId == e.Id ||
                               await permissions.HasPermissionAsync(actorId, PermissionCodes.ViewSensitiveData, ct);

        var createdByName = e.CreatedByEmployeeId is null
            ? null
            : await db.Employees.AsNoTracking()
                .Where(x => x.Id == e.CreatedByEmployeeId)
                .Select(x => x.FirstName + " " + x.LastName)
                .FirstOrDefaultAsync(ct);

        return new EmployeeDetailResponse
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            FullName = e.FullName,
            Email = e.Email,
            Mobile = e.Mobile,
            PhotoUrl = e.PhotoUrl,
            EmployeeCode = e.EmployeeCode,
            DateOfJoining = e.DateOfJoining,
            EmploymentType = e.EmploymentType,
            DepartmentId = e.DepartmentId,
            Department = e.Department?.Name ?? string.Empty,
            DesignationId = e.DesignationId,
            Designation = e.Designation?.Name ?? string.Empty,
            BranchId = e.BranchId,
            Branch = e.Branch?.Name ?? string.Empty,
            ReportingManagerId = e.ReportingManagerId,
            ReportingManagerName = e.ReportingManager is null
                ? null
                : $"{e.ReportingManager.FirstName} {e.ReportingManager.LastName}",
            Status = e.Status,
            IsSuperAdmin = e.IsSuperAdmin,
            MustChangePassword = e.MustChangePassword,
            LastSeenAt = e.LastSeenAt,
            CreatedAt = e.CreatedAt,
            CreatedByName = createdByName,
            ProfessionalProfile = MapProfile(e.ProfessionalProfile),
            Targets = MapTargets(e.Targets),
            Permissions = PermissionService.MapGrants(e),
            Capabilities = new EmployeeCapabilities
            {
                CanEdit = canManage,
                CanChangeStatus = canManage,
                CanResendInvite = canManage && e.Status == EmployeeStatus.Invited,
                CanResetPassword = canManage,
                CanManagePermissions = canManagePermissions,
                CanViewStatutory = canViewStatutory
            }
        };
    }

    private static ProfessionalProfileDto? MapProfile(EmployeeProfessionalProfile? p) =>
        p is null
            ? null
            : new ProfessionalProfileDto
            {
                Qualification = p.Qualification,
                Specialisation = p.Specialisation,
                ExperienceYears = p.ExperienceYears,
                SoftwareSkills = [.. p.SoftwareSkills],
                Certifications = [.. p.Certifications],
                PortfolioLink = p.PortfolioLink,
                Languages = [.. p.Languages]
            };

    private static EmployeeTargetsDto? MapTargets(EmployeeTargets? t) =>
        t is null
            ? null
            : new EmployeeTargetsDto
            {
                MonthlyTarget = t.MonthlyTarget,
                IncentivePercent = t.IncentivePercent,
                MaxDiscountBeforeEscalation = t.MaxDiscountBeforeEscalation,
                Territories = [.. t.Territories]
            };

    private static void ApplyProfessionalProfile(Employee employee, ProfessionalProfileDto? dto)
    {
        if (dto is null)
        {
            return;
        }

        employee.ProfessionalProfile ??= new EmployeeProfessionalProfile { EmployeeId = employee.Id };
        var p = employee.ProfessionalProfile;

        p.Qualification = dto.Qualification;
        p.Specialisation = dto.Specialisation;
        p.ExperienceYears = dto.ExperienceYears;
        p.SoftwareSkills = [.. dto.SoftwareSkills];
        p.Certifications = [.. dto.Certifications];
        p.PortfolioLink = dto.PortfolioLink;
        p.Languages = [.. dto.Languages];
    }

    private static void ApplyTargets(Employee employee, EmployeeTargetsDto? dto)
    {
        if (dto is null)
        {
            return;
        }

        employee.Targets ??= new EmployeeTargets { EmployeeId = employee.Id };
        var t = employee.Targets;

        t.MonthlyTarget = dto.MonthlyTarget;
        t.IncentivePercent = dto.IncentivePercent;
        t.MaxDiscountBeforeEscalation = dto.MaxDiscountBeforeEscalation;
        t.Territories = [.. dto.Territories];
    }

    private async Task RequireLookupsExistAsync(Guid departmentId, Guid designationId, Guid branchId, CancellationToken ct)
    {
        if (!await db.Departments.AnyAsync(d => d.Id == departmentId, ct))
        {
            throw new NotFoundException("Department", departmentId);
        }

        if (!await db.Designations.AnyAsync(d => d.Id == designationId, ct))
        {
            throw new NotFoundException("Designation", designationId);
        }

        if (!await db.Branches.AnyAsync(b => b.Id == branchId, ct))
        {
            throw new NotFoundException("Branch", branchId);
        }
    }

    /// <summary>
    /// Walks up the reporting chain from the proposed manager. Any assignment that would put
    /// the employee above themself is rejected here, at the API layer (spec section 4.2).
    /// </summary>
    private async Task RequireNoReportingCycleAsync(Guid employeeId, Guid? managerId, CancellationToken ct)
    {
        if (managerId is null)
        {
            return;
        }

        if (managerId == employeeId)
        {
            throw new BusinessRuleException("An employee cannot report to themself.", "reporting_cycle");
        }

        var chain = await db.Employees
            .AsNoTracking()
            .Select(e => new { e.Id, e.ReportingManagerId })
            .ToDictionaryAsync(e => e.Id, e => e.ReportingManagerId, ct);

        var cursor = managerId;
        var guard = 0;

        while (cursor is not null)
        {
            if (cursor == employeeId)
            {
                throw new BusinessRuleException(
                    "That reporting line would create a cycle.", "reporting_cycle");
            }

            if (++guard > chain.Count)
            {
                // Pre-existing loop in the stored data; refuse rather than spin.
                throw new BusinessRuleException(
                    "The existing reporting chain contains a cycle and must be corrected first.",
                    "reporting_cycle");
            }

            cursor = chain.TryGetValue(cursor.Value, out var next) ? next : null;
        }
    }

    /// <summary>Generates the next code in the EMP-0001 sequence (spec section 4.2).</summary>
    private async Task<string> GenerateEmployeeCodeAsync(CancellationToken ct)
    {
        var prefix = _options.EmployeeCodePrefix;

        var highest = await db.Employees
            .AsNoTracking()
            .Where(e => e.EmployeeCode.StartsWith(prefix))
            .Select(e => e.EmployeeCode)
            .ToListAsync(ct);

        var next = highest
            .Select(code => int.TryParse(code[prefix.Length..], out var n) ? n : 0)
            .DefaultIfEmpty(0)
            .Max() + 1;

        return $"{prefix}{next:D4}";
    }
}
