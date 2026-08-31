namespace IBS.SharedKernel.Auditing;

/// <summary>
/// The audit-log writer every module calls (spec sections 3 and 4.5). Writes are appended
/// inside the unit of work of the caller, so an audit row never survives a rolled-back change.
/// </summary>
public interface IAuditLogWriter
{
    /// <summary>
    /// Records one action against one target.
    /// </summary>
    /// <param name="action">Verb from <see cref="AuditActions"/>, e.g. <c>employee.suspended</c>.</param>
    /// <param name="targetType">Entity type acted upon, e.g. <c>Employee</c>.</param>
    /// <param name="targetId">Identifier of the row acted upon.</param>
    /// <param name="actorEmployeeId">Who acted. Null for system or seed actions.</param>
    /// <param name="metadata">Anything worth keeping: before/after values, reason, request id.</param>
    /// <param name="ct">Cancellation token.</param>
    Task WriteAsync(
        string action,
        string targetType,
        Guid? targetId,
        Guid? actorEmployeeId,
        object? metadata = null,
        CancellationToken ct = default);
}

/// <summary>Canonical audit action verbs, so the log stays queryable.</summary>
public static class AuditActions
{
    public const string EmployeeCreated = "employee.created";
    public const string EmployeeUpdated = "employee.updated";
    public const string EmployeeSuspended = "employee.suspended";
    public const string EmployeeReinstated = "employee.reinstated";
    public const string EmployeeDeactivated = "employee.deactivated";
    public const string EmployeeSelfUpdated = "employee.self_updated";
    public const string EmployeeDeleted = "employee.deleted";

    public const string InviteSent = "invite.sent";
    public const string InviteResent = "invite.resent";
    public const string InviteCompleted = "invite.completed";

    public const string PasswordResetRequested = "password.reset_requested";
    public const string PasswordResetCompleted = "password.reset_completed";
    public const string PasswordChanged = "password.changed";

    public const string LoginSucceeded = "auth.login_succeeded";
    public const string LoginFailed = "auth.login_failed";
    public const string AccountLocked = "auth.account_locked";
    public const string Logout = "auth.logout";

    public const string PermissionsUpdated = "permissions.updated";
    public const string PermissionCatalogueUpdated = "permission.catalogue_updated";

    public const string StatutoryViewed = "statutory.viewed";
    public const string StatutoryUpdated = "statutory.updated";

    public const string DocumentUploaded = "document.uploaded";
    public const string DocumentDeleted = "document.deleted";

    public const string CompanyUpdated = "company.updated";
    public const string BranchCreated = "branch.created";
    public const string BranchUpdated = "branch.updated";
    public const string BranchDeleted = "branch.deleted";
    public const string DepartmentCreated = "department.created";
    public const string DepartmentUpdated = "department.updated";
    public const string DepartmentDeleted = "department.deleted";
    public const string DesignationCreated = "designation.created";
    public const string DesignationUpdated = "designation.updated";
    public const string DesignationDeleted = "designation.deleted";

    public const string LeadCreated = "lead.created";
    public const string LeadUpdated = "lead.updated";
    public const string LeadAssigned = "lead.assigned";
    public const string LeadReassigned = "lead.reassigned";
    public const string LeadUnassigned = "lead.unassigned";
    public const string LeadBulkAssigned = "lead.bulk_assigned";
    public const string LeadDeleted = "lead.deleted";
    public const string LeadFloorPlanUploaded = "lead.floor_plan_uploaded";
    public const string LeadFloorPlanDeleted = "lead.floor_plan_deleted";

    public const string QuotationCreated = "quotation.created";
    public const string QuotationUpdated = "quotation.updated";
    public const string QuotationVersionCreated = "quotation.version_created";
    public const string QuotationDeleted = "quotation.deleted";
    public const string QuotationPdfGenerated = "quotation.pdf_generated";
    public const string QuotationSent = "quotation.sent";
    public const string QuotationApproved = "quotation.approved";
    public const string QuotationRevisionRequested = "quotation.revision_requested";
}
