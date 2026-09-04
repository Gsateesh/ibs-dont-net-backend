namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// Where a lead has reached in the studio's journey, from first enquiry to a closed project.
/// <para>
/// This is the single answer to "where is this lead". It absorbed two earlier fields that each
/// answered part of it: a stage-by-stage pipeline (quotation, design, final quotation, each
/// with its own in-progress/shared/approved trio) that described more process than the studio
/// actually tracks, and a separate overall status (Active, Awaiting client, Unreachable,
/// Dormant, Follow-up required...) whose live values are now phases in their own right -
/// <see cref="AwaitingResponse"/>, <see cref="NotResponding"/>, <see cref="FollowUp"/>. When to
/// chase a lead is still a third question, kept on NextFollowUpDate.
/// </para>
/// <para>
/// Numbered from 100 in tens. The range deliberately does not overlap the 10-53 the old
/// phases used, so a row that missed the migration reads as an invalid value rather than
/// quietly landing on a live phase that means something else.
/// </para>
/// </summary>
public enum LeadPhase
{
    /// <summary>Just captured. Nobody has worked it yet.</summary>
    NewClient = 100,

    /// <summary>Being worked, but the requirements are not captured well enough to price.</summary>
    RequirementPending = 110,

    /// <summary>Requirements are in and the quotation is being built.</summary>
    QuotationPending = 120,

    /// <summary>A quotation has gone out and is being talked through with the client.</summary>
    QuotationDiscussion = 130,

    /// <summary>The ball is with the client, and they have said they will come back.</summary>
    AwaitingResponse = 140,

    /// <summary>Calls and messages are going unanswered.</summary>
    NotResponding = 150,

    /// <summary>Real, but not now - a project that starts months out.</summary>
    FutureClient = 160,

    /// <summary>Alive and needs chasing, with nothing more specific to say about it.</summary>
    FollowUp = 170,

    /// <summary>Not a genuine enquiry. Kept rather than deleted so it stays out of the counts.</summary>
    Fake = 180,

    /// <summary>Gone elsewhere, or decided against the work.</summary>
    Lost = 190,

    /// <summary>Won and closed out.</summary>
    Closure = 200,

    /// <summary>Has said yes in principle - the work is on, the paperwork is not done.</summary>
    Interested = 210
}
