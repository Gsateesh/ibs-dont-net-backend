namespace IBS.SharedKernel.Security;

/// <summary>
/// The permission-check helper every module calls (spec sections 3 and 5.2).
/// <para>
/// <c>HasPermission(employee, code) = employee.IsSuperAdmin ? true
///   : EmployeePermission contains (employee.Id, code)</c>
/// </para>
/// </summary>
public interface IPermissionChecker
{
    /// <summary>True when the employee holds <paramref name="permissionCode"/>, or is Super Admin.</summary>
    Task<bool> HasPermissionAsync(Guid employeeId, string permissionCode, CancellationToken ct = default);

    /// <summary>True when the employee holds every one of <paramref name="permissionCodes"/>, or is Super Admin.</summary>
    Task<bool> HasAllPermissionsAsync(Guid employeeId, IEnumerable<string> permissionCodes, CancellationToken ct = default);

    /// <summary>True when the employee holds at least one of <paramref name="permissionCodes"/>, or is Super Admin.</summary>
    Task<bool> HasAnyPermissionAsync(Guid employeeId, IEnumerable<string> permissionCodes, CancellationToken ct = default);

    /// <summary>All permission codes effectively held. Super Admin resolves to the full catalogue.</summary>
    Task<IReadOnlySet<string>> GetEffectivePermissionsAsync(Guid employeeId, CancellationToken ct = default);

    /// <summary>Throws <see cref="Exceptions.ForbiddenException"/> unless the employee holds the permission.</summary>
    Task RequirePermissionAsync(Guid employeeId, string permissionCode, CancellationToken ct = default);

    /// <summary>
    /// <c>CanManageAccount(actor, target)</c> from spec section 5.3 - manage_users reaches every account
    /// except the one belonging to the Super Admin, which only the Super Admin may mutate.
    /// </summary>
    Task<bool> CanManageAccountAsync(Guid actorEmployeeId, Guid targetEmployeeId, CancellationToken ct = default);

    /// <summary>Throws <see cref="Exceptions.ForbiddenException"/> when <see cref="CanManageAccountAsync"/> is false.</summary>
    Task RequireCanManageAccountAsync(Guid actorEmployeeId, Guid targetEmployeeId, CancellationToken ct = default);
}
