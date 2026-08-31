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

    /// <summary>
    /// How many leads sit in each phase, scoped exactly as the list is - so the quick-filter
    /// chips cannot advertise leads the caller would not be shown.
    /// </summary>
    Task<IReadOnlyList<LeadPhaseCountResponse>> GetPhaseCountsAsync(Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<AssignableEmployeeResponse>> GetAssignableEmployeesAsync(Guid actorId, CancellationToken ct = default);

    Task<IReadOnlyList<LeadAssignmentHistoryEntry>> GetAssignmentHistoryAsync(Guid leadId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Replaces the lead's floor plan. Any previously stored image is deleted, so a lead only
    /// ever has the one current plan.
    /// </summary>
    Task<LeadDetailResponse> UploadFloorPlanAsync(
        Guid leadId, string fileName, string? contentType, Stream content, Guid actorId, CancellationToken ct = default);

    Task<LeadDetailResponse> DeleteFloorPlanAsync(Guid leadId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Opens the stored floor plan for streaming, subject to the same visibility rule as the
    /// lead itself. Null when the lead has no floor plan on file.
    /// </summary>
    Task<LeadFloorPlanContent?> OpenFloorPlanAsync(Guid leadId, Guid actorId, CancellationToken ct = default);
}
