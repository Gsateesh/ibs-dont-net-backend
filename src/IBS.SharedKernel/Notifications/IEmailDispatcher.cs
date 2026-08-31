namespace IBS.SharedKernel.Notifications;

/// <summary>
/// The low-level mail primitive: send this message, with these attachments, to this address.
/// </summary>
/// <remarks>
/// <para>
/// Lives in the shared kernel rather than in a module because more than one module needs to
/// send mail - UsersAccess for invites and password resets, Sales for issuing a quotation -
/// and no module may reference another. This is the same reasoning that puts
/// <see cref="Directories.IEmployeeDirectory"/> here.
/// </para>
/// <para>
/// It is deliberately dumb. Templating, wording and the decision to send at all belong to the
/// module raising the message; this contract only carries it out and reports what happened.
/// </para>
/// </remarks>
public interface IEmailDispatcher
{
    /// <summary>
    /// True when mail actually leaves the building. False for the development dispatcher, which
    /// only logs - callers use it to tell the user their message was not really sent rather than
    /// implying it was.
    /// </summary>
    bool DeliversMail { get; }

    /// <summary>
    /// Sends one message. Never throws for a rejected send: the outcome is on the result, so a
    /// caller that has already committed work does not lose it because a mail server was down.
    /// </summary>
    Task<EmailDeliveryResult> SendAsync(EmailMessage message, CancellationToken ct = default);
}

/// <summary>One outbound message.</summary>
public sealed class EmailMessage
{
    public required string ToEmail { get; init; }

    public string? ToName { get; init; }

    public required string Subject { get; init; }

    public required string HtmlBody { get; init; }

    /// <summary>
    /// A short stable label for what kind of message this is, e.g. <c>quotation.sent</c>. Stored
    /// on the log so "did the quotation mail go out" is a query rather than a text search.
    /// </summary>
    public required string Kind { get; init; }

    /// <summary>What the message is about, so the log can be filtered by it. Optional.</summary>
    public string? RelatedEntityType { get; init; }

    public Guid? RelatedEntityId { get; init; }

    /// <summary>Who asked for it to be sent. Null for system mail.</summary>
    public Guid? SentByEmployeeId { get; init; }

    public IReadOnlyList<EmailAttachment> Attachments { get; init; } = [];
}

/// <summary>One file attached to a message, held in memory for the length of the send.</summary>
public sealed class EmailAttachment
{
    public required string FileName { get; init; }

    public required string ContentType { get; init; }

    public required byte[] Content { get; init; }
}

/// <summary>What became of a send.</summary>
public sealed class EmailDeliveryResult
{
    /// <summary>
    /// True when the provider accepted the message. Not a promise it was delivered - see
    /// <see cref="EmailDeliveryStatus.Queued"/>.
    /// </summary>
    public bool Accepted => Status != EmailDeliveryStatus.Failed;

    public EmailDeliveryStatus Status { get; init; }

    /// <summary>The provider's handle for the send, where there is one. Kept for later reconciliation.</summary>
    public string? ProviderMessageId { get; init; }

    public string? Error { get; init; }

    public static EmailDeliveryResult Queued(string? providerMessageId) =>
        new() { Status = EmailDeliveryStatus.Queued, ProviderMessageId = providerMessageId };

    public static EmailDeliveryResult Suppressed() => new() { Status = EmailDeliveryStatus.Suppressed };

    public static EmailDeliveryResult Failed(string error) =>
        new() { Status = EmailDeliveryStatus.Failed, Error = error };
}

/// <summary>How far a message got.</summary>
public enum EmailDeliveryStatus
{
    /// <summary>
    /// Handed to the provider and accepted. This is as far as the system currently knows: the
    /// send is started rather than awaited, so a bounce afterwards is not visible here. Reading
    /// true delivery back would need the provider's delivery-report webhooks.
    /// </summary>
    Queued = 1,

    /// <summary>The development dispatcher logged it instead of sending. Nothing left the building.</summary>
    Suppressed = 2,

    /// <summary>The provider refused it, or the call failed outright.</summary>
    Failed = 3
}
