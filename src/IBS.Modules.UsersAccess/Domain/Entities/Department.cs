using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// An organisational department. Seeded with Sales, Design, Estimation, Procurement,
/// Execution and Finance (spec section 4.1). Carries no access of its own.
/// </summary>
public class Department : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    /// <summary>Employees in this department. Used for the in-use check before deletion.</summary>
    public ICollection<Employee> Employees { get; set; } = [];
}
