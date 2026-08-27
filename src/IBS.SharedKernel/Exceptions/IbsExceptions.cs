namespace IBS.SharedKernel.Exceptions;

/// <summary>Base type for exceptions the API translates into a meaningful HTTP status.</summary>
public abstract class IbsException : Exception
{
    protected IbsException(string message) : base(message) { }
}

/// <summary>The requested resource does not exist. Surfaces as 404.</summary>
public sealed class NotFoundException(string resource, object key)
    : IbsException($"{resource} '{key}' was not found.")
{
    public string Resource { get; } = resource;
    public object Key { get; } = key;
}

/// <summary>The request is well-formed but breaks a business rule. Surfaces as 400 or 422.</summary>
public sealed class BusinessRuleException(string message, string? code = null) : IbsException(message)
{
    /// <summary>Stable machine-readable rule identifier, e.g. <c>reporting_cycle</c>.</summary>
    public string? Code { get; } = code;
}

/// <summary>The caller is authenticated but not allowed to perform this action. Surfaces as 403.</summary>
public sealed class ForbiddenException(string message = "You are not allowed to perform this action.")
    : IbsException(message);

/// <summary>A conflicting row already exists (unique email, in-use lookup, ...). Surfaces as 409.</summary>
public sealed class ConflictException(string message) : IbsException(message);
