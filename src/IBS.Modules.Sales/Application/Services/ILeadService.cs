using IBS.Modules.Sales.Application.Dtos;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.Sales.Application.Services;

/// <summary>
/// Lead management. Visibility is scoped by permission: a caller without manage_leads sees
/// only leads assigned to themself; a manage_leads holder (or Super Admin, via the permission
/// bypass) sees and manages every lead.
/// </summary>
public interface ILeadService
{
    Task<PagedResult<LeadListItemResponse>> ListAsync(LeadQuery query, Guid actorId, CancellationToken ct = default);

    Task<LeadDetailResponse> GetAsync(Guid leadId, Guid actorId, CancellationToken ct = default);

    Task<LeadDetailResponse> CreateAsync(CreateLeadRequest request, Guid actorId, CancellationToken ct = default);

    Task<LeadDetailResponse> UpdateAsync(Guid leadId, UpdateLeadRequest request, Guid actorId, CancellationToken ct = default);

    Task DeleteAsync(Guid leadId, Guid actorId, CancellationToken ct = default);

    Task<LeadDetailResponse> AssignAsync(Guid leadId, AssignLeadRequest request, Guid actorId, CancellationToken ct = default);

    Task<LeadDetailResponse> UnassignAsync(Guid leadId, Guid actorId, CancellationToken ct = default);

    Task<BulkAssignResult> BulkAssignAsync(BulkAssignLeadsRequest request, Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<AssignableEmployeeResponse>> GetAssignableEmployeesAsync(Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<LeadAssignmentHistoryEntry>> GetAssignmentHistoryAsync(Guid leadId, Guid actorId, CancellationToken ct = default);
}
