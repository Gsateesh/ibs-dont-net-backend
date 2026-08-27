using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.Modules.UsersAccess.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace IBS.Infrastructure.Persistence;

/// <summary>
/// The single database context for the monolith. Each module contributes its entity
/// configurations and its slice interface; the context implements those interfaces so no
/// module ever depends on this type directly (spec section 3).
/// </summary>
public class IbsDbContext(DbContextOptions<IbsDbContext> options)
    : DbContext(options), IUsersAccessDbContext, ISalesDbContext
{
    // --- Users and access module --------------------------------------------------

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Designation> Designations => Set<Designation>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeProfessionalProfile> EmployeeProfessionalProfiles => Set<EmployeeProfessionalProfile>();
    public DbSet<EmployeeStatutory> EmployeeStatutories => Set<EmployeeStatutory>();
    public DbSet<EmployeeTargets> EmployeeTargets => Set<EmployeeTargets>();
    public DbSet<EmployeeDocument> EmployeeDocuments => Set<EmployeeDocument>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<EmployeePermission> EmployeePermissions => Set<EmployeePermission>();
    public DbSet<ActivationToken> ActivationTokens => Set<ActivationToken>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    Task<int> IUsersAccessDbContext.SaveChangesAsync(CancellationToken ct) => base.SaveChangesAsync(ct);

    // --- Sales module ---------------------------------------------------------------

    public DbSet<Lead> Leads => Set<Lead>();

    Task<int> ISalesDbContext.SaveChangesAsync(CancellationToken ct) => base.SaveChangesAsync(ct);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Each module owns its mapping; the context only collects them.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Employee).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Lead).Assembly);

        SeedReferenceData(modelBuilder);
    }

    /// <summary>
    /// Seeded through the model so the rows travel with a migration rather than with a
    /// startup routine: the catalogue and the lookup defaults exist identically everywhere.
    /// </summary>
    private static void SeedReferenceData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasData(LookupSeed.Company);
        modelBuilder.Entity<Branch>().HasData(LookupSeed.Branches);
        modelBuilder.Entity<Department>().HasData(LookupSeed.Departments);
        modelBuilder.Entity<Designation>().HasData(LookupSeed.Designations);
        modelBuilder.Entity<Permission>().HasData(PermissionSeed.All);
    }
}
