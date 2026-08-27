using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <inheritdoc cref="ISettingsService" />
public sealed class SettingsService(
    IUsersAccessDbContext db,
    IPermissionChecker permissions,
    IAuditLogWriter audit,
    IClock clock) : ISettingsService
{
    // --- company ------------------------------------------------------------------

    public async Task<CompanyResponse> GetCompanyAsync(CancellationToken ct = default)
    {
        var company = await db.Companies.AsNoTracking().FirstOrDefaultAsync(ct)
                      ?? throw new NotFoundException("Company", "singleton");

        return Map(company);
    }

    public async Task<CompanyResponse> UpdateCompanyAsync(
        UpdateCompanyRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var company = await db.Companies.FirstOrDefaultAsync(ct)
                      ?? throw new NotFoundException("Company", "singleton");

        company.LegalName = request.LegalName.Trim();
        company.Gstin = request.Gstin?.Trim();
        company.RegisteredAddress = request.RegisteredAddress?.Trim();
        company.LogoUrl = request.LogoUrl;
        company.FinancialYearStart = request.FinancialYearStart;
        company.Currency = request.Currency.Trim().ToUpperInvariant();
        company.UpdatedAt = clock.UtcNow;
        company.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(AuditActions.CompanyUpdated, nameof(Company), company.Id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return Map(company);
    }

    private static CompanyResponse Map(Company c) => new()
    {
        Id = c.Id,
        LegalName = c.LegalName,
        Gstin = c.Gstin,
        RegisteredAddress = c.RegisteredAddress,
        LogoUrl = c.LogoUrl,
        FinancialYearStart = c.FinancialYearStart,
        Currency = c.Currency
    };

    // --- branches -----------------------------------------------------------------

    public async Task<IReadOnlyList<BranchResponse>> GetBranchesAsync(CancellationToken ct = default) =>
        await db.Branches
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .Select(b => new BranchResponse
            {
                Id = b.Id,
                Name = b.Name,
                City = b.City,
                Address = b.Address,
                Timezone = b.Timezone,
                EmployeeCount = b.Employees.Count
            })
            .ToListAsync(ct);

    public async Task<BranchResponse> CreateBranchAsync(BranchRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);
        await RequireUniqueNameAsync(db.Branches, request.Name, null, "branch", ct);

        var branch = new Branch
        {
            Name = request.Name.Trim(),
            City = request.City?.Trim(),
            Address = request.Address?.Trim(),
            Timezone = request.Timezone.Trim(),
            CreatedAt = clock.UtcNow,
            CreatedByEmployeeId = actorId
        };

        db.Branches.Add(branch);
        await audit.WriteAsync(AuditActions.BranchCreated, nameof(Branch), branch.Id, actorId, new { branch.Name }, ct);
        await db.SaveChangesAsync(ct);

        return new BranchResponse
        {
            Id = branch.Id,
            Name = branch.Name,
            City = branch.City,
            Address = branch.Address,
            Timezone = branch.Timezone,
            EmployeeCount = 0
        };
    }

    public async Task<BranchResponse> UpdateBranchAsync(
        Guid id, BranchRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var branch = await db.Branches.Include(b => b.Employees).FirstOrDefaultAsync(b => b.Id == id, ct)
                     ?? throw new NotFoundException("Branch", id);

        await RequireUniqueNameAsync(db.Branches, request.Name, id, "branch", ct);

        branch.Name = request.Name.Trim();
        branch.City = request.City?.Trim();
        branch.Address = request.Address?.Trim();
        branch.Timezone = request.Timezone.Trim();
        branch.UpdatedAt = clock.UtcNow;
        branch.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(AuditActions.BranchUpdated, nameof(Branch), branch.Id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return new BranchResponse
        {
            Id = branch.Id,
            Name = branch.Name,
            City = branch.City,
            Address = branch.Address,
            Timezone = branch.Timezone,
            EmployeeCount = branch.Employees.Count
        };
    }

    public async Task DeleteBranchAsync(Guid id, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var branch = await db.Branches.FirstOrDefaultAsync(b => b.Id == id, ct)
                     ?? throw new NotFoundException("Branch", id);

        var inUse = await db.Employees.CountAsync(e => e.BranchId == id, ct);
        if (inUse > 0)
        {
            throw new ConflictException(
                $"{branch.Name} is still assigned to {inUse} employee(s). Reassign them before deleting it.");
        }

        db.Branches.Remove(branch);
        await audit.WriteAsync(AuditActions.BranchDeleted, nameof(Branch), id, actorId, new { branch.Name }, ct);
        await db.SaveChangesAsync(ct);
    }

    // --- departments --------------------------------------------------------------

    public async Task<IReadOnlyList<DepartmentResponse>> GetDepartmentsAsync(CancellationToken ct = default) =>
        await db.Departments
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .Select(d => new DepartmentResponse
            {
                Id = d.Id,
                Name = d.Name,
                EmployeeCount = d.Employees.Count
            })
            .ToListAsync(ct);

    public async Task<DepartmentResponse> CreateDepartmentAsync(
        DepartmentRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);
        await RequireUniqueNameAsync(db.Departments, request.Name, null, "department", ct);

        var department = new Department
        {
            Name = request.Name.Trim(),
            CreatedAt = clock.UtcNow,
            CreatedByEmployeeId = actorId
        };

        db.Departments.Add(department);
        await audit.WriteAsync(
            AuditActions.DepartmentCreated, nameof(Department), department.Id, actorId, new { department.Name }, ct);
        await db.SaveChangesAsync(ct);

        return new DepartmentResponse { Id = department.Id, Name = department.Name, EmployeeCount = 0 };
    }

    public async Task<DepartmentResponse> UpdateDepartmentAsync(
        Guid id, DepartmentRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var department = await db.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id, ct)
                         ?? throw new NotFoundException("Department", id);

        await RequireUniqueNameAsync(db.Departments, request.Name, id, "department", ct);

        department.Name = request.Name.Trim();
        department.UpdatedAt = clock.UtcNow;
        department.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(AuditActions.DepartmentUpdated, nameof(Department), id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return new DepartmentResponse
        {
            Id = department.Id,
            Name = department.Name,
            EmployeeCount = department.Employees.Count
        };
    }

    public async Task DeleteDepartmentAsync(Guid id, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var department = await db.Departments.FirstOrDefaultAsync(d => d.Id == id, ct)
                         ?? throw new NotFoundException("Department", id);

        var inUse = await db.Employees.CountAsync(e => e.DepartmentId == id, ct);
        if (inUse > 0)
        {
            throw new ConflictException(
                $"{department.Name} is still assigned to {inUse} employee(s). Reassign them before deleting it.");
        }

        db.Departments.Remove(department);
        await audit.WriteAsync(
            AuditActions.DepartmentDeleted, nameof(Department), id, actorId, new { department.Name }, ct);
        await db.SaveChangesAsync(ct);
    }

    // --- designations -------------------------------------------------------------

    public async Task<IReadOnlyList<DesignationResponse>> GetDesignationsAsync(CancellationToken ct = default) =>
        await db.Designations
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .Select(d => new DesignationResponse
            {
                Id = d.Id,
                Name = d.Name,
                IsSalesRole = d.IsSalesRole,
                EmployeeCount = d.Employees.Count
            })
            .ToListAsync(ct);

    public async Task<DesignationResponse> CreateDesignationAsync(
        DesignationRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);
        await RequireUniqueNameAsync(db.Designations, request.Name, null, "designation", ct);

        var designation = new Designation
        {
            Name = request.Name.Trim(),
            IsSalesRole = request.IsSalesRole,
            CreatedAt = clock.UtcNow,
            CreatedByEmployeeId = actorId
        };

        db.Designations.Add(designation);
        await audit.WriteAsync(
            AuditActions.DesignationCreated, nameof(Designation), designation.Id, actorId, new { designation.Name }, ct);
        await db.SaveChangesAsync(ct);

        return new DesignationResponse
        {
            Id = designation.Id,
            Name = designation.Name,
            IsSalesRole = designation.IsSalesRole,
            EmployeeCount = 0
        };
    }

    public async Task<DesignationResponse> UpdateDesignationAsync(
        Guid id, DesignationRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var designation = await db.Designations.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id, ct)
                          ?? throw new NotFoundException("Designation", id);

        await RequireUniqueNameAsync(db.Designations, request.Name, id, "designation", ct);

        designation.Name = request.Name.Trim();
        designation.IsSalesRole = request.IsSalesRole;
        designation.UpdatedAt = clock.UtcNow;
        designation.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(AuditActions.DesignationUpdated, nameof(Designation), id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return new DesignationResponse
        {
            Id = designation.Id,
            Name = designation.Name,
            IsSalesRole = designation.IsSalesRole,
            EmployeeCount = designation.Employees.Count
        };
    }

    public async Task DeleteDesignationAsync(Guid id, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageCompanySettings, ct);

        var designation = await db.Designations.FirstOrDefaultAsync(d => d.Id == id, ct)
                          ?? throw new NotFoundException("Designation", id);

        var inUse = await db.Employees.CountAsync(e => e.DesignationId == id, ct);
        if (inUse > 0)
        {
            throw new ConflictException(
                $"{designation.Name} is still assigned to {inUse} employee(s). Reassign them before deleting it.");
        }

        db.Designations.Remove(designation);
        await audit.WriteAsync(
            AuditActions.DesignationDeleted, nameof(Designation), id, actorId, new { designation.Name }, ct);
        await db.SaveChangesAsync(ct);
    }

    /// <summary>
    /// Lookup names are unique, so the Settings list cannot grow two identical rows.
    /// Written once over EF.Property so it works for all three lookup tables.
    /// </summary>
    private static async Task RequireUniqueNameAsync<T>(
        IQueryable<T> set, string name, Guid? exceptId, string label, CancellationToken ct)
        where T : class
    {
        var trimmed = name.Trim();

        var clash = await set.AnyAsync(
            x => EF.Property<string>(x, "Name") == trimmed &&
                 (exceptId == null || EF.Property<Guid>(x, "Id") != exceptId),
            ct);

        if (clash)
        {
            throw new ConflictException($"A {label} named {trimmed} already exists.");
        }
    }
}
