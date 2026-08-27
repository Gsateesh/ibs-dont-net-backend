using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// The company this deployment belongs to. Single row for now - this is not multi-tenant
/// (spec sections 4.1 and 8), so nothing is tenant-scoped.
/// </summary>
public class Company : AuditableEntity
{
    /// <summary>Registered legal name.</summary>
    public string LegalName { get; set; } = string.Empty;

    /// <summary>GST identification number.</summary>
    public string? Gstin { get; set; }

    /// <summary>Registered address as printed on statutory documents.</summary>
    public string? RegisteredAddress { get; set; }

    /// <summary>Blob Storage reference for the company logo.</summary>
    public string? LogoUrl { get; set; }

    /// <summary>First day of the financial year, e.g. 1 April.</summary>
    public DateOnly FinancialYearStart { get; set; } = new(DateTime.UtcNow.Year, 4, 1);

    /// <summary>ISO 4217 currency code, e.g. INR.</summary>
    public string Currency { get; set; } = "INR";
}
