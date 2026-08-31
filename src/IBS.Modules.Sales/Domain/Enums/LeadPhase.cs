namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// Where a lead has reached in the studio's journey, from first enquiry to a signed project.
/// <para>
/// This is the single answer to "where is this lead", and it replaced two earlier fields that
/// each answered part of it: a generic pipeline status (New/Contacted/Qualified/...) that
/// described no interiors studio in particular, and a separate quotation status that could
/// disagree with it. Whether the lead is still <em>alive</em> is a different question, kept on
/// <see cref="LeadOverallStatus"/>; when to chase it is a third, kept on NextFollowUpDate.
/// </para>
/// <para>
/// Numbered in tens per group so a phase can be inserted later without renumbering - the
/// value is what is stored, so shifting members would silently restage every existing lead.
/// </para>
/// </summary>
public enum LeadPhase
{
    // --- Capture and qualification ---------------------------------------------
    NewEnquiry = 10,
    Contacted = 11,
    Onboarding = 12,
    RequirementsGathering = 13,
    SiteVisitScheduled = 14,
    SiteVisitCompleted = 15,

    // --- Initial quotation, before any design ----------------------------------
    QuotationInProgress = 20,
    QuotationShared = 21,
    QuotationRevisionRequired = 22,
    QuotationApproved = 23,

    // --- Design ----------------------------------------------------------------
    DesignInProgress = 30,
    DesignShared = 31,
    DesignRevisionRequired = 32,
    DesignApproved = 33,

    // --- Final quotation, priced against the approved design -------------------
    FinalQuotationInProgress = 40,
    FinalQuotationShared = 41,
    FinalQuotationRevisionRequired = 42,
    FinalQuotationApproved = 43,
    FinalQuotationRejected = 44,

    // --- Conversion and close --------------------------------------------------
    AdvanceReceived = 50,
    ConvertedToProject = 51,
    Lost = 52,
    Closed = 53
}
