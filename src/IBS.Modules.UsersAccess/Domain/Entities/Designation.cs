using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// A job title. Purely descriptive: it carries no access whatsoever (spec sections 4.1 and 5.1).
/// Everything a person can do comes from <see cref="EmployeePermission"/> rows, or the
/// <see cref="Employee.IsSuperAdmin"/> bypass.
/// </summary>
public class Designation : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Marks sales-type designations, for which the optional targets section of the
    /// Add Person form is shown (spec section 4.3).
    /// </summary>
    public bool IsSalesRole { get; set; }

    /// <summary>Employees holding this designation. Used for the in-use check before deletion.</summary>
    public ICollection<Employee> Employees { get; set; } = [];
}
