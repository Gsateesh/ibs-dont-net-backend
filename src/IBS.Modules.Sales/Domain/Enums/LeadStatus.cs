namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>Pipeline stage of a lead.</summary>
public enum LeadStatus
{
    New = 1,
    Contacted = 2,
    Qualified = 3,
    Negotiation = 4,
    Won = 5,
    Lost = 6
}
