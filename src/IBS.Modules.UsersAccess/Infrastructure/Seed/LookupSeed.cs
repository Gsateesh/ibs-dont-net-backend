using IBS.Modules.UsersAccess.Domain.Entities;

namespace IBS.Modules.UsersAccess.Infrastructure.Seed;

/// <summary>
/// Default branches, departments and designations from spec section 4.1. All three are
/// editable in Settings afterwards; these are only the starting rows.
/// </summary>
public static class LookupSeed
{
    private static Guid BranchId(int n) => new($"b7a10000-0000-4000-8000-{n:D12}");
    private static Guid DepartmentId(int n) => new($"d4e10000-0000-4000-8000-{n:D12}");
    private static Guid DesignationId(int n) => new($"d5a10000-0000-4000-8000-{n:D12}");

    /// <summary>The single company row, filled in properly from Settings on first run.</summary>
    public static Company Company { get; } = new()
    {
        Id = new Guid("c0119a11-0000-4000-8000-000000000001"),
        LegalName = "IBS",
        Currency = "INR",
        FinancialYearStart = new DateOnly(2026, 4, 1),
        CreatedAt = SeedTimestamp.Value
    };

    public static IReadOnlyList<Branch> Branches { get; } =
    [
        MakeBranch(1, "Bengaluru"),
        MakeBranch(2, "Chennai"),
        MakeBranch(3, "Pune"),
        MakeBranch(4, "Hyderabad")
    ];

    public static IReadOnlyList<Department> Departments { get; } =
    [
        MakeDepartment(1, "Sales"),
        MakeDepartment(2, "Design"),
        MakeDepartment(3, "Estimation"),
        MakeDepartment(4, "Procurement"),
        MakeDepartment(5, "Execution"),
        MakeDepartment(6, "Finance")
    ];

    /// <summary>
    /// Descriptive job titles only. Super Admin appears here as a title; the access it implies
    /// comes from the flag on the employee row, not from this list (spec sections 5.1 and 6.1).
    /// </summary>
    public static IReadOnlyList<Designation> Designations { get; } =
    [
        MakeDesignation(1, "Super Admin"),
        MakeDesignation(2, "Company Admin"),
        MakeDesignation(3, "Business Head"),
        MakeDesignation(4, "Sales Manager", isSalesRole: true),
        MakeDesignation(5, "Sales Executive", isSalesRole: true),
        MakeDesignation(6, "Pre-sales / Telecaller", isSalesRole: true),
        MakeDesignation(7, "Design Head"),
        MakeDesignation(8, "Interior Designer"),
        MakeDesignation(9, "3D Visualiser"),
        MakeDesignation(10, "Draftsman / CAD"),
        MakeDesignation(11, "Estimator / QS"),
        MakeDesignation(12, "Procurement Executive"),
        MakeDesignation(13, "Store Keeper"),
        MakeDesignation(14, "Project Manager"),
        MakeDesignation(15, "Site Supervisor"),
        MakeDesignation(16, "QC Inspector"),
        MakeDesignation(17, "Accounts Executive"),
        MakeDesignation(18, "HR Executive"),
        MakeDesignation(19, "Customer Support")
    ];

    /// <summary>The designation the seed tool assigns to the bootstrap Super Admin row.</summary>
    public static Guid SuperAdminDesignationId => DesignationId(1);

    /// <summary>Defaults the seed tool uses when creating the very first employee row.</summary>
    public static Guid DefaultBranchId => BranchId(1);

    /// <summary>Defaults the seed tool uses when creating the very first employee row.</summary>
    public static Guid DefaultDepartmentId => DepartmentId(1);

    private static Branch MakeBranch(int n, string name) => new()
    {
        Id = BranchId(n),
        Name = name,
        City = name,
        Timezone = "Asia/Kolkata",
        CreatedAt = SeedTimestamp.Value
    };

    private static Department MakeDepartment(int n, string name) => new()
    {
        Id = DepartmentId(n),
        Name = name,
        CreatedAt = SeedTimestamp.Value
    };

    private static Designation MakeDesignation(int n, string name, bool isSalesRole = false) => new()
    {
        Id = DesignationId(n),
        Name = name,
        IsSalesRole = isSalesRole,
        CreatedAt = SeedTimestamp.Value
    };
}
