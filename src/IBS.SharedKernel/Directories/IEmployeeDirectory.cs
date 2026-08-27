namespace IBS.SharedKernel.Directories;

/// <summary>Thin, read-only projection of an employee for display in another module's responses.</summary>
public sealed record EmployeeSummary(Guid Id, string FullName, string Email);

/// <summary>
/// Read-only employee lookups for modules that need to show or select an employee (e.g. an
/// "assign to" dropdown) without depending on the UsersAccess module directly - which would
/// break the module boundary - or on the manage_users-gated employee endpoints, which a caller
/// with a narrower permission may not hold.
/// </summary>
public interface IEmployeeDirectory
{
    /// <summary>Active employees, suitable for populating an "assign to" selector.</summary>
    Task<IReadOnlyList<EmployeeSummary>> GetAssignableEmployeesAsync(CancellationToken ct = default);

    /// <summary>Batched id-to-summary lookup, for hydrating names onto a list of records.</summary>
    Task<IReadOnlyDictionary<Guid, EmployeeSummary>> GetSummariesAsync(
        IEnumerable<Guid> employeeIds, CancellationToken ct = default);
}
