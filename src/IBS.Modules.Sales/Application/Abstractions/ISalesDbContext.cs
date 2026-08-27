using IBS.Modules.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.Sales.Application.Abstractions;

/// <summary>
/// The slice of the database this module is allowed to touch. Keeping the module against an
/// interface rather than the concrete DbContext is what makes the module boundary real:
/// IBS.Infrastructure owns the context and implements this, no module references another.
/// </summary>
public interface ISalesDbContext
{
    DbSet<Lead> Leads { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
