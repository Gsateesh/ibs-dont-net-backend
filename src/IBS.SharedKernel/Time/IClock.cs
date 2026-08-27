namespace IBS.SharedKernel.Time;

/// <summary>
/// Abstraction over the system clock so token expiry, lockout windows and audit
/// timestamps can be tested deterministically.
/// </summary>
public interface IClock
{
    DateTimeOffset UtcNow { get; }
}

/// <summary>Default <see cref="IClock"/> backed by the machine clock.</summary>
public sealed class SystemClock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
