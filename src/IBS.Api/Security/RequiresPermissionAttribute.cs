namespace IBS.Api.Security;

/// <summary>
/// Documents the permission an endpoint requires, so Swagger can state it (see
/// <see cref="Swagger.PermissionSummaryOperationFilter"/>).
/// <para>
/// This attribute describes; it does not enforce. Enforcement lives in the services, where
/// the check can also see the target of the action - which is what rules like
/// CanManageAccount need in order to mean anything (spec section 5.3).
/// </para>
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class RequiresPermissionAttribute(params string[] permissionCodes) : Attribute
{
    /// <summary>The permission codes involved.</summary>
    public IReadOnlyList<string> PermissionCodes { get; } = permissionCodes;
}
