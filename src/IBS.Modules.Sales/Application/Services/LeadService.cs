using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Domain.Entities;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Directories;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.Sales.Application.Services;

/// <inheritdoc cref="ILeadService" />
public sealed class LeadService(
    ISalesDbContext db,
    IPermissionChecker permissions,
    IEmployeeDirectory directory,
    IAuditLogReader auditReader,
    IAuditLogWriter audit,
    IClock clock) : ILeadService
{
    public async Task<PagedResult<LeadListItemResponse>> ListAsync(
        LeadQuery query, Guid actorId, CancellationToken ct = default)
    {
        var canViewAll = await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var q = db.Leads.AsNoTracking().AsQueryable();

        if (!canViewAll)
        {
            // A plain employee sees only what is assigned to them, regardless of what they asked for.
            q = q.Where(l => l.AssignedToEmployeeId == actorId);
        }
        else if (query.AssignedToEmployeeId is not null)
        {
            q = q.Where(l => l.AssignedToEmployeeId == query.AssignedToEmployeeId);
        }

        if (query.Status is not null)
        {
            q = q.Where(l => l.Status == query.Status);
        }

        if (query.PropertyType is not null)
        {
            q = q.Where(l => l.PropertyType == query.PropertyType);
        }

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var term = query.Search.Trim();
            q = q.Where(l =>
                EF.Functions.Like(l.FirstName, $"%{term}%") ||
                EF.Functions.Like(l.LastName, $"%{term}%") ||
                EF.Functions.Like(l.Email, $"%{term}%") ||
                EF.Functions.Like(l.PropertyName, $"%{term}%") ||
                EF.Functions.Like(l.PropertyAddress, $"%{term}%"));
        }

        var total = await q.CountAsync(ct);

        var items = await q
            .OrderByDescending(l => l.CreatedAt)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(l => new LeadListItemResponse
            {
                Id = l.Id,
                FullName = l.FirstName + " " + l.LastName,
                Email = l.Email,
                Phone = l.Phone,
                PropertyName = l.PropertyName,
                PropertyAddress = l.PropertyAddress,
                PropertyType = l.PropertyType,
                BudgetMin = l.BudgetMin,
                BudgetMax = l.BudgetMax,
                Status = l.Status,
                AssignedToEmployeeId = l.AssignedToEmployeeId
            })
            .ToListAsync(ct);

        var assigneeIds = items
            .Where(i => i.AssignedToEmployeeId is not null)
            .Select(i => i.AssignedToEmployeeId!.Value);
        var summaries = await directory.GetSummariesAsync(assigneeIds, ct);

        foreach (var item in items)
        {
            if (item.AssignedToEmployeeId is not null &&
                summaries.TryGetValue(item.AssignedToEmployeeId.Value, out var summary))
            {
                item.AssignedToName = summary.FullName;
            }
        }

        return new PagedResult<LeadListItemResponse>(items, query.Page, query.PageSize, total);
    }

    public async Task<LeadDetailResponse> GetAsync(Guid leadId, Guid actorId, CancellationToken ct = default)
    {
        var lead = await db.Leads.AsNoTracking().FirstOrDefaultAsync(l => l.Id == leadId, ct)
                   ?? throw new NotFoundException("Lead", leadId);

        var canViewAll = await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        // Hidden rather than forbidden: a plain employee should not learn that a lead they
        // cannot see exists at all.
        if (!canViewAll && lead.AssignedToEmployeeId != actorId)
        {
            throw new NotFoundException("Lead", leadId);
        }

        return await MapDetailAsync(lead, canViewAll, ct);
    }

    public async Task<LeadDetailResponse> CreateAsync(
        CreateLeadRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var now = clock.UtcNow;

        var lead = new Lead
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.Trim(),
            Phone = request.Phone.Trim(),
            SecondaryPhone = request.SecondaryPhone?.Trim(),
            Notes = request.Notes?.Trim(),
            PropertyName = request.PropertyName.Trim(),
            PropertyAddress = request.PropertyAddress.Trim(),
            PropertyType = request.PropertyType,
            BudgetMin = request.BudgetMin,
            BudgetMax = request.BudgetMax,
            Status = Domain.Enums.LeadStatus.New,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        if (request.AssignedToEmployeeId is not null)
        {
            lead.AssignedToEmployeeId = request.AssignedToEmployeeId;
            lead.AssignedByEmployeeId = actorId;
            lead.AssignedAt = now;
        }

        db.Leads.Add(lead);

        await audit.WriteAsync(
            AuditActions.LeadCreated, nameof(Lead), lead.Id, actorId,
            new { lead.Email, lead.PropertyName, lead.PropertyAddress }, ct);

        if (lead.AssignedToEmployeeId is not null)
        {
            await audit.WriteAsync(
                AuditActions.LeadAssigned, nameof(Lead), lead.Id, actorId,
                new { toEmployeeId = lead.AssignedToEmployeeId }, ct);
        }

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(lead, canViewAll: true, ct);
    }

    public async Task<LeadDetailResponse> UpdateAsync(
        Guid leadId, UpdateLeadRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var lead = await db.Leads.FirstOrDefaultAsync(l => l.Id == leadId, ct)
                  ?? throw new NotFoundException("Lead", leadId);

        lead.FirstName = request.FirstName.Trim();
        lead.LastName = request.LastName.Trim();
        lead.Email = request.Email.Trim();
        lead.Phone = request.Phone.Trim();
        lead.SecondaryPhone = request.SecondaryPhone?.Trim();
        lead.Notes = request.Notes?.Trim();
        lead.PropertyName = request.PropertyName.Trim();
        lead.PropertyAddress = request.PropertyAddress.Trim();
        lead.PropertyType = request.PropertyType;
        lead.BudgetMin = request.BudgetMin;
        lead.BudgetMax = request.BudgetMax;
        lead.Status = request.Status;
        lead.UpdatedAt = clock.UtcNow;
        lead.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(AuditActions.LeadUpdated, nameof(Lead), lead.Id, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(lead, canViewAll: true, ct);
    }

    public async Task DeleteAsync(Guid leadId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var lead = await db.Leads.FirstOrDefaultAsync(l => l.Id == leadId, ct)
                  ?? throw new NotFoundException("Lead", leadId);

        db.Leads.Remove(lead);

        await audit.WriteAsync(
            AuditActions.LeadDeleted, nameof(Lead), leadId, actorId,
            new { lead.Email, name = lead.FullName }, ct);

        await db.SaveChangesAsync(ct);
    }

    public async Task<LeadDetailResponse> AssignAsync(
        Guid leadId, AssignLeadRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var lead = await db.Leads.FirstOrDefaultAsync(l => l.Id == leadId, ct)
                  ?? throw new NotFoundException("Lead", leadId);

        var previousAssigneeId = lead.AssignedToEmployeeId;
        var now = clock.UtcNow;

        lead.AssignedToEmployeeId = request.AssignedToEmployeeId;
        lead.AssignedByEmployeeId = actorId;
        lead.AssignedAt = now;

        var action = previousAssigneeId is null ? AuditActions.LeadAssigned : AuditActions.LeadReassigned;
        await audit.WriteAsync(
            action, nameof(Lead), lead.Id, actorId,
            new { fromEmployeeId = previousAssigneeId, toEmployeeId = request.AssignedToEmployeeId }, ct);

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(lead, canViewAll: true, ct);
    }

    public async Task<LeadDetailResponse> UnassignAsync(Guid leadId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var lead = await db.Leads.FirstOrDefaultAsync(l => l.Id == leadId, ct)
                  ?? throw new NotFoundException("Lead", leadId);

        if (lead.AssignedToEmployeeId is null)
        {
            throw new BusinessRuleException("This lead is not currently assigned to anyone.", "not_assigned");
        }

        var previousAssigneeId = lead.AssignedToEmployeeId;

        lead.AssignedToEmployeeId = null;
        lead.AssignedByEmployeeId = null;
        lead.AssignedAt = null;

        await audit.WriteAsync(
            AuditActions.LeadUnassigned, nameof(Lead), lead.Id, actorId,
            new { fromEmployeeId = previousAssigneeId }, ct);

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(lead, canViewAll: true, ct);
    }

    public async Task<BulkAssignResult> BulkAssignAsync(
        BulkAssignLeadsRequest request, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var requestedIds = request.LeadIds.Distinct().ToList();

        var leads = await db.Leads
            .Where(l => requestedIds.Contains(l.Id))
            .ToListAsync(ct);

        var foundIds = leads.Select(l => l.Id).ToHashSet();
        var skipped = requestedIds.Where(id => !foundIds.Contains(id)).ToList();

        var now = clock.UtcNow;
        var batchId = Guid.NewGuid();

        foreach (var lead in leads)
        {
            var previousAssigneeId = lead.AssignedToEmployeeId;

            lead.AssignedToEmployeeId = request.AssignedToEmployeeId;
            lead.AssignedByEmployeeId = actorId;
            lead.AssignedAt = now;

            // One row per lead, so each lead's own history stays correct; correlated by batchId.
            await audit.WriteAsync(
                AuditActions.LeadBulkAssigned, nameof(Lead), lead.Id, actorId,
                new { fromEmployeeId = previousAssigneeId, toEmployeeId = request.AssignedToEmployeeId, batchId }, ct);
        }

        await db.SaveChangesAsync(ct);

        return new BulkAssignResult
        {
            UpdatedCount = leads.Count,
            SkippedLeadIds = skipped
        };
    }

    public async Task<IReadOnlyList<AssignableEmployeeResponse>> GetAssignableEmployeesAsync(
        Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var summaries = await directory.GetAssignableEmployeesAsync(ct);

        return [.. summaries.Select(s => new AssignableEmployeeResponse
        {
            Id = s.Id,
            FullName = s.FullName,
            Email = s.Email
        })];
    }

    public async Task<IReadOnlyList<LeadAssignmentHistoryEntry>> GetAssignmentHistoryAsync(
        Guid leadId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        if (!await db.Leads.AsNoTracking().AnyAsync(l => l.Id == leadId, ct))
        {
            throw new NotFoundException("Lead", leadId);
        }

        var entries = await auditReader.GetForTargetAsync(leadId, ct);

        return [.. entries.Select(e => new LeadAssignmentHistoryEntry
        {
            Id = e.Id,
            Action = e.Action,
            ActorEmployeeId = e.ActorEmployeeId,
            ActorName = e.ActorName,
            Timestamp = e.Timestamp,
            MetadataJson = e.MetadataJson
        })];
    }

    // --- helpers ------------------------------------------------------------------

    private async Task<LeadDetailResponse> MapDetailAsync(Lead lead, bool canViewAll, CancellationToken ct)
    {
        var ids = new[] { lead.AssignedToEmployeeId, lead.AssignedByEmployeeId, lead.CreatedByEmployeeId, lead.UpdatedByEmployeeId }
            .Where(id => id is not null)
            .Select(id => id!.Value);

        var summaries = await directory.GetSummariesAsync(ids, ct);

        string? NameOf(Guid? id) => id is not null && summaries.TryGetValue(id.Value, out var s) ? s.FullName : null;

        var response = new LeadDetailResponse
        {
            Id = lead.Id,
            FirstName = lead.FirstName,
            LastName = lead.LastName,
            FullName = lead.FullName,
            Email = lead.Email,
            Phone = lead.Phone,
            SecondaryPhone = lead.SecondaryPhone,
            Notes = lead.Notes,
            PropertyName = lead.PropertyName,
            PropertyAddress = lead.PropertyAddress,
            PropertyType = lead.PropertyType,
            BudgetMin = lead.BudgetMin,
            BudgetMax = lead.BudgetMax,
            Status = lead.Status,
            AssignedToEmployeeId = lead.AssignedToEmployeeId,
            AssignedToName = NameOf(lead.AssignedToEmployeeId),
            CreatedAt = lead.CreatedAt,
            CreatedByName = NameOf(lead.CreatedByEmployeeId),
            UpdatedAt = lead.UpdatedAt,
            UpdatedByName = NameOf(lead.UpdatedByEmployeeId),
            Capabilities = new LeadCapabilities
            {
                CanEdit = canViewAll,
                CanDelete = canViewAll,
                CanReassign = canViewAll,
                CanViewAssignmentHistory = canViewAll
            }
        };

        // Assignment provenance (who assigned it and when) is administrative detail: a plain
        // employee sees that the lead is theirs, but not the audit trail behind it.
        if (canViewAll)
        {
            response.AssignedByEmployeeId = lead.AssignedByEmployeeId;
            response.AssignedByName = NameOf(lead.AssignedByEmployeeId);
            response.AssignedAt = lead.AssignedAt;
        }

        return response;
    }
}
