using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Security;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Infrastructure;

/// <summary>
/// The single implementation of the access rules in spec section 5. Every module calls this
/// rather than querying EmployeePermission directly, so the Super Admin bypass and the
/// Super Admin account protection can never be forgotten at a call site.
/// </summary>
public sealed class PermissionChecker(IUsersAccessDbContext db) : IPermissionChecker
{
    public async Task<bool> HasPermissionAsync(Guid employeeId, string permissionCode, CancellationToken ct = default)
    {
        if (await IsSuperAdminAsync(employeeId, ct))
        {
            return true;
        }

        return await db.EmployeePermissions
            .AsNoTracking()
            .AnyAsync(ep => ep.EmployeeId == employeeId && ep.Permission!.Code == permissionCode, ct);
    }

    public async Task<bool> HasAllPermissionsAsync(Guid employeeId, IEnumerable<string> permissionCodes, CancellationToken ct = default)
    {
        var required = permissionCodes.Distinct(StringComparer.Ordinal).ToList();
        if (required.Count == 0)
        {
            return true;
        }

        var held = await GetEffectivePermissionsAsync(employeeId, ct);
        return required.All(held.Contains);
    }

    public async Task<bool> HasAnyPermissionAsync(Guid employeeId, IEnumerable<string> permissionCodes, CancellationToken ct = default)
    {
        var candidates = permissionCodes.Distinct(StringComparer.Ordinal).ToList();
        if (candidates.Count == 0)
        {
            return false;
        }

        var held = await GetEffectivePermissionsAsync(employeeId, ct);
        return candidates.Any(held.Contains);
    }

    public async Task<IReadOnlySet<string>> GetEffectivePermissionsAsync(Guid employeeId, CancellationToken ct = default)
    {
        if (await IsSuperAdminAsync(employeeId, ct))
        {
            // The flag is a bypass, so the effective set is the whole catalogue (spec section 5.2).
            return PermissionCodes.All.ToHashSet(StringComparer.Ordinal);
        }

        var codes = await db.EmployeePermissions
            .AsNoTracking()
            .Where(ep => ep.EmployeeId == employeeId)
            .Select(ep => ep.Permission!.Code)
            .ToListAsync(ct);

        return codes.ToHashSet(StringComparer.Ordinal);
    }

    public async Task RequirePermissionAsync(Guid employeeId, string permissionCode, CancellationToken ct = default)
    {
        if (!await HasPermissionAsync(employeeId, permissionCode, ct))
        {
            throw new ForbiddenException($"This action requires the {permissionCode} permission.");
        }
    }

    /// <inheritdoc />
    public async Task<bool> CanManageAccountAsync(Guid actorEmployeeId, Guid targetEmployeeId, CancellationToken ct = default)
    {
        if (!await HasPermissionAsync(actorEmployeeId, PermissionCodes.ManageUsers, ct))
        {
            return false;
        }

        var targetIsSuperAdmin = await db.Employees
            .AsNoTracking()
            .Where(e => e.Id == targetEmployeeId)
            .Select(e => (bool?)e.IsSuperAdmin)
            .FirstOrDefaultAsync(ct);

        if (targetIsSuperAdmin is null)
        {
            throw new NotFoundException("Employee", targetEmployeeId);
        }

        // manage_users reaches every account except the one belonging to the Super Admin,
        // which only the Super Admin themself may mutate (spec section 5.3).
        return targetIsSuperAdmin == false || actorEmployeeId == targetEmployeeId;
    }

    public async Task RequireCanManageAccountAsync(Guid actorEmployeeId, Guid targetEmployeeId, CancellationToken ct = default)
    {
        if (!await CanManageAccountAsync(actorEmployeeId, targetEmployeeId, ct))
        {
            throw new ForbiddenException("You are not allowed to manage this account.");
        }
    }

    private Task<bool> IsSuperAdminAsync(Guid employeeId, CancellationToken ct) =>
        db.Employees.AsNoTracking().AnyAsync(e => e.Id == employeeId && e.IsSuperAdmin, ct);
}
