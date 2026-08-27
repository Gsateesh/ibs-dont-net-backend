using System.Security.Claims;
using IBS.SharedKernel.Security;

namespace IBS.Api.Security;

/// <summary>
/// Reads the signed-in employee out of the bearer token claims.
/// </summary>
public sealed class CurrentUser(IHttpContextAccessor accessor) : ICurrentUser
{
    /// <summary>Claim type carrying the employee id.</summary>
    public const string EmployeeIdClaim = "ibs:employee_id";

    /// <summary>Claim type carrying the Super Admin flag.</summary>
    public const string SuperAdminClaim = "ibs:super_admin";

    private ClaimsPrincipal? Principal => accessor.HttpContext?.User;

    public Guid? EmployeeId =>
        Guid.TryParse(Principal?.FindFirstValue(EmployeeIdClaim), out var id) ? id : null;

    public string? Email => Principal?.FindFirstValue(ClaimTypes.Email);

    public bool IsAuthenticated => Principal?.Identity?.IsAuthenticated ?? false;

    public bool IsSuperAdmin =>
        bool.TryParse(Principal?.FindFirstValue(SuperAdminClaim), out var flag) && flag;

    public Guid RequireEmployeeId() =>
        EmployeeId ?? throw new UnauthorizedAccessException("This request has no signed-in employee.");
}
