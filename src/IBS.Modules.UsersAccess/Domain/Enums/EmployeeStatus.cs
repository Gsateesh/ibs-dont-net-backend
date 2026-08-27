namespace IBS.Modules.UsersAccess.Domain.Enums;

/// <summary>
/// Account lifecycle state (spec sections 4.2 and 6). A row starts at Invited with no
/// password, and only reaches Active when the person sets one themselves.
/// </summary>
public enum EmployeeStatus
{
    /// <summary>Created, invite emailed, password not yet set.</summary>
    Invited = 1,

    /// <summary>Password set, can sign in.</summary>
    Active = 2,

    /// <summary>Sign-in blocked by an administrator; reversible via reinstate.</summary>
    Suspended = 3,

    /// <summary>Deactivated account, retained for history.</summary>
    Inactive = 4,

    /// <summary>Person has left the company.</summary>
    Exited = 5
}
