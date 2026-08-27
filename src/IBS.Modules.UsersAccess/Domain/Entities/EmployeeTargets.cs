namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// Optional 1:1 sales targets (spec section 4.3). Shown in the UI only for designations
/// flagged <see cref="Designation.IsSalesRole"/>.
/// </summary>
public class EmployeeTargets
{
    /// <summary>Primary key and foreign key - one row per employee at most.</summary>
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public decimal? MonthlyTarget { get; set; }

    /// <summary>Incentive as a percentage, e.g. 2.5 for 2.5 percent.</summary>
    public decimal? IncentivePercent { get; set; }

    /// <summary>Discount ceiling above which an approval is required.</summary>
    public decimal? MaxDiscountBeforeEscalation { get; set; }

    /// <summary>Areas the person covers.</summary>
    public List<string> Territories { get; set; } = [];
}
