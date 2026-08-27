using IBS.Infrastructure.Persistence;
using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Directories;
using Microsoft.EntityFrameworkCore;

namespace IBS.Infrastructure.Directories;

/// <inheritdoc cref="IEmployeeDirectory" />
public sealed class EmployeeDirectory(IbsDbContext db) : IEmployeeDirectory
{
    public async Task<IReadOnlyList<EmployeeSummary>> GetAssignableEmployeesAsync(CancellationToken ct = default) =>
        await db.Employees
            .AsNoTracking()
            .Where(e => e.Status == EmployeeStatus.Active)
            .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
            .Select(e => new EmployeeSummary(e.Id, e.FirstName + " " + e.LastName, e.Email))
            .ToListAsync(ct);

    public async Task<IReadOnlyDictionary<Guid, EmployeeSummary>> GetSummariesAsync(
        IEnumerable<Guid> employeeIds, CancellationToken ct = default)
    {
        var ids = employeeIds.Distinct().ToList();
        if (ids.Count == 0)
        {
            return new Dictionary<Guid, EmployeeSummary>();
        }

        var summaries = await db.Employees
            .AsNoTracking()
            .Where(e => ids.Contains(e.Id))
            .Select(e => new EmployeeSummary(e.Id, e.FirstName + " " + e.LastName, e.Email))
            .ToListAsync(ct);

        return summaries.ToDictionary(s => s.Id);
    }
}
