using IBS.SharedKernel.Notifications;
using IBS.SharedKernel.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Infrastructure.Email;

/// <summary>
/// A record of one outbound message: who it went to, what it was about, and what became of it.
/// </summary>
/// <remarks>
/// <para>
/// Written by <see cref="EmailLoggingDispatcher"/> around the dispatcher rather than by the
/// module raising the message. That way every email the system sends is logged - invites and
/// password resets included - instead of only the ones somebody remembered to instrument.
/// </para>
/// <para>
/// The status is honest about its limits. Azure Communication Services is handed the message
/// and the send is started rather than awaited, so <see cref="EmailDeliveryStatus.Queued"/>
/// means "the provider accepted it", not "the client received it". A bounce afterwards is not
/// visible here; reading that back would need the provider's delivery-report webhooks.
/// <see cref="ProviderMessageId"/> is stored so that remains possible later.
/// </para>
/// </remarks>
public class EmailLog : AuditableEntity
{
    public string ToEmail { get; set; } = string.Empty;

    public string? ToName { get; set; }

    public string Subject { get; set; } = string.Empty;

    /// <summary>Stable label for the kind of message, e.g. <c>quotation.sent</c>.</summary>
    public string Kind { get; set; } = string.Empty;

    /// <summary>What the message was about, e.g. <c>Quotation</c>, so the log can be filtered.</summary>
    public string? RelatedEntityType { get; set; }

    public Guid? RelatedEntityId { get; set; }

    /// <summary>Comma-separated attachment names. The bytes themselves are not kept here.</summary>
    public string? AttachmentNames { get; set; }

    public int AttachmentCount { get; set; }

    public EmailDeliveryStatus Status { get; set; }

    public string? ProviderMessageId { get; set; }

    /// <summary>Why it failed, when it did. Truncated - this is a breadcrumb, not a stack trace.</summary>
    public string? Error { get; set; }

    public Guid? SentByEmployeeId { get; set; }

    public DateTimeOffset SentAt { get; set; }
}

/// <summary>Mapping for <see cref="EmailLog"/>.</summary>
public sealed class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
{
    public void Configure(EntityTypeBuilder<EmailLog> builder)
    {
        builder.ToTable("EmailLogs");
        builder.HasKey(l => l.Id);

        builder.Property(l => l.ToEmail).HasMaxLength(256).IsRequired();
        builder.Property(l => l.ToName).HasMaxLength(200);
        builder.Property(l => l.Subject).HasMaxLength(500).IsRequired();
        builder.Property(l => l.Kind).HasMaxLength(100).IsRequired();
        builder.Property(l => l.RelatedEntityType).HasMaxLength(100);
        builder.Property(l => l.AttachmentNames).HasMaxLength(1000);
        builder.Property(l => l.ProviderMessageId).HasMaxLength(200);
        builder.Property(l => l.Error).HasMaxLength(2000);
        builder.Property(l => l.Status).HasConversion<int>();

        // "What was sent about this quotation" is the query this table exists to answer.
        builder.HasIndex(l => new { l.RelatedEntityType, l.RelatedEntityId });
        builder.HasIndex(l => l.SentAt);
        builder.HasIndex(l => l.Kind);
    }
}
