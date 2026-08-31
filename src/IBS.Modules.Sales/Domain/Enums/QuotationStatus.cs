namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// Where one version of a quotation has reached. Deliberately narrower than
/// <see cref="LeadPhase"/>: the phase describes the lead, this describes a single document,
/// and a lead can hold a superseded v1 and a shared v2 at the same time.
/// </summary>
/// <remarks>
/// Only <see cref="Draft"/> is editable. Everything else is frozen, because the numbers on a
/// version the client has seen must never change underneath them - a revision is a new
/// version, not an edit.
/// </remarks>
public enum QuotationStatus
{
    /// <summary>Being built. The only editable state.</summary>
    Draft = 1,

    /// <summary>Emailed to the client. Frozen from here on.</summary>
    Shared = 2,

    /// <summary>The client asked for changes. Still frozen - the changes go into a new version.</summary>
    RevisionRequired = 3,

    /// <summary>The client accepted this version.</summary>
    Approved = 4,

    /// <summary>A later version replaced this one.</summary>
    Superseded = 5
}
