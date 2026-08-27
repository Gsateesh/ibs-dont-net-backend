using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.SharedKernel.Security;

namespace IBS.Modules.UsersAccess.Infrastructure.Seed;

/// <summary>
/// The 20 permissions from spec section 4.4, seeded by migration with fixed ids so the same
/// row exists in every environment. A new permission is added here only alongside the
/// migration that ships the feature it gates - never through the UI.
/// </summary>
public static class PermissionSeed
{
    /// <summary>Deterministic ids keep migrations idempotent across environments.</summary>
    private static Guid Id(int n) => new($"9e5b0000-0000-4000-8000-{n:D12}");

    public static IReadOnlyList<Permission> All { get; } =
    [
        Make(1, PermissionCodes.ManageUsers, "Can manage users", PermissionGroups.PeopleAndAccess,
            "Add people, edit their details, and run invite, suspend, reinstate and deactivate actions."),
        Make(2, PermissionCodes.ManagePermissions, "Can manage permissions", PermissionGroups.PeopleAndAccess,
            "Grant or revoke the two high-impact permissions, and rename or regroup the catalogue."),
        Make(3, PermissionCodes.ViewSensitiveData, "Can view employee sensitive data", PermissionGroups.PeopleAndAccess,
            "Read the statutory record: PAN, Aadhaar, bank details, PF, ESIC and CTC."),

        Make(4, PermissionCodes.ManageCustomerOnboarding, "Can manage customer onboarding", PermissionGroups.SalesPipeline,
            "Create and progress customer onboarding records."),
        Make(5, PermissionCodes.ManageQuotations, "Can manage quotations", PermissionGroups.SalesPipeline,
            "Prepare, revise and issue quotations."),
        Make(20, PermissionCodes.ManageLeads, "Can manage leads", PermissionGroups.SalesPipeline,
            "View all leads, create, edit, delete and (re)assign them to any employee."),

        Make(6, PermissionCodes.ManageDesigns, "Can manage designs", PermissionGroups.DesignAndEstimation,
            "Upload and revise design files and moodboards."),
        Make(7, PermissionCodes.ManageBoq, "Can manage BOQ and estimation", PermissionGroups.DesignAndEstimation,
            "Build and revise the bill of quantities and its costing."),

        Make(8, PermissionCodes.ManageProjects, "Can manage projects", PermissionGroups.DeliveryAndExecution,
            "Create projects, set milestones and assign teams."),
        Make(9, PermissionCodes.ManageTasks, "Can manage tasks", PermissionGroups.DeliveryAndExecution,
            "Create, assign and close tasks."),
        Make(10, PermissionCodes.ManageSiteProgress, "Can manage site progress", PermissionGroups.DeliveryAndExecution,
            "Record site updates, snags and daily progress."),

        Make(11, PermissionCodes.ManageProcurement, "Can manage procurement", PermissionGroups.ProcurementInventoryVendors,
            "Raise and approve purchase orders."),
        Make(12, PermissionCodes.ManageInventory, "Can manage inventory", PermissionGroups.ProcurementInventoryVendors,
            "Record stock movements and adjust inventory."),
        Make(13, PermissionCodes.ManageVendors, "Can manage vendors", PermissionGroups.ProcurementInventoryVendors,
            "Add and edit vendors and their rate cards."),

        Make(14, PermissionCodes.ManageInvoices, "Can manage invoices and payments", PermissionGroups.Finance,
            "Raise invoices and record payments against them."),

        Make(15, PermissionCodes.ManagePortal, "Can manage client portal publishing", PermissionGroups.ClientPortal,
            "Decide what is published to the client portal."),

        Make(16, PermissionCodes.ViewReports, "Can view reports", PermissionGroups.ReportingAndOversight,
            "Open the reporting dashboards."),
        Make(17, PermissionCodes.ExportData, "Can export data", PermissionGroups.ReportingAndOversight,
            "Download list and report data as files."),

        Make(18, PermissionCodes.ManageCompanySettings, "Can manage company settings", PermissionGroups.Administration,
            "Edit the company profile, branches, departments and designations."),
        Make(19, PermissionCodes.ViewAuditLog, "Can view audit log", PermissionGroups.Administration,
            "Read the record of who did what, and when.")
    ];

    private static Permission Make(int n, string code, string name, string group, string description) => new()
    {
        Id = Id(n),
        Code = code,
        Name = name,
        GroupName = group,
        Description = description,
        SortOrder = n,
        CreatedAt = SeedTimestamp.Value
    };
}

/// <summary>
/// One fixed timestamp for every seeded row. Seed data must not move between migrations,
/// so this cannot be DateTimeOffset.UtcNow.
/// </summary>
public static class SeedTimestamp
{
    public static readonly DateTimeOffset Value = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
}
