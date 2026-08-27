namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// A grant of one permission to one employee (spec section 4.4). The composite key is
/// (EmployeeId, PermissionId); the grant metadata is what makes "granted by X on Y"
/// on the Access tab a single join.
/// </summary>
public class EmployeePermission
{
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public Guid PermissionId { get; set; }

    public Permission? Permission { get; set; }

    /// <summary>Who granted it. Null only for grants made by the seed tool.</summary>
    public Guid? GrantedByEmployeeId { get; set; }

    public Employee? GrantedByEmployee { get; set; }

    public DateTimeOffset GrantedAt { get; set; }
}
