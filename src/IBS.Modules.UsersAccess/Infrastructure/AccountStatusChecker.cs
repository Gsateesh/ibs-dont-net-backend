using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.SharedKernel.Security;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Infrastructure;

/// <inheritdoc cref="IAccountStatusChecker" />
public sealed class AccountStatusChecker(IUsersAccessDbContext db) : IAccountStatusChecker
{
    public async Task<bool> IsActiveAsync(Guid employeeId, CancellationToken ct = default)
    {
        var status = await db.Employees
            .AsNoTracking()
            .Where(e => e.Id == employeeId)
            .Select(e => (EmployeeStatus?)e.Status)
            .FirstOrDefaultAsync(ct);

        return status == EmployeeStatus.Active;
    }
}
