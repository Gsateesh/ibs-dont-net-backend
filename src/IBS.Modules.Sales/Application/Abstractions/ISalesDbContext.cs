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

    DbSet<LeadRoom> LeadRooms { get; }

    DbSet<LeadRoomRequirement> LeadRoomRequirements { get; }

    DbSet<Quotation> Quotations { get; }

    DbSet<QuotationRoom> QuotationRooms { get; }

    DbSet<QuotationLineItem> QuotationLineItems { get; }

    DbSet<QuotationDocument> QuotationDocuments { get; }

    /// <summary>The item picker's contents. Read-only from this module; edited by an admin screen.</summary>
    DbSet<QuotationCatalogEntry> QuotationCatalogEntries { get; }

    /// <summary>The rate card. Read-only from this module for the same reason.</summary>
    DbSet<QuotationRate> QuotationRates { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
