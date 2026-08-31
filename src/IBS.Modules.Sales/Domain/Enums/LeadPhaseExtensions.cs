namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>Questions worth asking of a <see cref="LeadPhase"/> in more than one place.</summary>
public static class LeadPhaseExtensions
{
    /// <summary>
    /// Phases that can only have been reached after a quotation went to the client.
    /// <para>
    /// Lost and Closed are absent on purpose: a lead can be lost before anything was quoted,
    /// and the phase alone cannot tell the two apart. That gap is exactly why the date below
    /// is stored rather than inferred - this set only decides when to stamp it.
    /// </para>
    /// </summary>
    private static readonly HashSet<LeadPhase> QuotationSharedPhases =
    [
        LeadPhase.QuotationShared,
        LeadPhase.QuotationRevisionRequired,
        LeadPhase.QuotationApproved,
        LeadPhase.DesignInProgress,
        LeadPhase.DesignShared,
        LeadPhase.DesignRevisionRequired,
        LeadPhase.DesignApproved,
        LeadPhase.FinalQuotationInProgress,
        LeadPhase.FinalQuotationShared,
        LeadPhase.FinalQuotationRevisionRequired,
        LeadPhase.FinalQuotationApproved,
        LeadPhase.FinalQuotationRejected,
        LeadPhase.AdvanceReceived,
        LeadPhase.ConvertedToProject
    ];

    /// <summary>True when reaching this phase implies a quotation has been sent.</summary>
    public static bool ImpliesQuotationShared(this LeadPhase phase) => QuotationSharedPhases.Contains(phase);
}
