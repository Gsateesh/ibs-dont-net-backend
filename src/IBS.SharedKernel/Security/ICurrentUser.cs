namespace IBS.SharedKernel.Security;

/// <summary>
/// The employee behind the current request, resolved from the bearer token.
/// Injected wherever a service needs to know who is acting.
/// </summary>
public interface ICurrentUser
{
    /// <summary>Employee id, or null when the request is unauthenticated.</summary>
    Guid? EmployeeId { get; }

    /// <summary>Email of the signed-in employee, or null when unauthenticated.</summary>
    string? Email { get; }

    /// <summary>True when a bearer token was presented and validated.</summary>
    bool IsAuthenticated { get; }

    /// <summary>True when the signed-in employee carries the Super Admin flag (spec section 5.2).</summary>
    bool IsSuperAdmin { get; }

    /// <summary>Employee id, throwing when the request is unauthenticated.</summary>
    Guid RequireEmployeeId();
}
