namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// Whether anyone is actively working this lead right now - and nothing else.
/// <para>
/// Deliberately holds no outcome: <em>which</em> way a closed lead went (converted, lost) is
/// answered by <see cref="LeadPhase"/>, and duplicating it here only created two fields that
/// could contradict each other. Converted, NotInterested and Lost were removed for that
/// reason; their numbers (4, 5, 6) are left unused rather than recycled, so an unmigrated row
/// can never quietly read as a live value.
/// </para>
/// </summary>
public enum LeadOverallStatus
{
    /// <summary>Moving along normally.</summary>
    Active = 1,

    /// <summary>Paused by agreement, expected to resume.</summary>
    OnHold = 2,

    /// <summary>Blocked on the client - an approval, a decision, a document.</summary>
    AwaitingClient = 3,

    /// <summary>
    /// Chasing has stopped. Gone quiet with no response, not formally lost, and nobody is
    /// working it - so it belongs on no one's call list. Contrast <see cref="Unreachable"/>,
    /// which is the same silence while someone is still actively trying.
    /// </summary>
    Dormant = 7,

    /// <summary>Needs chasing. Can be true at any phase, which is why it lives here.</summary>
    FollowUpRequired = 8,

    /// <summary>No longer being worked, whatever the outcome. See the phase for which.</summary>
    Closed = 9,

    /// <summary>
    /// Calls and emails are going out and getting no answer, and the lead is still being
    /// chased. An active state, not an outcome: it says the next contact attempt has yet to
    /// land, so the lead stays on the owner's call list.
    /// <para>
    /// The line against <see cref="Dormant"/> is effort, not silence - both are silent. This
    /// one means someone is still trying; Dormant means they have stopped. A lead that goes
    /// unanswered long enough is moved on to Dormant by hand, since nothing ages it
    /// automatically (there is no background service in the solution).
    /// </para>
    /// <para>
    /// Distinct from <see cref="AwaitingClient"/>, where the client is contactable and simply
    /// owes something, and from <see cref="FollowUpRequired"/>, which says a lead is due a
    /// chase without claiming anything about whether earlier attempts were answered.
    /// </para>
    /// </summary>
    Unreachable = 10
}
