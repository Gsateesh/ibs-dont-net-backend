using IBS.Modules.UsersAccess.Application.Dtos;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>
/// Company profile and the three lookup tables (spec sections 4.1 and 7). Everything here
/// requires manage_company_settings, and a lookup row in use cannot be deleted.
/// </summary>
public interface ISettingsService
{
    Task<CompanyResponse> GetCompanyAsync(CancellationToken ct = default);

    Task<CompanyResponse> UpdateCompanyAsync(UpdateCompanyRequest request, Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<BranchResponse>> GetBranchesAsync(CancellationToken ct = default);

    Task<BranchResponse> CreateBranchAsync(BranchRequest request, Guid actorId, CancellationToken ct = default);

    Task<BranchResponse> UpdateBranchAsync(Guid id, BranchRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Blocked while any employee still references the branch.</summary>
    Task DeleteBranchAsync(Guid id, Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<DepartmentResponse>> GetDepartmentsAsync(CancellationToken ct = default);

    Task<DepartmentResponse> CreateDepartmentAsync(DepartmentRequest request, Guid actorId, CancellationToken ct = default);

    Task<DepartmentResponse> UpdateDepartmentAsync(Guid id, DepartmentRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Blocked while any employee still references the department.</summary>
    Task DeleteDepartmentAsync(Guid id, Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<DesignationResponse>> GetDesignationsAsync(CancellationToken ct = default);

    Task<DesignationResponse> CreateDesignationAsync(DesignationRequest request, Guid actorId, CancellationToken ct = default);

    Task<DesignationResponse> UpdateDesignationAsync(Guid id, DesignationRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Blocked while any employee still references the designation.</summary>
    Task DeleteDesignationAsync(Guid id, Guid actorId, CancellationToken ct = default);
}
