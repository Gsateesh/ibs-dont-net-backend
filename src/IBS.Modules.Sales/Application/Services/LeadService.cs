using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Application.Options;
using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Directories;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Primitives;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Storage;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IBS.Modules.Sales.Application.Services;

/// <summary>How much of the Leads module the caller can reach at all.</summary>
internal enum LeadAccess
{
    /// <summary>Holds neither leads permission: the module is closed to them.</summary>
    None = 0,

    /// <summary>manage_own_leads: only the leads assigned to them, which they may also edit.</summary>
    Own = 1,

    /// <summary>manage_leads: every lead, plus assignment and deletion.</summary>
    All = 2
}

/// <inheritdoc cref="ILeadService" />
public sealed class LeadService(
    ISalesDbContext db,
    IPermissionChecker permissions,
    IEmployeeDirectory directory,
    IAuditLogReader auditReader,
    IAuditLogWriter audit,
    IFileStorage storage,
    IOptions<SalesOptions> options,
    IClock clock) : ILeadService
{
    /// <summary>Image types a floor plan may be uploaded as. PDFs are not accepted here.</summary>
    private static readonly HashSet<string> AllowedFloorPlanContentTypes =
        new(StringComparer.OrdinalIgnoreCase) { "image/png", "image/jpeg", "image/jpg", "image/webp", "image/gif" };

    /// <summary>
    /// A ceiling on images per lead. Not a business rule so much as a guard: the viewer pages
    /// through them one at a time, and nobody is stepping through a hundred drawings.
    /// </summary>
    private const int MaxFloorPlansPerLead = 20;

    private readonly SalesOptions _options = options.Value;

    public async Task<PagedResult<LeadListItemResponse>> ListAsync(
        LeadQuery query, Guid actorId, CancellationToken ct = default)
    {
        var access = await RequireAnyLeadAccessAsync(actorId, ct);
        var canViewAll = access == LeadAccess.All;

        var q = db.Leads.AsNoTracking().AsQueryable();

        if (!canViewAll)
        {
            // manage_own_leads sees only what is assigned to them, regardless of what they asked for.
            q = q.Where(l => l.AssignedToEmployeeId == actorId);
        }
        else if (query.AssignedToEmployeeId is not null)
        {
            q = q.Where(l => l.AssignedToEmployeeId == query.AssignedToEmployeeId);
        }

        if (query.Phases is { Count: > 0 })
        {
            q = q.Where(l => query.Phases.Contains(l.Phase));
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
                EF.Functions.Like(l.AddressLine1, $"%{term}%") ||
                EF.Functions.Like(l.AddressLine2 ?? "", $"%{term}%") ||
                EF.Functions.Like(l.City ?? "", $"%{term}%"));
        }

        var total = await q.CountAsync(ct);

        var items = await ApplySort(q, query)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(l => new LeadListItemResponse
            {
                Id = l.Id,
                // CustomerCode itself is a computed property EF cannot translate to SQL; the raw
                // number travels instead and is formatted below, once the query has run.
                CustomerNumber = l.CustomerNumber,
                FullName = (l.FirstName + " " + (l.LastName ?? "")).Trim(),
                Email = l.Email,
                Phone = l.Phone,
                PropertyName = l.PropertyName,
                AddressLine1 = l.AddressLine1,
                AddressLine2 = l.AddressLine2,
                City = l.City,
                PinCode = l.PinCode,
                State = l.State,
                PropertyType = l.PropertyType,
                PropertyConfiguration = l.PropertyConfiguration,
                PropertySize = l.PropertySize,
                PropertySizeUnit = l.PropertySizeUnit,
                BudgetMin = l.BudgetMin,
                BudgetMax = l.BudgetMax,
                Phase = l.Phase,
                IsInterested = l.IsInterested,
                HasFloorPlan = l.FloorPlans.Any(),

                // What the client was last quoted: the newest version of the initial
                // quotation. A correlated subquery rather than a join, so a lead that has
                // never been quoted still returns its row, with null here.
                QuoteValue = db.Quotations
                    .Where(quote => quote.LeadId == l.Id && quote.Stage == QuotationStage.Initial)
                    .OrderByDescending(quote => quote.VersionNumber)
                    .Select(quote => (decimal?)quote.GrandTotal)
                    .FirstOrDefault(),
                NextFollowUpDate = l.NextFollowUpDate,
                QuotationSharedAt = l.QuotationSharedAt,
                CreatedAt = l.CreatedAt,
                AssignedToEmployeeId = l.AssignedToEmployeeId
            })
            .ToListAsync(ct);

        var assigneeIds = items
            .Where(i => i.AssignedToEmployeeId is not null)
            .Select(i => i.AssignedToEmployeeId!.Value);
        var summaries = await directory.GetSummariesAsync(assigneeIds, ct);

        foreach (var item in items)
        {
            item.CustomerCode = $"CUS-{item.CustomerNumber:D4}";

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
        var (lead, access) = await LoadAccessibleLeadAsync(leadId, actorId, tracked: false, ct);

        return await MapDetailAsync(lead, access, actorId, ct);
    }

    public async Task<LeadDetailResponse> CreateAsync(
        CreateLeadRequest request, Guid actorId, CancellationToken ct = default)
    {
        var access = await RequireAnyLeadAccessAsync(actorId, ct);

        var now = clock.UtcNow;

        var nextCustomerNumber = (await db.Leads.MaxAsync(l => (int?)l.CustomerNumber, ct) ?? 0) + 1;

        var lead = new Lead
        {
            CustomerNumber = nextCustomerNumber,
            FirstName = request.FirstName.Trim(),
            LastName = Blank(request.LastName),
            Email = request.Email.Trim(),
            Phone = request.Phone.Trim(),
            SecondaryPhone = request.SecondaryPhone?.Trim(),
            Notes = request.Notes?.Trim(),
            PropertyName = request.PropertyName.Trim(),
            AddressLine1 = request.AddressLine1.Trim(),
            AddressLine2 = Blank(request.AddressLine2),
            City = Blank(request.City),
            PinCode = Blank(request.PinCode),
            State = Blank(request.State),
            PropertyType = request.PropertyType,
            PropertySize = request.PropertySize,
            PropertySizeUnit = request.PropertySizeUnit,
            PropertyConfiguration = request.PropertyConfiguration,
            BudgetMin = request.BudgetMin,
            BudgetMax = request.BudgetMax,
            Phase = request.Phase,
            ContactedDate = request.ContactedDate,
            NextFollowUpDate = request.NextFollowUpDate,
            QuotationSharedAt = request.QuotationSharedAt,
            IsInterested = request.IsInterested,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        RequireBudgetOrder(lead.BudgetMin, lead.BudgetMax);

        // A lead created directly into a quotation-shared phase is stamped too, so the field
        // is never silently empty for a lead that plainly has been quoted.
        if (lead.QuotationSharedAt is null && lead.Phase.ImpliesQuotationShared())
        {
            lead.QuotationSharedAt = DateOnly.FromDateTime(now.UtcDateTime);
        }

        lead.Rooms = BuildRooms(request.Rooms, now, actorId);

        if (access == LeadAccess.Own)
        {
            // A manage_own_leads holder can only ever create a lead for themselves - honouring
            // a requested assignee would let them hand work to anyone, which is precisely the
            // privilege manage_leads exists to hold.
            lead.AssignedToEmployeeId = actorId;
            lead.AssignedByEmployeeId = actorId;
            lead.AssignedAt = now;
        }
        else if (request.AssignedToEmployeeId is not null)
        {
            lead.AssignedToEmployeeId = request.AssignedToEmployeeId;
            lead.AssignedByEmployeeId = actorId;
            lead.AssignedAt = now;
        }

        db.Leads.Add(lead);

        await audit.WriteAsync(
            AuditActions.LeadCreated, nameof(Lead), lead.Id, actorId,
            new { lead.Email, lead.PropertyName, lead.AddressLine1, roomCount = lead.Rooms.Count }, ct);

        if (lead.AssignedToEmployeeId is not null)
        {
            await audit.WriteAsync(
                AuditActions.LeadAssigned, nameof(Lead), lead.Id, actorId,
                new { toEmployeeId = lead.AssignedToEmployeeId }, ct);
        }

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(lead, access, actorId, ct);
    }

    public async Task<LeadDetailResponse> UpdateAsync(
        Guid leadId, UpdateLeadRequest request, Guid actorId, CancellationToken ct = default)
    {
        // Editing is open to the lead's own assignee: the tracking fields below - contacted
        // date, next follow-up, quotation status - are exactly what the salesperson who owns
        // the lead is meant to keep current. Assignment is not part of this payload, so an
        // owner still cannot move a lead to or from anyone.
        var (lead, access) = await LoadAccessibleLeadAsync(leadId, actorId, tracked: true, ct);

        var now = clock.UtcNow;
        var previousPhase = lead.Phase;

        lead.FirstName = request.FirstName.Trim();
        lead.LastName = Blank(request.LastName);
        lead.Email = request.Email.Trim();
        lead.Phone = request.Phone.Trim();
        lead.SecondaryPhone = request.SecondaryPhone?.Trim();
        lead.Notes = request.Notes?.Trim();
        lead.PropertyName = request.PropertyName.Trim();
        lead.AddressLine1 = request.AddressLine1.Trim();
        lead.AddressLine2 = Blank(request.AddressLine2);
        lead.City = Blank(request.City);
        lead.PinCode = Blank(request.PinCode);
        lead.State = Blank(request.State);
        lead.PropertyType = request.PropertyType;
        lead.PropertySize = request.PropertySize;
        lead.PropertySizeUnit = request.PropertySizeUnit;
        lead.PropertyConfiguration = request.PropertyConfiguration;
        lead.BudgetMin = request.BudgetMin;
        lead.BudgetMax = request.BudgetMax;
        lead.Phase = request.Phase;
        lead.ContactedDate = request.ContactedDate;
        lead.NextFollowUpDate = request.NextFollowUpDate;
        lead.QuotationSharedAt = request.QuotationSharedAt;

        // Stamped only on the crossing into a quotation-shared phase, and only when the client
        // did not supply a date itself. Doing it on every save would keep overwriting a date
        // the user had deliberately corrected or cleared.
        if (lead.QuotationSharedAt is null &&
            !previousPhase.ImpliesQuotationShared() &&
            lead.Phase.ImpliesQuotationShared())
        {
            lead.QuotationSharedAt = DateOnly.FromDateTime(now.UtcDateTime);
        }
        lead.IsInterested = request.IsInterested;
        lead.UpdatedAt = now;
        lead.UpdatedByEmployeeId = actorId;

        RequireBudgetOrder(lead.BudgetMin, lead.BudgetMax);

        // The form edits the whole Requirements section at once, so the rooms are replaced
        // rather than diffed: whatever the client sends is what the lead ends up with.
        //
        // The replacements go in through the DbSet rather than by being added to lead.Rooms.
        // AuditableEntity hands every new row a Guid at construction, so a replacement turning
        // up inside a tracked navigation already carries a key - and change tracking reads a
        // populated key as "this row exists", issuing UPDATEs against ids that were never
        // inserted. Each matches nothing, and SaveChanges fails with "expected to affect
        // 1 row(s), but actually affected 0". AddRange marks the whole graph Added outright.
        //
        // Only the rooms are deleted: their requirements cascade with them in both the model
        // and the database.
        db.LeadRooms.RemoveRange(lead.Rooms);

        var rooms = BuildRooms(request.Rooms, now, actorId);

        foreach (var room in rooms)
        {
            room.LeadId = lead.Id;
        }

        db.LeadRooms.AddRange(rooms);

        await audit.WriteAsync(
            AuditActions.LeadUpdated, nameof(Lead), lead.Id, actorId,
            new { roomCount = rooms.Count }, ct);

        await db.SaveChangesAsync(ct);

        // Mapped from what was just written rather than from the navigation, which still holds
        // the rows that were deleted above.
        lead.Rooms = rooms;

        return await MapDetailAsync(lead, access, actorId, ct);
    }

    public async Task DeleteAsync(Guid leadId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var lead = await db.Leads
            .Include(l => l.FloorPlans)
            .FirstOrDefaultAsync(l => l.Id == leadId, ct)
                  ?? throw new NotFoundException("Lead", leadId);

        // The rooms and the image rows go with the lead by cascade; the images themselves sit
        // in storage, which no cascade reaches, so they are removed explicitly or they would
        // be orphaned there forever.
        foreach (var image in lead.FloorPlans)
        {
            await storage.DeleteAsync(image.BlobUrl, ct);
        }

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

        var lead = await LeadsWithRequirements(tracked: true)
                       .FirstOrDefaultAsync(l => l.Id == leadId, ct)
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

        return await MapDetailAsync(lead, LeadAccess.All, actorId, ct);
    }

    public async Task<LeadDetailResponse> UnassignAsync(Guid leadId, Guid actorId, CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        var lead = await LeadsWithRequirements(tracked: true)
                       .FirstOrDefaultAsync(l => l.Id == leadId, ct)
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

        return await MapDetailAsync(lead, LeadAccess.All, actorId, ct);
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

    // --- floor plans ---------------------------------------------------------------

    public async Task<LeadDetailResponse> UploadFloorPlanAsync(
        Guid leadId, string fileName, string? contentType, Stream content, Guid actorId, CancellationToken ct = default)
    {
        if (contentType is null || !AllowedFloorPlanContentTypes.Contains(contentType))
        {
            throw new BusinessRuleException(
                "A floor plan must be a PNG, JPEG, WebP or GIF image.", "unsupported_floor_plan_type");
        }

        if (content.CanSeek && content.Length > _options.MaxFloorPlanSizeInBytes)
        {
            throw new BusinessRuleException(
                $"A floor plan must be {_options.MaxFloorPlanSizeInBytes / (1024 * 1024)} MB or smaller.",
                "floor_plan_too_large");
        }

        // The lead's own assignee uploads its floor plans, same as they edit its other details.
        var (lead, access) = await LoadAccessibleLeadAsync(leadId, actorId, tracked: true, ct);

        if (lead.FloorPlans.Count >= MaxFloorPlansPerLead)
        {
            throw new BusinessRuleException(
                $"A lead can hold {MaxFloorPlansPerLead} floor plan images. Delete one before adding another.",
                "too_many_floor_plans");
        }

        var now = clock.UtcNow;
        var safeName = Path.GetFileName(fileName);
        var blobName = $"{leadId}/{Guid.NewGuid():N}-{safeName}";

        var blobUrl = await storage.UploadAsync(_options.FloorPlanContainer, blobName, content, contentType, ct);

        // Appended, never replacing: a flat is rarely one drawing, and the upload that used to
        // overwrite the previous image is exactly what this section stopped doing.
        var image = new LeadFloorPlanImage
        {
            LeadId = lead.Id,
            BlobUrl = blobUrl,
            FileName = safeName,
            ContentType = contentType,
            SizeInBytes = content.CanSeek ? content.Length : null,
            UploadedAt = now,
            SortOrder = lead.FloorPlans.Count == 0 ? 0 : lead.FloorPlans.Max(f => f.SortOrder) + 1,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        db.LeadFloorPlanImages.Add(image);

        lead.UpdatedAt = now;
        lead.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.LeadFloorPlanUploaded, nameof(Lead), lead.Id, actorId,
            new { fileName = safeName, contentType }, ct);

        await db.SaveChangesAsync(ct);

        // The navigation was loaded before the insert, so the new image is added to it by hand
        // rather than by re-reading the lead.
        lead.FloorPlans.Add(image);

        return await MapDetailAsync(lead, access, actorId, ct);
    }

    public async Task<LeadDetailResponse> DeleteFloorPlanAsync(
        Guid leadId, Guid imageId, Guid actorId, CancellationToken ct = default)
    {
        var (lead, access) = await LoadAccessibleLeadAsync(leadId, actorId, tracked: true, ct);

        var image = lead.FloorPlans.FirstOrDefault(f => f.Id == imageId)
            ?? throw new NotFoundException("Floor plan", imageId);

        var blobUrl = image.BlobUrl;
        var fileName = image.FileName;

        db.LeadFloorPlanImages.Remove(image);
        lead.FloorPlans.Remove(image);

        lead.UpdatedAt = clock.UtcNow;
        lead.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.LeadFloorPlanDeleted, nameof(Lead), lead.Id, actorId, new { fileName }, ct);

        await db.SaveChangesAsync(ct);

        // Only after the row is gone: a blob with no row is invisible, a row with no blob is a
        // broken image in the viewer.
        await storage.DeleteAsync(blobUrl, ct);

        return await MapDetailAsync(lead, access, actorId, ct);
    }

    public async Task<LeadFloorPlanContent?> OpenFloorPlanAsync(
        Guid leadId, Guid imageId, Guid actorId, CancellationToken ct = default)
    {
        // Same rule as GetAsync: an image is exactly as visible as the lead that owns it.
        var (lead, _) = await LoadAccessibleLeadAsync(leadId, actorId, tracked: false, ct);

        var image = lead.FloorPlans.FirstOrDefault(f => f.Id == imageId);

        if (image is null)
        {
            return null;
        }

        var stream = await storage.OpenReadAsync(image.BlobUrl, ct);

        if (stream is null)
        {
            return null;
        }

        return new LeadFloorPlanContent
        {
            Content = stream,
            FileName = image.FileName,
            ContentType = image.ContentType ?? "application/octet-stream"
        };
    }


    /// <summary>
    /// Orders the list. Ordering has to happen in SQL, before paging, or page 2 would be
    /// drawn from a differently-sorted set than page 1.
    /// </summary>
    private IQueryable<Lead> ApplySort(IQueryable<Lead> q, LeadQuery query)
    {
        var descending = query.SortDescending;

        return query.SortBy?.Trim().ToLowerInvariant() switch
        {
            "name" => descending
                ? q.OrderByDescending(l => l.FirstName).ThenByDescending(l => l.LastName)
                : q.OrderBy(l => l.FirstName).ThenBy(l => l.LastName),
            "property" => descending
                ? q.OrderByDescending(l => l.PropertyName)
                : q.OrderBy(l => l.PropertyName),
            "budget" => descending
                ? q.OrderByDescending(l => l.BudgetMin)
                : q.OrderBy(l => l.BudgetMin),
            "phase" => descending
                ? q.OrderByDescending(l => l.Phase)
                : q.OrderBy(l => l.Phase),
            // By assignee id, not name: the names live in the UsersAccess module and are
            // stitched on after paging, so SQL cannot order by them. This groups each
            // person's leads together without putting them in alphabetical order.
            "assignee" => descending
                ? q.OrderByDescending(l => l.AssignedToEmployeeId)
                : q.OrderBy(l => l.AssignedToEmployeeId),
            "floorplan" => descending
                ? q.OrderByDescending(l => l.FloorPlans.Any())
                : q.OrderBy(l => l.FloorPlans.Any()),
            "quotevalue" => descending
                ? q.OrderByDescending(l => db.Quotations
                    .Where(quote => quote.LeadId == l.Id && quote.Stage == QuotationStage.Initial)
                    .OrderByDescending(quote => quote.VersionNumber)
                    .Select(quote => (decimal?)quote.GrandTotal)
                    .FirstOrDefault())
                : q.OrderBy(l => db.Quotations
                    .Where(quote => quote.LeadId == l.Id && quote.Stage == QuotationStage.Initial)
                    .OrderByDescending(quote => quote.VersionNumber)
                    .Select(quote => (decimal?)quote.GrandTotal)
                    .FirstOrDefault()),
            "interested" => descending
                ? q.OrderByDescending(l => l.IsInterested)
                : q.OrderBy(l => l.IsInterested),
            "quotationshared" => descending
                ? q.OrderByDescending(l => l.QuotationSharedAt)
                : q.OrderBy(l => l.QuotationSharedAt),
            // Descending is a plain reverse, so the column header still toggles. Ascending is
            // the worklist order below, which is also what the list opens on.
            "nextfollowup" when descending => q.OrderByDescending(l => l.NextFollowUpDate),
            "nextfollowup" => FollowUpOrder(q),
            "createdat" => descending
                ? q.OrderByDescending(l => l.CreatedAt)
                : q.OrderBy(l => l.CreatedAt),
            _ => FollowUpOrder(q)
        };
    }

    /// <summary>
    /// The order the list opens on, and what "sort by follow-up" means going up: the call
    /// list. Leads nobody has touched yet lead it - they have no follow-up date to sort by and
    /// are the most perishable thing on the page - then everything else by when it is due,
    /// soonest (and overdue) first. Leads with no date at all sit at the bottom rather than
    /// ahead of today's calls, which is where SQL would otherwise put the nulls.
    /// </summary>
    private static IQueryable<Lead> FollowUpOrder(IQueryable<Lead> q) =>
        q.OrderByDescending(l => l.Phase == LeadPhase.NewClient)
            .ThenBy(l => l.NextFollowUpDate == null)
            .ThenBy(l => l.NextFollowUpDate)
            .ThenByDescending(l => l.CreatedAt);

    public async Task<IReadOnlyList<LeadPhaseCountResponse>> GetPhaseCountsAsync(
        Guid actorId, CancellationToken ct = default)
    {
        var access = await RequireAnyLeadAccessAsync(actorId, ct);

        var q = db.Leads.AsNoTracking().AsQueryable();

        // Counted over exactly the leads this caller can see, so the chips never advertise
        // work that clicking them would not show.
        if (access != LeadAccess.All)
        {
            q = q.Where(l => l.AssignedToEmployeeId == actorId);
        }

        return await q
            .GroupBy(l => l.Phase)
            .Select(g => new LeadPhaseCountResponse { Phase = g.Key, Count = g.Count() })
            .ToListAsync(ct);
    }

    // --- access -------------------------------------------------------------------

    /// <summary>
    /// How far into the module this caller reaches. manage_leads supersedes manage_own_leads,
    /// so it is checked first and nobody needs to hold both.
    /// </summary>
    private async Task<LeadAccess> GetAccessAsync(Guid actorId, CancellationToken ct)
    {
        if (await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageLeads, ct))
        {
            return LeadAccess.All;
        }

        if (await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageOwnLeads, ct))
        {
            return LeadAccess.Own;
        }

        return LeadAccess.None;
    }

    /// <summary>Rejects a caller who holds neither leads permission.</summary>
    private async Task<LeadAccess> RequireAnyLeadAccessAsync(Guid actorId, CancellationToken ct)
    {
        var access = await GetAccessAsync(actorId, ct);

        if (access == LeadAccess.None)
        {
            throw new ForbiddenException(
                $"This action requires the {PermissionCodes.ManageLeads} or " +
                $"{PermissionCodes.ManageOwnLeads} permission.");
        }

        return access;
    }

    /// <summary>
    /// Loads a lead the caller is allowed to touch, or reports it as missing.
    /// <para>
    /// A lead outside the caller's reach is 404 rather than 403 throughout: someone holding
    /// only manage_own_leads should not be able to discover that a colleague's lead exists by
    /// probing ids.
    /// </para>
    /// </summary>
    private async Task<(Lead Lead, LeadAccess Access)> LoadAccessibleLeadAsync(
        Guid leadId, Guid actorId, bool tracked, CancellationToken ct)
    {
        var access = await RequireAnyLeadAccessAsync(actorId, ct);

        var lead = await LeadsWithRequirements(tracked).FirstOrDefaultAsync(l => l.Id == leadId, ct)
                   ?? throw new NotFoundException("Lead", leadId);

        if (access != LeadAccess.All && lead.AssignedToEmployeeId != actorId)
        {
            throw new NotFoundException("Lead", leadId);
        }

        return (lead, access);
    }

    // --- helpers ------------------------------------------------------------------

    private IQueryable<Lead> LeadsWithRequirements(bool tracked)
    {
        var q = tracked ? db.Leads : db.Leads.AsNoTracking();

        return q
            .Include(l => l.FloorPlans)
            .Include(l => l.Rooms)
            .ThenInclude(r => r.Requirements);
    }

    /// <summary>
    /// Turns the submitted rooms into fresh entities. Blank rooms and blank items are dropped
    /// rather than rejected: the form always carries an empty "Others" row ready to be typed
    /// into, and an untouched one is not a validation error.
    /// </summary>
    private static List<LeadRoom> BuildRooms(
        IReadOnlyList<LeadRoomRequest> requests, DateTimeOffset now, Guid actorId)
    {
        var rooms = new List<LeadRoom>();
        var order = 0;

        foreach (var request in requests)
        {
            var roomName = request.RoomName?.Trim();

            if (string.IsNullOrWhiteSpace(roomName))
            {
                continue;
            }

            var room = new LeadRoom
            {
                RoomKey = request.RoomKey?.Trim() ?? string.Empty,
                RoomName = roomName,
                IsCustom = request.IsCustom,
                Notes = string.IsNullOrWhiteSpace(request.Notes) ? null : request.Notes.Trim(),
                SortOrder = order++,
                CreatedAt = now,
                CreatedByEmployeeId = actorId
            };

            var itemOrder = 0;

            foreach (var item in request.Requirements)
            {
                var itemName = item.ItemName?.Trim();

                if (string.IsNullOrWhiteSpace(itemName))
                {
                    continue;
                }

                room.Requirements.Add(new LeadRoomRequirement
                {
                    ItemKey = item.ItemKey?.Trim() ?? string.Empty,
                    ItemName = itemName,
                    IsCustom = item.IsCustom,
                    Quantity = item.Quantity,
                    Notes = string.IsNullOrWhiteSpace(item.Notes) ? null : item.Notes.Trim(),
                    SortOrder = itemOrder++,
                    CreatedAt = now,
                    CreatedByEmployeeId = actorId
                });
            }

            rooms.Add(room);
        }

        return rooms;
    }

    /// <summary>
    /// Rejects an inverted budget range. Worth checking on the server as well as in the form:
    /// the shorthand expansion happens client-side, and a mis-typed suffix (5L vs 5K) is
    /// exactly the mistake that produces a max below the min.
    /// </summary>
    /// <summary>Trims an optional field, turning whitespace-only input into null.</summary>
    private static string? Blank(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    private static void RequireBudgetOrder(decimal? min, decimal? max)
    {
        if (min is not null && max is not null && max < min)
        {
            throw new BusinessRuleException(
                "The maximum budget cannot be less than the minimum budget.", "budget_range_inverted");
        }
    }

    private async Task<LeadDetailResponse> MapDetailAsync(
        Lead lead, LeadAccess access, Guid actorId, CancellationToken ct)
    {
        var isManager = access == LeadAccess.All;

        // The assignee edits their own lead; everything structural - reassigning it, deleting
        // it, reading who handed it to them - stays with manage_leads.
        var canEdit = isManager || (access == LeadAccess.Own && lead.AssignedToEmployeeId == actorId);

        var ids = new[] { lead.AssignedToEmployeeId, lead.AssignedByEmployeeId, lead.CreatedByEmployeeId, lead.UpdatedByEmployeeId }
            .Where(id => id is not null)
            .Select(id => id!.Value);

        var summaries = await directory.GetSummariesAsync(ids, ct);

        string? NameOf(Guid? id) => id is not null && summaries.TryGetValue(id.Value, out var s) ? s.FullName : null;

        var response = new LeadDetailResponse
        {
            Id = lead.Id,
            CustomerCode = lead.CustomerCode,
            FirstName = lead.FirstName,
            LastName = lead.LastName ?? string.Empty,
            FullName = lead.FullName,
            Email = lead.Email,
            Phone = lead.Phone,
            SecondaryPhone = lead.SecondaryPhone,
            Notes = lead.Notes,
            PropertyName = lead.PropertyName,
            AddressLine1 = lead.AddressLine1,
            AddressLine2 = lead.AddressLine2,
            City = lead.City,
            PinCode = lead.PinCode,
            State = lead.State,
            PropertyType = lead.PropertyType,
            PropertySize = lead.PropertySize,
            PropertySizeUnit = lead.PropertySizeUnit,
            PropertyConfiguration = lead.PropertyConfiguration,
            BudgetMin = lead.BudgetMin,
            BudgetMax = lead.BudgetMax,
            Phase = lead.Phase,
            ContactedDate = lead.ContactedDate,
            NextFollowUpDate = lead.NextFollowUpDate,
            QuotationSharedAt = lead.QuotationSharedAt,
            IsInterested = lead.IsInterested,
            FloorPlans = MapFloorPlans(lead),
            Rooms = MapRooms(lead),
            AssignedToEmployeeId = lead.AssignedToEmployeeId,
            AssignedToName = NameOf(lead.AssignedToEmployeeId),
            CreatedAt = lead.CreatedAt,
            CreatedByName = NameOf(lead.CreatedByEmployeeId),
            UpdatedAt = lead.UpdatedAt,
            UpdatedByName = NameOf(lead.UpdatedByEmployeeId),
            Capabilities = new LeadCapabilities
            {
                CanEdit = canEdit,
                CanDelete = isManager,
                CanReassign = isManager,
                CanViewAssignmentHistory = isManager
            }
        };

        // Assignment provenance (who assigned it and when) is administrative detail: an owner
        // sees that the lead is theirs, but not the audit trail behind it.
        if (isManager)
        {
            response.AssignedByEmployeeId = lead.AssignedByEmployeeId;
            response.AssignedByName = NameOf(lead.AssignedByEmployeeId);
            response.AssignedAt = lead.AssignedAt;
        }

        return response;
    }

    private static List<LeadFloorPlanResponse> MapFloorPlans(Lead lead) =>
        [.. lead.FloorPlans
            .OrderBy(f => f.SortOrder)
            .ThenBy(f => f.UploadedAt)
            .Select(f => new LeadFloorPlanResponse
            {
                Id = f.Id,
                FileName = f.FileName,
                ContentType = f.ContentType,
                SizeInBytes = f.SizeInBytes,
                UploadedAt = f.UploadedAt,
                Url = $"/api/leads/{lead.Id}/floor-plans/{f.Id}"
            })];

    private static List<LeadRoomResponse> MapRooms(Lead lead) =>
        [.. lead.Rooms
            .OrderBy(r => r.SortOrder)
            .Select(r => new LeadRoomResponse
            {
                Id = r.Id,
                RoomKey = r.RoomKey,
                RoomName = r.RoomName,
                IsCustom = r.IsCustom,
                Notes = r.Notes,
                SortOrder = r.SortOrder,
                Requirements =
                [
                    .. r.Requirements
                        .OrderBy(i => i.SortOrder)
                        .Select(i => new LeadRoomRequirementResponse
                        {
                            Id = i.Id,
                            ItemKey = i.ItemKey,
                            ItemName = i.ItemName,
                            IsCustom = i.IsCustom,
                            Quantity = i.Quantity,
                            Notes = i.Notes,
                            SortOrder = i.SortOrder
                        })
                ]
            })];
}
