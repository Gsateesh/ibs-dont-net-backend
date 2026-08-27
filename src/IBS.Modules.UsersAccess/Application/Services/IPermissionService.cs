using IBS.Modules.UsersAccess.Application.Dtos;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>
/// The permission catalogue and the grants made from it (spec sections 4.4 and 5.4).
/// Entries are created only by migration; this service can rename and regroup them,
/// and can grant or revoke them for an employee.
/// </summary>
public interface IPermissionService
{
    /// <summary>The catalogue arranged by group, each entry carrying its holder count.</summary>
    Task<IReadOnlyList<PermissionGroupResponse>> GetCatalogueAsync(CancellationToken ct = default);

    /// <summary>Renames, redescribes or regroups one entry. The code is never editable.</summary>
    Task<PermissionResponse> UpdateCatalogueEntryAsync(
        Guid permissionId, UpdatePermissionRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>The grants held by one employee, as shown on the Access tab.</summary>
    Task<IReadOnlyList<EmployeePermissionResponse>> GetEmployeePermissionsAsync(
        Guid employeeId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Replaces the permission set of an employee. Codes present are granted, codes absent
    /// are revoked. Granting manage_permissions or view_sensitive_data requires the actor to
    /// hold manage_permissions, not merely manage_users (spec section 5.4).
    /// </summary>
    Task<IReadOnlyList<EmployeePermissionResponse>> SetEmployeePermissionsAsync(
        Guid employeeId, UpdateEmployeePermissionsRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Validates permission codes and returns unsaved grant rows, without touching the database.
    /// <para>
    /// This is what lets Add Person validate everything before writing anything: an unknown code
    /// or a blocked escalation fails while the employee is still only an object in memory, so a
    /// rejected request leaves no half-created person behind.
    /// </para>
    /// </summary>
    Task<IReadOnlyList<Domain.Entities.EmployeePermission>> PrepareGrantsAsync(
        IReadOnlyList<string> permissionCodes, Guid actorId, CancellationToken ct = default);
}
