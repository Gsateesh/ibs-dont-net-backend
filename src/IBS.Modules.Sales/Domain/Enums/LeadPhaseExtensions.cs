namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>Questions worth asking of a <see cref="LeadPhase"/> in more than one place.</summary>
public static class LeadPhaseExtensions
{
    /// <summary>
    /// Phases that can only have been reached after a quotation went to the client.
    /// <para>
    /// Just the one, now that the phases are flat: talking a quotation through means it was
    /// sent. Interested, Closure and Lost are absent on purpose - a lead can be any of the
    /// three with nothing ever quoted, and the phase alone cannot tell the cases apart. That
    /// gap is exactly why the date is stored rather than inferred; this set only decides when
    /// to stamp it.
    /// </para>
    /// </summary>
    private static readonly HashSet<LeadPhase> QuotationSharedPhases =
    [
        LeadPhase.QuotationDiscussion
    ];

    /// <summary>True when reaching this phase implies a quotation has been sent.</summary>
    public static bool ImpliesQuotationShared(this LeadPhase phase) => QuotationSharedPhases.Contains(phase);

    /// <summary>
    /// Phases where nobody is working the lead any more. Used to keep closed-out leads off
    /// the top of the default list ordering, which is a call list.
    /// </summary>
    private static readonly HashSet<LeadPhase> ClosedPhases =
    [
        LeadPhase.Fake,
        LeadPhase.Lost,
        LeadPhase.Closure
    ];

    /// <summary>True when the lead is no longer in play, whichever way it went.</summary>
    public static bool IsClosed(this LeadPhase phase) => ClosedPhases.Contains(phase);
}
