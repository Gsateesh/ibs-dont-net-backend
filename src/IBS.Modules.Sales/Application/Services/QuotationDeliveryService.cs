using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Application.Dtos;
using IBS.Modules.Sales.Application.Options;
using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Notifications;
using IBS.SharedKernel.Security;
using IBS.SharedKernel.Storage;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuestPDF.Fluent;

namespace IBS.Modules.Sales.Application.Services;

/// <summary>
/// Producing a quotation's PDF and getting it to the client.
/// </summary>
/// <remarks>
/// Split from <see cref="IQuotationService"/> so that building a quotation stays free of
/// storage and mail concerns - the two have different failure modes and different permissions.
/// </remarks>
public interface IQuotationDeliveryService
{
    /// <summary>Renders a version, stores the file against it, and hands back the bytes.</summary>
    Task<QuotationFileContent> GeneratePdfAsync(
        Guid leadId, Guid quotationId, Guid actorId, CancellationToken ct = default);

    /// <summary>Streams a previously generated document back.</summary>
    Task<QuotationFileContent> GetDocumentAsync(
        Guid leadId, Guid quotationId, Guid documentId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Emails the version to the client with its PDF attached, freezes it, and moves the lead on.
    /// </summary>
    Task<SendQuotationResult> SendAsync(
        Guid leadId, Guid quotationId, SendQuotationRequest request, Guid actorId,
        CancellationToken ct = default);
}

/// <summary>A generated file and enough about it to serve as an HTTP response.</summary>
public sealed class QuotationFileContent
{
    public required byte[] Content { get; init; }

    public required string FileName { get; init; }

    public string ContentType { get; init; } = "application/pdf";
}

/// <summary>What happened when a version was sent.</summary>
public sealed class SendQuotationResult
{
    public required QuotationDetailResponse Quotation { get; init; }

    /// <summary>False when the development dispatcher suppressed the message.</summary>
    public bool Delivered { get; init; }

    public string? Recipient { get; init; }

    /// <summary>Populated when the provider refused it. The version is still marked as issued.</summary>
    public string? DeliveryError { get; init; }
}

/// <inheritdoc cref="IQuotationDeliveryService" />
public sealed class QuotationDeliveryService(
    ISalesDbContext db,
    IQuotationService quotations,
    IPermissionChecker permissions,
    IFileStorage storage,
    IEmailDispatcher mail,
    IAuditLogWriter audit,
    IOptions<SalesOptions> options,
    IClock clock) : IQuotationDeliveryService
{
    private readonly SalesOptions _options = options.Value;

    public async Task<QuotationFileContent> GeneratePdfAsync(
        Guid leadId, Guid quotationId, Guid actorId, CancellationToken ct = default)
    {
        await RequireAnyQuotationPermissionAsync(actorId, ct);

        var (quotation, lead) = await LoadForRenderAsync(leadId, quotationId, tracked: true, ct);
        var file = await RenderAndStoreAsync(quotation, lead, actorId, ct);

        await audit.WriteAsync(
            AuditActions.QuotationPdfGenerated, nameof(Quotation), quotation.Id, actorId,
            new { leadId, version = quotation.VersionNumber }, ct);

        await db.SaveChangesAsync(ct);

        return file;
    }

    public async Task<QuotationFileContent> GetDocumentAsync(
        Guid leadId, Guid quotationId, Guid documentId, Guid actorId, CancellationToken ct = default)
    {
        await RequireAnyQuotationPermissionAsync(actorId, ct);

        // Goes through the service so the lead-level access check is the same one every other
        // read performs - a document is exactly as sensitive as the quotation it renders.
        await quotations.GetAsync(leadId, quotationId, actorId, ct);

        var document = await db.QuotationDocuments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == documentId && d.QuotationId == quotationId, ct)
            ?? throw new NotFoundException("Quotation document", documentId);

        // Streamed through the API rather than handed out as a blob URL, so the permission check
        // above actually covers the file - the same rule the lead's floor plan follows.
        await using var stream = await storage.OpenReadAsync(document.BlobUrl, ct)
                                 ?? throw new NotFoundException("Quotation document", documentId);

        using var buffer = new MemoryStream();
        await stream.CopyToAsync(buffer, ct);

        return new QuotationFileContent
        {
            Content = buffer.ToArray(),
            FileName = document.FileName,
            ContentType = document.ContentType
        };
    }

    public async Task<SendQuotationResult> SendAsync(
        Guid leadId, Guid quotationId, SendQuotationRequest request, Guid actorId,
        CancellationToken ct = default)
    {
        await permissions.RequirePermissionAsync(actorId, PermissionCodes.ApproveQuotations, ct);

        var (quotation, lead) = await LoadForRenderAsync(leadId, quotationId, tracked: true, ct);

        if (quotation.Status == QuotationStatus.Approved)
        {
            throw new ConflictException("This version has already been approved by the client.");
        }

        var recipient = (request.ToEmail ?? lead.Email)?.Trim();

        if (string.IsNullOrWhiteSpace(recipient))
        {
            throw new BusinessRuleException(
                "There is no email address to send this quotation to.", "quotation_no_recipient");
        }

        if (quotation.Rooms.Sum(r => r.LineItems.Count) == 0)
        {
            throw new BusinessRuleException(
                "This quotation has no priced items yet.", "quotation_empty");
        }

        var now = clock.UtcNow;
        var file = await RenderAndStoreAsync(quotation, lead, actorId, ct, markAsSent: true);

        var subject = string.IsNullOrWhiteSpace(request.Subject)
            ? $"{_options.StudioName} - quotation for {lead.PropertyName}".Trim()
            : request.Subject.Trim();

        var result = await mail.SendAsync(
            new EmailMessage
            {
                ToEmail = recipient,
                ToName = lead.FullName,
                Subject = subject,
                HtmlBody = BuildBody(lead, quotation, request.Message),
                Kind = "quotation.sent",
                RelatedEntityType = nameof(Quotation),
                RelatedEntityId = quotation.Id,
                SentByEmployeeId = actorId,
                Attachments =
                [
                    new EmailAttachment
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        Content = file.Content
                    }
                ]
            }, ct);

        // The version is marked as issued even when the provider refused it. The PDF was
        // generated and the attempt is on the mail log; leaving it editable would let the
        // numbers drift away from a document that may well have gone out after all.
        quotation.Status = QuotationStatus.Shared;
        quotation.SharedAt = now;
        quotation.SharedByEmployeeId = actorId;
        quotation.UpdatedAt = now;
        quotation.UpdatedByEmployeeId = actorId;

        // The same phase whichever stage went out: the phase list no longer runs a separate
        // track for the final quotation, and "the client is looking at a quotation" is the
        // fact either way.
        var lead0 = await db.Leads.FirstAsync(l => l.Id == leadId, ct);
        lead0.Phase = LeadPhase.QuotationDiscussion;

        if (quotation.Stage == QuotationStage.Initial)
        {
            // Kept on the lead as well, because a lost lead may still have been quoted and its
            // phase can no longer say so.
            lead0.QuotationSharedAt = DateOnly.FromDateTime(now.UtcDateTime);
        }

        lead0.UpdatedAt = now;
        lead0.UpdatedByEmployeeId = actorId;

        await audit.WriteAsync(
            AuditActions.QuotationSent, nameof(Quotation), quotation.Id, actorId,
            new { leadId, version = quotation.VersionNumber, recipient, status = result.Status.ToString() }, ct);

        await db.SaveChangesAsync(ct);

        return new SendQuotationResult
        {
            Quotation = await quotations.GetAsync(leadId, quotationId, actorId, ct),
            Delivered = result.Status == EmailDeliveryStatus.Queued,
            Recipient = recipient,
            DeliveryError = result.Error
        };
    }

    // --- Rendering ----------------------------------------------------------------

    private async Task<QuotationFileContent> RenderAndStoreAsync(
        Quotation quotation, Lead lead, Guid actorId, CancellationToken ct, bool markAsSent = false)
    {
        var document = new QuotationPdfDocument(quotation, lead, _options.StudioName);
        var bytes = document.GeneratePdf();

        var fileName = BuildFileName(lead, quotation);
        var now = clock.UtcNow;

        var blobPath = await storage.UploadAsync(
            _options.QuotationDocumentContainer,
            $"{quotation.LeadId}/{quotation.Id}/{now:yyyyMMddHHmmss}-{fileName}",
            new MemoryStream(bytes),
            "application/pdf",
            ct);

        var documentRow = new QuotationDocument
        {
            QuotationId = quotation.Id,
            BlobUrl = blobPath,
            FileName = fileName,
            ContentType = "application/pdf",
            SizeInBytes = bytes.LongLength,
            GeneratedAt = now,
            GeneratedByEmployeeId = actorId,
            IsSent = markAsSent,
            CreatedAt = now,
            CreatedByEmployeeId = actorId
        };

        // Added through the DbSet for the same reason the rooms are in QuotationService.SaveAsync:
        // the key is already set by AuditableEntity, so appending to a tracked parent's collection
        // alone gets it tracked as Modified and saved as an UPDATE of a row that is not there.
        db.QuotationDocuments.Add(documentRow);
        quotation.Documents.Add(documentRow);

        return new QuotationFileContent { Content = bytes, FileName = fileName };
    }

    private string BuildBody(Lead lead, Quotation quotation, string? message)
    {
        var note = string.IsNullOrWhiteSpace(message)
            ? "Please find your quotation attached. We would be glad to walk you through it, and to revise anything that does not look right."
            : System.Net.WebUtility.HtmlEncode(message.Trim()).Replace("\n", "<br>");

        return $"""
            <p>Hello {System.Net.WebUtility.HtmlEncode(lead.FullName)},</p>
            <p>{note}</p>
            <p><strong>{StageLabel(quotation.Stage)} - version {quotation.VersionNumber}</strong><br>
               {System.Net.WebUtility.HtmlEncode(lead.PropertyName)}<br>
               Total including GST: Rs {quotation.GrandTotal:N2}</p>
            <p>Kind regards,<br>{System.Net.WebUtility.HtmlEncode(_options.StudioName)}</p>
            """;
    }

    private static string StageLabel(QuotationStage stage) =>
        stage == QuotationStage.Initial ? "Initial quotation" : "Final quotation";

    private static string BuildFileName(Lead lead, Quotation quotation)
    {
        var safeName = new string(lead.FullName
            .Where(c => char.IsLetterOrDigit(c) || c is ' ' or '-')
            .ToArray())
            .Trim()
            .Replace(' ', '-');

        if (safeName.Length == 0) safeName = "client";

        var stage = quotation.Stage == QuotationStage.Initial ? "initial" : "final";

        return $"quotation-{stage}-v{quotation.VersionNumber}-{safeName}.pdf";
    }

    // --- Loading and access -------------------------------------------------------

    private async Task<(Quotation Quotation, Lead Lead)> LoadForRenderAsync(
        Guid leadId, Guid quotationId, bool tracked, CancellationToken ct)
    {
        var query = tracked ? db.Quotations : db.Quotations.AsNoTracking();

        var quotation = await query
            .Include(q => q.Rooms.OrderBy(r => r.SortOrder))
            .ThenInclude(r => r.LineItems.OrderBy(i => i.SortOrder))
            .Include(q => q.Documents)
            .FirstOrDefaultAsync(q => q.Id == quotationId && q.LeadId == leadId, ct)
            ?? throw new NotFoundException("Quotation", quotationId);

        var lead = await db.Leads.AsNoTracking().FirstOrDefaultAsync(l => l.Id == leadId, ct)
                   ?? throw new NotFoundException("Lead", leadId);

        return (quotation, lead);
    }

    private async Task RequireAnyQuotationPermissionAsync(Guid actorId, CancellationToken ct)
    {
        var allowed = await permissions.HasAnyPermissionAsync(
            actorId, [PermissionCodes.ManageQuotations, PermissionCodes.ApproveQuotations], ct);

        if (!allowed)
        {
            throw new ForbiddenException(
                $"This action requires the {PermissionCodes.ManageQuotations} or " +
                $"{PermissionCodes.ApproveQuotations} permission.");
        }
    }
}
