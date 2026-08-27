using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <inheritdoc cref="IPermissionService" />
public sealed class PermissionService(
    IUsersAccessDbContext db,
    IPermissionChecker permissions,
    IAuditLogWriter audit,
    IClock clock) : IPermissionService
{
    public async Task<IReadOnlyList<PermissionGroupResponse>> GetCatalogueAsync(CancellationToken ct = default)
    {
        // IsHighImpact is set after materialisation: it is a fact about the code list in the
        // shared kernel, not something the database should be asked to evaluate.
        var entries = await db.Permissions
            .AsNoTracking()
            .OrderBy(p => p.SortOrder)
            .Select(p => new PermissionResponse
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Description = p.Description,
                GroupName = p.GroupName,
                HolderCount = p.EmployeePermissions.Count
            })
            .ToListAsync(ct);

        foreach (var entry in entries)
        {
            entry.IsHighImpact = PermissionCodes.HighImpact.Contains(entry.Code);
        }

        return entries
            .GroupBy(p => p.GroupName)
            .Select(g => new PermissionGroupResponse
            {
                GroupName = g.Key,
                Permissions = g.ToList()
            })
            .ToList();
    }

    public async Task<PermissionResponse> UpdateCatalogueEntryAsync(
        Guid permissionId, UpdatePermissionRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManagePermissions, ct);

        var permission = await db.Permissions
            .Include(p => p.EmployeePermissions)
            .FirstOrDefaultAsync(p => p.Id == permissionId, ct)
            ?? throw new NotFoundException("Permission", permissionId);

        // Label, description and grouping only. The code is the contract with the codebase
        // and comes into existence solely through a migration (spec section 4.4).
        permission.Name = request.Name.Trim();
        permission.Description = request.Description?.Trim();
        permission.GroupName = request.GroupName.Trim();
        permission.UpdatedAt = clock.UtcNow;
        permission.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.PermissionCatalogueUpdated, nameof(Permission), permission.Id, actorId,
            new { permission.Code, permission.Name, permission.GroupName }, ct);

        await db.SaveChangesAsync(ct);

        return new PermissionResponse
        {
            Id = permission.Id,
            Code = permission.Code,
            Name = permission.Name,
            Description = permission.Description,
            GroupName = permission.GroupName,
            IsHighImpact = PermissionCodes.HighImpact.Contains(permission.Code),
            HolderCount = permission.EmployeePermissions.Count
        };
    }

    public async Task<IReadOnlyList<EmployeePermissionResponse>> GetEmployeePermissionsAsync(
        Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        if (actorId != employeeId)
        {
            await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageUsers, ct);
        }

        var employee = await db.Employees
            .AsNoTracking()
            .Include(e => e.Permissions).ThenInclude(p => p.Permission)
            .Include(e => e.Permissions).ThenInclude(p => p.GrantedByEmployee)
            .FirstOrDefaultAsync(e => e.Id == employeeId, ct)
            ?? throw new NotFoundException("Employee", employeeId);

        return MapGrants(employee);
    }

    public async Task<IReadOnlyList<EmployeePermissionResponse>> SetEmployeePermissionsAsync(
        Guid employeeId, UpdateEmployeePermissionsRequest request, Guid actorId, CancellationToken ct = default)
    {
        // Both gates apply: the account must be reachable by this actor, and the actor must
        // hold manage_users at all (spec sections 5.3 and 7).
        await permissions.RequireCanManageAccountAsync(actorId, employeeId, ct);
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageUsers, ct);

        var employee = await db.Employees
            .Include(e => e.Permissions).ThenInclude(p => p.Permission)
            .Include(e => e.Permissions).ThenInclude(p => p.GrantedByEmployee)
            .FirstOrDefaultAsync(e => e.Id == employeeId, ct)
            ?? throw new NotFoundException("Employee", employeeId);

        if (employee.IsSuperAdmin)
        {
            throw new BusinessRuleException(
                "The Super Admin bypasses permission checks, so there is nothing to grant.",
                "super_admin_permissions_immutable");
        }

        var requested = request.PermissionCodes
            .Select(c => c.Trim())
            .Where(c => c.Length > 0)
            .ToHashSet(StringComparer.Ordinal);

        var catalogue = await db.Permissions.ToDictionaryAsync(p => p.Code, p => p, ct);

        var unknown = requested.Where(c => !catalogue.ContainsKey(c)).ToList();
        if (unknown.Count > 0)
        {
            throw new BusinessRuleException(
                $"Unknown permission code(s): {string.Join(", ", unknown)}.", "unknown_permission");
        }

        var current = employee.Permissions
            .Select(p => p.Permission!.Code)
            .ToHashSet(StringComparer.Ordinal);

        var toGrant = requested.Except(current, StringComparer.Ordinal).ToList();
        var toRevoke = current.Except(requested, StringComparer.Ordinal).ToList();

        if (toGrant.Count == 0 && toRevoke.Count == 0)
        {
            return MapGrants(employee);
        }

        // Spec section 5.4: handing out manage_permissions or view_sensitive_data is itself a
        // privilege. Without this, any manage_users holder could grant themselves the very
        // permission the two were split apart to protect. Revoking needs no extra clearance.
        var highImpactGrants = toGrant.Where(PermissionCodes.HighImpact.Contains).ToList();
        if (highImpactGrants.Count > 0 &&
            !await permissions.HasPermissionAsync(actorId, PermissionCodes.ManagePermissions, ct))
        {
            throw new ForbiddenException(
                $"Granting {string.Join(" and ", highImpactGrants)} requires the manage_permissions permission.");
        }

        var now = clock.UtcNow;

        foreach (var code in toRevoke)
        {
            var row = employee.Permissions.First(p => p.Permission!.Code == code);
            db.EmployeePermissions.Remove(row);
            employee.Permissions.Remove(row);
        }

        foreach (var code in toGrant)
        {
            employee.Permissions.Add(new EmployeePermission
            {
                EmployeeId = employee.Id,
                PermissionId = catalogue[code].Id,
                GrantedByEmployeeId = actorId,
                GrantedAt = now
            });
        }

        await audit.WriteAsync(
            AuditActions.PermissionsUpdated, nameof(Employee), employee.Id, actorId,
            new { granted = toGrant, revoked = toRevoke }, ct);

        await db.SaveChangesAsync(ct);

        var refreshed = await db.Employees
            .AsNoTracking()
            .Include(e => e.Permissions).ThenInclude(p => p.Permission)
            .Include(e => e.Permissions).ThenInclude(p => p.GrantedByEmployee)
            .FirstAsync(e => e.Id == employeeId, ct);

        return MapGrants(refreshed);
    }

    public async Task<IReadOnlyList<EmployeePermission>> PrepareGrantsAsync(
        IReadOnlyList<string> permissionCodes, Guid actorId, CancellationToken ct = default)
    {
        var requested = permissionCodes
            .Select(c => c.Trim())
            .Where(c => c.Length > 0)
            .ToHashSet(StringComparer.Ordinal);

        if (requested.Count == 0)
        {
            return [];
        }

        var catalogue = await db.Permissions.AsNoTracking().ToDictionaryAsync(p => p.Code, p => p.Id, ct);

        var unknown = requested.Where(c => !catalogue.ContainsKey(c)).ToList();
        if (unknown.Count > 0)
        {
            throw new BusinessRuleException(
                $"Unknown permission code(s): {string.Join(", ", unknown)}. " +
                $"Use the code from GET /api/permissions, such as manage_users - not the id.",
                "unknown_permission");
        }

        var highImpact = requested.Where(PermissionCodes.HighImpact.Contains).ToList();
        if (highImpact.Count > 0 &&
            !await permissions.HasPermissionAsync(actorId, PermissionCodes.ManagePermissions, ct))
        {
            throw new ForbiddenException(
                $"Granting {string.Join(" and ", highImpact)} requires the manage_permissions permission.");
        }

        var now = clock.UtcNow;

        return [.. requested.Select(code => new EmployeePermission
        {
            PermissionId = catalogue[code],
            GrantedByEmployeeId = actorId,
            GrantedAt = now
        })];
    }

    /// <summary>
    /// Projects the grants of an employee for the Access tab. A Super Admin holds no rows at
    /// all, so the full catalogue is reported as implicit instead (spec section 5.2).
    /// </summary>
    internal static IReadOnlyList<EmployeePermissionResponse> MapGrants(Employee employee)
    {
        if (employee.IsSuperAdmin)
        {
            return PermissionCodes.All
                .Select(code => new EmployeePermissionResponse
                {
                    Code = code,
                    Name = code,
                    IsHighImpact = PermissionCodes.HighImpact.Contains(code),
                    IsImplicitFromSuperAdmin = true
                })
                .ToList();
        }

        return employee.Permissions
            .Where(p => p.Permission is not null)
            .OrderBy(p => p.Permission!.SortOrder)
            .Select(p => new EmployeePermissionResponse
            {
                PermissionId = p.PermissionId,
                Code = p.Permission!.Code,
                Name = p.Permission.Name,
                GroupName = p.Permission.GroupName,
                IsHighImpact = PermissionCodes.HighImpact.Contains(p.Permission.Code),
                GrantedByName = p.GrantedByEmployee is null
                    ? null
                    : $"{p.GrantedByEmployee.FirstName} {p.GrantedByEmployee.LastName}",
                GrantedAt = p.GrantedAt
            })
            .ToList();
    }
}
