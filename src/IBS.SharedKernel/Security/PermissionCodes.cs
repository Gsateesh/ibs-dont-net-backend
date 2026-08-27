namespace IBS.SharedKernel.Security;

/// <summary>
/// The 20 permission codes seeded by migration (spec section 4.4). Referenced by every module
/// so a typo becomes a compile error rather than a silently-failing permission check.
/// A new permission is only ever added here together with the migration that seeds it.
/// </summary>
public static class PermissionCodes
{
    // People and access
    public const string ManageUsers = "manage_users";
    public const string ManagePermissions = "manage_permissions";
    public const string ViewSensitiveData = "view_sensitive_data";

    // Sales pipeline
    public const string ManageCustomerOnboarding = "manage_customer_onboarding";
    public const string ManageQuotations = "manage_quotations";
    public const string ManageLeads = "manage_leads";

    // Design and estimation
    public const string ManageDesigns = "manage_designs";
    public const string ManageBoq = "manage_boq";

    // Delivery and execution
    public const string ManageProjects = "manage_projects";
    public const string ManageTasks = "manage_tasks";
    public const string ManageSiteProgress = "manage_site_progress";

    // Procurement, inventory and vendors
    public const string ManageProcurement = "manage_procurement";
    public const string ManageInventory = "manage_inventory";
    public const string ManageVendors = "manage_vendors";

    // Finance
    public const string ManageInvoices = "manage_invoices";

    // Client portal
    public const string ManagePortal = "manage_portal";

    // Reporting and oversight
    public const string ViewReports = "view_reports";
    public const string ExportData = "export_data";

    // Administration
    public const string ManageCompanySettings = "manage_company_settings";
    public const string ViewAuditLog = "view_audit_log";

    /// <summary>
    /// High-impact permissions (spec section 5.4): granting either of these requires the actor to
    /// already hold <see cref="ManagePermissions"/>, not merely <see cref="ManageUsers"/>.
    /// </summary>
    public static readonly IReadOnlySet<string> HighImpact =
        new HashSet<string>(StringComparer.Ordinal) { ManagePermissions, ViewSensitiveData };

    /// <summary>Every code, in catalogue order.</summary>
    public static readonly IReadOnlyList<string> All =
    [
        ManageUsers, ManagePermissions, ViewSensitiveData,
        ManageCustomerOnboarding, ManageQuotations, ManageLeads,
        ManageDesigns, ManageBoq,
        ManageProjects, ManageTasks, ManageSiteProgress,
        ManageProcurement, ManageInventory, ManageVendors,
        ManageInvoices, ManagePortal,
        ViewReports, ExportData,
        ManageCompanySettings, ViewAuditLog
    ];
}

/// <summary>Cosmetic grouping names used by the permission checklist UI.</summary>
public static class PermissionGroups
{
    public const string PeopleAndAccess = "People & access";
    public const string SalesPipeline = "Sales pipeline";
    public const string DesignAndEstimation = "Design & estimation";
    public const string DeliveryAndExecution = "Delivery & execution";
    public const string ProcurementInventoryVendors = "Procurement, inventory & vendors";
    public const string Finance = "Finance";
    public const string ClientPortal = "Client portal";
    public const string ReportingAndOversight = "Reporting & oversight";
    public const string Administration = "Administration";
}
