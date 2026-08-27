using IBS.Modules.UsersAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Application.Abstractions;

/// <summary>
/// The slice of the database this module is allowed to touch. Keeping the module against an
/// interface rather than the concrete DbContext is what makes the module boundary real:
/// IBS.Infrastructure owns the context and implements this, no module references another.
/// </summary>
public interface IUsersAccessDbContext
{
    DbSet<Company> Companies { get; }
    DbSet<Branch> Branches { get; }
    DbSet<Department> Departments { get; }
    DbSet<Designation> Designations { get; }
    DbSet<Employee> Employees { get; }
    DbSet<EmployeeProfessionalProfile> EmployeeProfessionalProfiles { get; }
    DbSet<EmployeeStatutory> EmployeeStatutories { get; }
    DbSet<EmployeeTargets> EmployeeTargets { get; }
    DbSet<EmployeeDocument> EmployeeDocuments { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<EmployeePermission> EmployeePermissions { get; }
    DbSet<ActivationToken> ActivationTokens { get; }
    DbSet<AuditLog> AuditLogs { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
