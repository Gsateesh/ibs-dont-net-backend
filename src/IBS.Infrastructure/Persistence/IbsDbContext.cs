using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Infrastructure.Seed;
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
    public DbSet<LeadRoom> LeadRooms => Set<LeadRoom>();
    public DbSet<LeadFloorPlanImage> LeadFloorPlanImages => Set<LeadFloorPlanImage>();
    public DbSet<LeadRoomRequirement> LeadRoomRequirements => Set<LeadRoomRequirement>();

    public DbSet<Quotation> Quotations => Set<Quotation>();
    public DbSet<QuotationRoom> QuotationRooms => Set<QuotationRoom>();
    public DbSet<QuotationLineItem> QuotationLineItems => Set<QuotationLineItem>();
    public DbSet<QuotationDocument> QuotationDocuments => Set<QuotationDocument>();
    public DbSet<QuotationCatalogEntry> QuotationCatalogEntries => Set<QuotationCatalogEntry>();
    public DbSet<QuotationRate> QuotationRates => Set<QuotationRate>();

    Task<int> ISalesDbContext.SaveChangesAsync(CancellationToken ct) => base.SaveChangesAsync(ct);

    // --- Infrastructure -------------------------------------------------------------

    /// <summary>Every outbound message, written by the dispatcher's logging decorator.</summary>
    public DbSet<Email.EmailLog> EmailLogs => Set<Email.EmailLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Each module owns its mapping; the context only collects them.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Employee).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Lead).Assembly);

        // Infrastructure owns a table of its own: the mail log, written around the dispatcher
        // rather than by any one module.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IbsDbContext).Assembly);

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

        // The quotation picker and its rate card. Placeholder pricing - see the seed's remarks.
        modelBuilder.Entity<QuotationCatalogEntry>().HasData(QuotationCatalogSeed.Entries);
        modelBuilder.Entity<QuotationRate>().HasData(QuotationCatalogSeed.Rates);
    }
}
