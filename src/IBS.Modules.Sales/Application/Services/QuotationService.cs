using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Application.Options;
using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Directories;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Notifications;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IBS.Modules.Sales.Application.Services;

/// <inheritdoc cref="IQuotationService" />
public sealed class QuotationService(
    ISalesDbContext db,
    IPermissionChecker permissions,
    IEmployeeDirectory directory,
    IQuotationPricingService pricing,
    IAuditLogWriter audit,
    IEmailDispatcher mail,
    IOptions<SalesOptions> options,
    IClock clock) : IQuotationService
{
    private readonly SalesOptions _options = options.Value;

    // --- Reads -------------------------------------------------------------------

    public async Task<IReadOnlyList<QuotationSummaryResponse>> ListAsync(
        Guid leadId, QuotationStage? stage, Guid actorId, CancellationToken ct = default)
    {
        await RequireLeadAccessAsync(leadId, actorId, ct);

        var q = db.Quotations.AsNoTracking().Where(x => x.LeadId == leadId);

        if (stage is not null)
        {
            q = q.Where(x => x.Stage == stage);
        }

        var rows = await q
            .OrderByDescending(x => x.Stage)
            .ThenByDescending(x => x.VersionNumber)
            .ToListAsync(ct);

        var names = await ResolveNamesAsync(rows.Select(r => r.PreparedByEmployeeId), ct);

        return rows.Select(r => new QuotationSummaryResponse
        {
            Id = r.Id,
            Stage = r.Stage,
            VersionNumber = r.VersionNumber,
            Status = r.Status,
            IsCurrent = r.IsCurrent,
            Title = r.Title,
            GrandTotal = r.GrandTotal,
            SharedAt = r.SharedAt,
            CreatedAt = r.CreatedAt,
            PreparedByName = NameOf(names, r.PreparedByEmployeeId)
        }).ToList();
    }

    public async Task<QuotationDetailResponse> GetAsync(
        Guid leadId, Guid quotationId, Guid actorId, CancellationToken ct = default)
    {
        await RequireLeadAccessAsync(leadId, actorId, ct);

        var quotation = await LoadAsync(leadId, quotationId, tracked: false, ct);

        return await MapDetailAsync(quotation, actorId, ct);
    }

    public async Task<QuotationDetailResponse?> GetCurrentAsync(
        Guid leadId, QuotationStage stage, Guid actorId, CancellationToken ct = default)
    {
        await RequireLeadAccessAsync(leadId, actorId, ct);

        // Prefers the flagged row but falls back to the highest version rather than insisting on
        // the flag. Deleting the current version promotes its successor in a second write, so
        // there is a moment - and, if that write ever fails, longer - where nothing is flagged.
        // Answering "no quotation" for a lead that visibly has one is the worse failure.
        var quotation = await QuotationsWithContents(tracked: false)
            .Where(x => x.LeadId == leadId && x.Stage == stage)
            .OrderByDescending(x => x.IsCurrent)
            .ThenByDescending(x => x.VersionNumber)
            .FirstOrDefaultAsync(ct);

        return quotation is null ? null : await MapDetailAsync(quotation, actorId, ct);
    }

    public async Task<QuotationCatalogResponse> GetCatalogAsync(Guid actorId, CancellationToken ct = default)
    {
        // Anyone who can open a lead can see the picker: it carries rates only indirectly, and
        // the tab is unusable without it.
        await RequireAnyLeadPermissionAsync(actorId, ct);

        var entries = await db.QuotationCatalogEntries
            .AsNoTracking()
            .Where(e => e.IsActive)
            .OrderBy(e => e.CategoryKey)
            .ThenBy(e => e.SortOrder)
            .ToListAsync(ct);

        var rates = await db.QuotationRates
            .AsNoTracking()
            .Where(r => r.IsActive)
            .ToListAsync(ct);

        var categories = entries
            .GroupBy(e => e.CategoryKey, StringComparer.Ordinal)
            .Select((group, index) => new QuotationCategoryResponse
            {
                CategoryKey = group.Key,
                CategoryName = group.First().CategoryName,
                SortOrder = index,
                Items = group
                    // One picker entry per item, with its variants folded in - which is exactly
                    // the shape the right-hand rail draws.
                    .GroupBy(e => e.ItemKey, StringComparer.Ordinal)
                    .Select(items => new QuotationCatalogItemResponse
                    {
                        ItemKey = items.Key,
                        ItemName = items.First().ItemName,
                        // The same item is seeded once per room it belongs to, so the rooms it
                        // serves are the distinct keys across those rows. An empty key among
                        // them means it is offered everywhere.
                        RoomKeys = items
                            .Select(i => i.RoomKey)
                            .Distinct(StringComparer.OrdinalIgnoreCase)
                            .ToList(),
                        PricingType = items.First().PricingType,
                        UnitOfMeasure = items.First().UnitOfMeasure,
                        BasePrice = items.First().BasePrice,
                        Variants = items
                            .Where(v => !string.IsNullOrEmpty(v.VariantKey))
                            .Select(v => new QuotationCatalogVariantResponse
                            {
                                VariantKey = v.VariantKey,
                                VariantName = v.VariantName
                            })
                            .DistinctBy(v => v.VariantKey, StringComparer.OrdinalIgnoreCase)
                            .ToList()
                    })
                    .ToList()
            })
            .ToList();

        // Offered materials come from the rate card rather than a fixed list, so the dropdowns
        // can only ever suggest a specification something is actually priced for.
        return new QuotationCatalogResponse
        {
            Categories = categories,
            Rates = rates
                .Where(r => r.EffectiveFrom <= DateOnly.FromDateTime(clock.UtcNow.UtcDateTime))
                .Select(r => new QuotationRateResponse
                {
                    ItemKey = r.ItemKey,
                    VariantKey = r.VariantKey,
                    CarcassMaterial = r.CarcassMaterial,
                    ShutterMaterial = r.ShutterMaterial,
                    Finish = r.Finish,
                    UnitOfMeasure = r.UnitOfMeasure,
                    RatePerUnit = r.RatePerUnit
                })
                .ToList(),
            CarcassMaterials = DistinctValues(rates.Select(r => r.CarcassMaterial)),
            ShutterMaterials = DistinctValues(rates.Select(r => r.ShutterMaterial)),
            Finishes = DistinctValues(rates.Select(r => r.Finish)),
            DefaultGstRatePercent = _options.DefaultGstRatePercent
        };
    }

    // --- Writes ------------------------------------------------------------------

    public async Task<QuotationDetailResponse> CreateAsync(
        Guid leadId, CreateQuotationRequest request, Guid actorId, CancellationToken ct = default)
    {
        var lead = await RequireLeadAccessAsync(leadId, actorId, ct);
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageQuotations, ct);

        // Any quotation at this stage, not merely a flagged-current one. Keying off the flag
        // would let a second v1 be created whenever nothing happened to be flagged, and that
        // collides on the (LeadId, Stage, VersionNumber) index instead of reporting the conflict.
        var exists = await db.Quotations
            .AnyAsync(x => x.LeadId == leadId && x.Stage == request.Stage, ct);

        if (exists)
        {
            throw new ConflictException(
                "This lead already has a quotation at this stage. Open it and save a new version instead.");
        }

        var now = clock.UtcNow;

        var quotation = new Quotation
        {
            LeadId = leadId,
            Stage = request.Stage,
            VersionNumber = 1,
            IsCurrent = true,
            Status = QuotationStatus.Draft,
            Title = Trimmed(request.Title),
            GstRatePercent = _options.DefaultGstRatePercent,
            PreparedByEmployeeId = actorId,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        if (request.SeedRoomsFromRequirements)
        {
            // Copied, not linked. From here the quotation owns its room list, and removing a
            // room from it must leave the client's brief exactly as it was.
            var briefRooms = await db.LeadRooms
                .AsNoTracking()
                .Where(r => r.LeadId == leadId)
                .OrderBy(r => r.SortOrder)
                .ToListAsync(ct);

            var order = 0;

            foreach (var room in briefRooms)
            {
                quotation.Rooms.Add(new QuotationRoom
                {
                    RoomKey = room.RoomKey,
                    RoomName = room.RoomName,
                    IsCustom = room.IsCustom,
                    SourceLeadRoomId = room.Id,
                    SortOrder = order++,
                    CreatedAt = now,
                    CreatedByEmployeeId = actorId
                });
            }
        }

        pricing.RecalculateTotals(quotation);

        db.Quotations.Add(quotation);
        await audit.WriteAsync(
            AuditActions.QuotationCreated, nameof(Quotation), quotation.Id, actorId,
            new { leadId, stage = quotation.Stage.ToString(), rooms = quotation.Rooms.Count }, ct);

        await db.SaveChangesAsync(ct);

        _ = lead;
        return await MapDetailAsync(quotation, actorId, ct);
    }

    public async Task<QuotationDetailResponse> SaveAsync(
        Guid leadId, Guid quotationId, SaveQuotationRequest request, Guid actorId,
        CancellationToken ct = default)
    {
        await RequireLeadAccessAsync(leadId, actorId, ct);
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageQuotations, ct);

        var quotation = await LoadAsync(leadId, quotationId, tracked: true, ct);
        RequireEditable(quotation);

        var now = clock.UtcNow;

        quotation.Title = Trimmed(request.Title);
        quotation.DiscountPercent = request.DiscountPercent;
        quotation.DiscountAmount = request.DiscountPercent is null ? request.DiscountAmount ?? 0m : 0m;
        quotation.TransportCharges = request.TransportCharges;
        quotation.InstallationCharges = request.InstallationCharges;

        if (request.GstRatePercent is { } gst)
        {
            quotation.GstRatePercent = gst;
        }

        // The catalogue supplies each line's name, pricing type and unit of measure. Taking them
        // from the request instead would let a caller quietly bill a square-foot item by the
        // running foot, which no amount of validation elsewhere would catch.
        var catalog = await LoadCatalogLookupAsync(request, ct);
        var rateCard = await pricing.LoadRateCardAsync(
            request.Rooms.SelectMany(r => r.LineItems).Select(i => i.ItemKey).Distinct().ToList(), ct);

        var rooms = BuildRooms(request, catalog, rateCard, now, actorId);

        // Removed and added through the DbSet, not by mutating the navigation alone.
        //
        // AuditableEntity assigns Id in its initialiser, so a brand-new room or line already has
        // its key set. Discovered through a tracked parent's collection, EF reads that as an
        // entity it has seen before and marks it Modified - and then issues an UPDATE against a
        // row that does not exist, which fails as a concurrency conflict rather than as anything
        // that names the real problem. Add on the DbSet marks the whole graph Added outright.
        //
        // Create and "save as new version" avoid this by accident: both Add a whole new Quotation
        // root, and that traversal marks everything under it Added. Only this path, which mutates
        // an already-tracked aggregate, was exposed.
        db.QuotationRooms.RemoveRange(quotation.Rooms.ToList());
        quotation.Rooms.Clear();

        foreach (var room in rooms)
        {
            db.QuotationRooms.Add(room);
            quotation.Rooms.Add(room);
        }

        pricing.RecalculateTotals(quotation);

        quotation.UpdatedAt = now;
        quotation.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.QuotationUpdated, nameof(Quotation), quotation.Id, actorId,
            new { leadId, version = quotation.VersionNumber, quotation.GrandTotal }, ct);

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(quotation, actorId, ct);
    }

    public async Task<QuotationDetailResponse> CreateVersionAsync(
        Guid leadId, Guid quotationId, CreateQuotationVersionRequest request, Guid actorId,
        CancellationToken ct = default)
    {
        await RequireLeadAccessAsync(leadId, actorId, ct);
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageQuotations, ct);

        var source = await LoadAsync(leadId, quotationId, tracked: true, ct);
        var now = clock.UtcNow;

        var nextNumber = await db.Quotations
            .Where(x => x.LeadId == leadId && x.Stage == source.Stage)
            .MaxAsync(x => (int?)x.VersionNumber, ct) ?? 0;

        var clone = new Quotation
        {
            LeadId = leadId,
            Stage = source.Stage,
            VersionNumber = nextNumber + 1,
            ClonedFromQuotationId = source.Id,
            IsCurrent = true,
            Status = QuotationStatus.Draft,
            Title = Trimmed(request.Title),
            DiscountPercent = source.DiscountPercent,
            DiscountAmount = source.DiscountAmount,
            GstRatePercent = source.GstRatePercent,
            TransportCharges = source.TransportCharges,
            InstallationCharges = source.InstallationCharges,
            PreparedByEmployeeId = actorId,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        foreach (var room in source.Rooms.OrderBy(r => r.SortOrder))
        {
            var copy = new QuotationRoom
            {
                RoomKey = room.RoomKey,
                RoomName = room.RoomName,
                IsCustom = room.IsCustom,
                SourceLeadRoomId = room.SourceLeadRoomId,
                DefaultCarcassMaterial = room.DefaultCarcassMaterial,
                DefaultShutterMaterial = room.DefaultShutterMaterial,
                DefaultFinish = room.DefaultFinish,
                Notes = room.Notes,
                SortOrder = room.SortOrder,
                CreatedAt = now,
                CreatedByEmployeeId = actorId
            };

            foreach (var line in room.LineItems.OrderBy(i => i.SortOrder))
            {
                // Amounts are copied rather than recomputed. A new version starts as an exact
                // duplicate of what the client last saw; if the rate card has moved since, that
                // shows up when the estimator edits the line, not silently on open.
                copy.LineItems.Add(new QuotationLineItem
                {
                    CategoryKey = line.CategoryKey,
                    CategoryName = line.CategoryName,
                    ItemKey = line.ItemKey,
                    ItemName = line.ItemName,
                    VariantKey = line.VariantKey,
                    IsCustom = line.IsCustom,
                    SortOrder = line.SortOrder,
                    PricingType = line.PricingType,
                    CarcassMaterial = line.CarcassMaterial,
                    ShutterMaterial = line.ShutterMaterial,
                    Finish = line.Finish,
                    WidthFeet = line.WidthFeet,
                    HeightFeet = line.HeightFeet,
                    DepthFeet = line.DepthFeet,
                    UnitOfMeasure = line.UnitOfMeasure,
                    BillableQuantity = line.BillableQuantity,
                    Quantity = line.Quantity,
                    Rate = line.Rate,
                    IsRateOverridden = line.IsRateOverridden,
                    BaseAmount = line.BaseAmount,
                    HardwareAmount = line.HardwareAmount,
                    AccessoryAmount = line.AccessoryAmount,
                    Amount = line.Amount,
                    Notes = line.Notes,
                    InternalNotes = line.InternalNotes,
                    CreatedAt = now,
                    CreatedByEmployeeId = actorId
                });
            }

            clone.Rooms.Add(copy);
        }

        pricing.RecalculateTotals(clone);

        // The old version stops being the one the workspace opens. An approved version keeps its
        // status - that was the client's decision, and a later draft does not undo it.
        source.IsCurrent = false;

        if (source.Status != QuotationStatus.Approved)
        {
            source.Status = QuotationStatus.Superseded;
        }

        source.UpdatedAt = now;
        source.UpdatedByEmployeeId = actorId;

        // Stood down first, in its own save. The clone arrives flagged current, and if EF were to
        // insert it before clearing the flag here, two rows would be current at once and
        // IX_Quotations_LeadId_Stage_Current would reject the batch - the same ordering trap that
        // DeleteAsync hits.
        await db.SaveChangesAsync(ct);

        db.Quotations.Add(clone);

        await audit.WriteAsync(
            AuditActions.QuotationVersionCreated, nameof(Quotation), clone.Id, actorId,
            new { leadId, from = source.VersionNumber, to = clone.VersionNumber }, ct);

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(clone, actorId, ct);
    }

    public async Task DeleteAsync(Guid leadId, Guid quotationId, Guid actorId, CancellationToken ct = default)
    {
        await RequireLeadAccessAsync(leadId, actorId, ct);
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ManageQuotations, ct);

        var quotation = await LoadAsync(leadId, quotationId, tracked: true, ct);

        if (quotation.Status != QuotationStatus.Draft)
        {
            throw new ConflictException(
                "Only a draft can be deleted. A version that has been issued is the record of what the client was sent.");
        }

        var wasCurrent = quotation.IsCurrent;
        var stage = quotation.Stage;

        db.Quotations.Remove(quotation);

        await audit.WriteAsync(
            AuditActions.QuotationDeleted, nameof(Quotation), quotation.Id, actorId,
            new { leadId, version = quotation.VersionNumber }, ct);

        // Saved on its own, before the successor is promoted. Both writes touch
        // IX_Quotations_LeadId_Stage_Current, and EF gives no guarantee that it will run the
        // delete before the update - in practice it runs the update first, which leaves two rows
        // flagged current for a moment and trips the index. Ordering them by hand is the fix.
        await db.SaveChangesAsync(ct);

        if (!wasCurrent) return;

        // Something has to be current, or the tab opens its empty state on a lead that
        // demonstrably has quotations. The highest surviving version takes over.
        var successor = await db.Quotations
            .Where(x => x.LeadId == leadId && x.Stage == stage)
            .OrderByDescending(x => x.VersionNumber)
            .FirstOrDefaultAsync(ct);

        if (successor is null) return;

        successor.IsCurrent = true;
        successor.UpdatedAt = clock.UtcNow;
        successor.UpdatedByEmployeeId = actorId;

        await db.SaveChangesAsync(ct);
    }

    public async Task<QuotationDetailResponse> RecordDecisionAsync(
        Guid leadId, Guid quotationId, RecordQuotationDecisionRequest request, Guid actorId,
        CancellationToken ct = default)
    {
        var lead = await RequireLeadAccessAsync(leadId, actorId, ct, tracked: true);
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ApproveQuotations, ct);

        if (request.Status is not (QuotationStatus.Approved or QuotationStatus.RevisionRequired))
        {
            throw new BusinessRuleException(
                "A decision is either an approval or a request for revision.", "quotation_decision");
        }

        var quotation = await LoadAsync(leadId, quotationId, tracked: true, ct);

        if (quotation.Status is not (QuotationStatus.Shared or QuotationStatus.RevisionRequired))
        {
            throw new ConflictException("Only a quotation that has been sent to the client can have a decision recorded.");
        }

        var now = clock.UtcNow;
        quotation.Status = request.Status;

        if (request.Status == QuotationStatus.Approved)
        {
            quotation.ApprovedAt = now;
            quotation.ApprovedByEmployeeId = actorId;
        }

        quotation.UpdatedAt = now;
        quotation.UpdatedByEmployeeId = actorId;

        lead.Phase = PhaseFor(request.Status);
        lead.UpdatedAt = now;
        lead.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            request.Status == QuotationStatus.Approved
                ? AuditActions.QuotationApproved
                : AuditActions.QuotationRevisionRequested,
            nameof(Quotation), quotation.Id, actorId,
            new { leadId, version = quotation.VersionNumber, notes = Trimmed(request.Notes) }, ct);

        await db.SaveChangesAsync(ct);

        return await MapDetailAsync(quotation, actorId, ct);
    }

    // --- Building the room graph -------------------------------------------------

    private List<QuotationRoom> BuildRooms(
        SaveQuotationRequest request,
        IReadOnlyDictionary<(string ItemKey, string VariantKey), QuotationCatalogEntry> catalog,
        RateCard rateCard,
        DateTimeOffset now,
        Guid actorId)
    {
        var rooms = new List<QuotationRoom>();
        var roomOrder = 0;

        foreach (var roomRequest in request.Rooms)
        {
            var roomName = roomRequest.RoomName?.Trim();

            if (string.IsNullOrWhiteSpace(roomName)) continue;

            var room = new QuotationRoom
            {
                RoomKey = roomRequest.RoomKey?.Trim() ?? string.Empty,
                RoomName = roomName,
                IsCustom = roomRequest.IsCustom,
                SourceLeadRoomId = roomRequest.SourceLeadRoomId,
                DefaultCarcassMaterial = Trimmed(roomRequest.DefaultCarcassMaterial),
                DefaultShutterMaterial = Trimmed(roomRequest.DefaultShutterMaterial),
                DefaultFinish = Trimmed(roomRequest.DefaultFinish),
                Notes = Trimmed(roomRequest.Notes),
                SortOrder = roomOrder++,
                CreatedAt = now,
                CreatedByEmployeeId = actorId
            };

            var lineOrder = 0;

            foreach (var lineRequest in roomRequest.LineItems)
            {
                var line = BuildLine(lineRequest, catalog, rateCard, lineOrder, now, actorId);

                if (line is null) continue;

                lineOrder++;
                room.LineItems.Add(line);
            }

            rooms.Add(room);
        }

        return rooms;
    }

    private QuotationLineItem? BuildLine(
        SaveQuotationLineItemRequest request,
        IReadOnlyDictionary<(string ItemKey, string VariantKey), QuotationCatalogEntry> catalog,
        RateCard rateCard,
        int sortOrder,
        DateTimeOffset now,
        Guid actorId)
    {
        var itemKey = request.ItemKey?.Trim() ?? string.Empty;
        var variantKey = request.VariantKey?.Trim() ?? string.Empty;

        catalog.TryGetValue((itemKey, variantKey), out var entry);

        // A line that is neither in the catalogue nor flagged custom has nothing to price it by.
        // Dropping it silently is wrong, but so is failing the whole save over one stale row -
        // it is treated as custom, so it survives the round trip visibly unpriced.
        var isCustom = request.IsCustom || entry is null;

        var name = Trimmed(request.ItemName)
                   ?? (entry is null
                       ? null
                       : string.IsNullOrEmpty(entry.VariantName)
                           ? entry.ItemName
                           : $"{entry.ItemName} - {entry.VariantName}");

        if (string.IsNullOrWhiteSpace(name)) return null;

        var line = new QuotationLineItem
        {
            CategoryKey = entry?.CategoryKey ?? request.CategoryKey?.Trim() ?? "custom-work",
            CategoryName = entry?.CategoryName ?? "Custom work",
            ItemKey = itemKey,
            ItemName = name,
            VariantKey = variantKey,
            IsCustom = isCustom,
            SortOrder = sortOrder,
            PricingType = isCustom
                ? QuotationPricingType.Custom
                : entry!.PricingType,
            UnitOfMeasure = entry?.UnitOfMeasure ?? QuotationUnitOfMeasure.Number,
            CarcassMaterial = Trimmed(request.CarcassMaterial),
            ShutterMaterial = Trimmed(request.ShutterMaterial),
            Finish = Trimmed(request.Finish),
            WidthFeet = request.WidthFeet,
            HeightFeet = request.HeightFeet,
            DepthFeet = request.DepthFeet,
            Quantity = request.Quantity,
            HardwareAmount = request.HardwareAmount,
            AccessoryAmount = request.AccessoryAmount,
            Notes = Trimmed(request.Notes),
            InternalNotes = Trimmed(request.InternalNotes),
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        pricing.PriceLine(line, rateCard, request.RateOverride, entry?.BasePrice);

        return line;
    }

    private async Task<IReadOnlyDictionary<(string, string), QuotationCatalogEntry>> LoadCatalogLookupAsync(
        SaveQuotationRequest request, CancellationToken ct)
    {
        var itemKeys = request.Rooms
            .SelectMany(r => r.LineItems)
            .Select(i => i.ItemKey?.Trim() ?? string.Empty)
            .Where(k => k.Length > 0)
            .Distinct()
            .ToList();

        if (itemKeys.Count == 0)
        {
            return new Dictionary<(string, string), QuotationCatalogEntry>();
        }

        var entries = await db.QuotationCatalogEntries
            .AsNoTracking()
            .Where(e => itemKeys.Contains(e.ItemKey))
            .ToListAsync(ct);

        // Keyed on item and variant only: the same item offered in several rooms is the same
        // product at the same rate, so the first row wins rather than the room deciding.
        return entries
            .GroupBy(e => (e.ItemKey, e.VariantKey))
            .ToDictionary(g => g.Key, g => g.First());
    }

    // --- Access ------------------------------------------------------------------

    /// <summary>
    /// Loads the lead, if this caller is allowed to reach it. A lead outside their reach is
    /// reported as missing rather than forbidden, matching how the leads service behaves - the
    /// alternative lets someone probe ids to learn which leads exist.
    /// </summary>
    private async Task<Lead> RequireLeadAccessAsync(
        Guid leadId, Guid actorId, CancellationToken ct, bool tracked = false)
    {
        var canSeeAll = await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageLeads, ct);

        if (!canSeeAll && !await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageOwnLeads, ct))
        {
            throw new ForbiddenException(
                $"This action requires the {PermissionCodes.ManageLeads} or " +
                $"{PermissionCodes.ManageOwnLeads} permission.");
        }

        var query = tracked ? db.Leads : db.Leads.AsNoTracking();
        var lead = await query.FirstOrDefaultAsync(l => l.Id == leadId, ct)
                   ?? throw new NotFoundException("Lead", leadId);

        if (!canSeeAll && lead.AssignedToEmployeeId != actorId)
        {
            throw new NotFoundException("Lead", leadId);
        }

        return lead;
    }

    private async Task RequireAnyLeadPermissionAsync(Guid actorId, CancellationToken ct)
    {
        var allowed = await permissions.HasAnyPermissionAsync(
            actorId, [PermissionCodes.ManageLeads, PermissionCodes.ManageOwnLeads], ct);

        if (!allowed)
        {
            throw new ForbiddenException(
                $"This action requires the {PermissionCodes.ManageLeads} or " +
                $"{PermissionCodes.ManageOwnLeads} permission.");
        }
    }

    private static void RequireEditable(Quotation quotation)
    {
        if (!quotation.IsEditable)
        {
            throw new ConflictException(
                "This version has already been issued and can no longer be edited. Save it as a new version to make changes.");
        }
    }

    // --- Loading and mapping -----------------------------------------------------

    private IQueryable<Quotation> QuotationsWithContents(bool tracked)
    {
        var query = tracked ? db.Quotations : db.Quotations.AsNoTracking();

        return query
            .Include(q => q.Rooms.OrderBy(r => r.SortOrder))
            .ThenInclude(r => r.LineItems.OrderBy(i => i.SortOrder))
            .Include(q => q.Documents);
    }

    private async Task<Quotation> LoadAsync(Guid leadId, Guid quotationId, bool tracked, CancellationToken ct)
    {
        return await QuotationsWithContents(tracked)
                   .FirstOrDefaultAsync(x => x.Id == quotationId && x.LeadId == leadId, ct)
               ?? throw new NotFoundException("Quotation", quotationId);
    }

    private async Task<QuotationDetailResponse> MapDetailAsync(
        Quotation quotation, Guid actorId, CancellationToken ct)
    {
        var canEdit = await permissions.HasPermissionAsync(actorId, PermissionCodes.ManageQuotations, ct);
        var canIssue = await permissions.HasPermissionAsync(actorId, PermissionCodes.ApproveQuotations, ct);

        var ids = quotation.Documents
            .Select(d => d.GeneratedByEmployeeId)
            .Append(quotation.PreparedByEmployeeId);

        var names = await ResolveNamesAsync(ids, ct);

        return new QuotationDetailResponse
        {
            Id = quotation.Id,
            LeadId = quotation.LeadId,
            Stage = quotation.Stage,
            VersionNumber = quotation.VersionNumber,
            ClonedFromQuotationId = quotation.ClonedFromQuotationId,
            IsCurrent = quotation.IsCurrent,
            Status = quotation.Status,
            Title = quotation.Title,
            Subtotal = quotation.Subtotal,
            DiscountPercent = quotation.DiscountPercent,
            DiscountAmount = quotation.DiscountAmount,
            TaxableValue = quotation.TaxableValue,
            GstRatePercent = quotation.GstRatePercent,
            GstAmount = quotation.GstAmount,
            TransportCharges = quotation.TransportCharges,
            InstallationCharges = quotation.InstallationCharges,
            GrandTotal = quotation.GrandTotal,
            SharedAt = quotation.SharedAt,
            ApprovedAt = quotation.ApprovedAt,
            CreatedAt = quotation.CreatedAt,
            PreparedByName = NameOf(names, quotation.PreparedByEmployeeId),
            Rooms = quotation.Rooms
                .OrderBy(r => r.SortOrder)
                .Select(r => MapRoom(r, canEdit))
                .ToList(),
            Documents = quotation.Documents
                .OrderByDescending(d => d.GeneratedAt)
                .Select(d => new QuotationDocumentResponse
                {
                    Id = d.Id,
                    FileName = d.FileName,
                    SizeInBytes = d.SizeInBytes,
                    GeneratedAt = d.GeneratedAt,
                    GeneratedByName = NameOf(names, d.GeneratedByEmployeeId),
                    IsSent = d.IsSent
                })
                .ToList(),
            Capabilities = new QuotationCapabilities
            {
                CanEdit = canEdit && quotation.IsEditable,
                CanCreateVersion = canEdit,
                CanDelete = canEdit && quotation.Status == QuotationStatus.Draft,
                CanGeneratePdf = canEdit || canIssue,
                CanSendToClient = canIssue,
                CanRecordDecision = canIssue && quotation.Status
                    is QuotationStatus.Shared or QuotationStatus.RevisionRequired,
                EmailDeliveryEnabled = mail.DeliversMail
            }
        };
    }

    private static QuotationRoomResponse MapRoom(QuotationRoom room, bool includeInternalNotes) => new()
    {
        Id = room.Id,
        RoomKey = room.RoomKey,
        RoomName = room.RoomName,
        IsCustom = room.IsCustom,
        SourceLeadRoomId = room.SourceLeadRoomId,
        DefaultCarcassMaterial = room.DefaultCarcassMaterial,
        DefaultShutterMaterial = room.DefaultShutterMaterial,
        DefaultFinish = room.DefaultFinish,
        Notes = room.Notes,
        SortOrder = room.SortOrder,
        RoomTotal = room.RoomTotal,
        LineItems = room.LineItems
            .OrderBy(i => i.SortOrder)
            .Select(i => new QuotationLineItemResponse
            {
                Id = i.Id,
                CategoryKey = i.CategoryKey,
                CategoryName = i.CategoryName,
                ItemKey = i.ItemKey,
                ItemName = i.ItemName,
                VariantKey = i.VariantKey,
                IsCustom = i.IsCustom,
                SortOrder = i.SortOrder,
                PricingType = i.PricingType,
                CarcassMaterial = i.CarcassMaterial,
                ShutterMaterial = i.ShutterMaterial,
                Finish = i.Finish,
                WidthFeet = i.WidthFeet,
                HeightFeet = i.HeightFeet,
                DepthFeet = i.DepthFeet,
                UnitOfMeasure = i.UnitOfMeasure,
                BillableQuantity = i.BillableQuantity,
                Quantity = i.Quantity,
                Rate = i.Rate,
                IsRateOverridden = i.IsRateOverridden,
                BaseAmount = i.BaseAmount,
                HardwareAmount = i.HardwareAmount,
                AccessoryAmount = i.AccessoryAmount,
                Amount = i.Amount,
                Notes = i.Notes,
                InternalNotes = includeInternalNotes ? i.InternalNotes : null
            })
            .ToList()
    };

    private async Task<IReadOnlyDictionary<Guid, EmployeeSummary>> ResolveNamesAsync(
        IEnumerable<Guid?> ids, CancellationToken ct)
    {
        var distinct = ids.Where(id => id is not null).Select(id => id!.Value).Distinct().ToList();

        return distinct.Count == 0
            ? new Dictionary<Guid, EmployeeSummary>()
            : await directory.GetSummariesAsync(distinct, ct);
    }

    private static string? NameOf(IReadOnlyDictionary<Guid, EmployeeSummary> names, Guid? id) =>
        id is not null && names.TryGetValue(id.Value, out var summary) ? summary.FullName : null;

    /// <summary>
    /// Where a decision leaves the lead. The stage no longer matters - the phases are flat, and
    /// a client approving a quotation is Interested whichever of the two they approved.
    /// </summary>
    private static LeadPhase PhaseFor(QuotationStatus status) =>
        status == QuotationStatus.Approved
            ? LeadPhase.Interested
            : LeadPhase.QuotationDiscussion;

    private static List<string> DistinctValues(IEnumerable<string> values) =>
        values
            .Where(v => !string.IsNullOrWhiteSpace(v))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(v => v, StringComparer.OrdinalIgnoreCase)
            .ToList();

    private static string? Trimmed(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
