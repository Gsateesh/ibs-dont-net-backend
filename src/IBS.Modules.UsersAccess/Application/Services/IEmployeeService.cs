using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.SharedKernel.Primitives;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>
/// The Team and Person Detail pages, and the account lifecycle actions behind them
/// (spec sections 6 and 7). Every mutating method enforces CanManageAccount itself -
/// the API layer never relies on the UI having hidden a button.
/// </summary>
public interface IEmployeeService
{
    /// <summary>Filtered, paged Team list. Visibility is unrestricted beyond manage_users.</summary>
    Task<PagedResult<EmployeeListItemResponse>> ListAsync(EmployeeQuery query, Guid actorId, CancellationToken ct = default);

    /// <summary>One person, including what the caller is allowed to do with the account.</summary>
    Task<EmployeeDetailResponse> GetAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Creates the row with Status = Invited and no password, then emails an invite link
    /// (spec section 6.2).
    /// </summary>
    Task<EmployeeDetailResponse> CreateAsync(CreateEmployeeRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Updates a person. Requires CanManageAccount.</summary>
    Task<EmployeeDetailResponse> UpdateAsync(Guid employeeId, UpdateEmployeeRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Invalidates any unused invite token, issues a fresh one and emails it. The link comes
    /// back in the response only while outbound email is unconfigured.
    /// </summary>
    Task<InvitationLinkResponse> ResendInviteAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Emails a reset link. Never sets or displays a password directly (spec section 6.3); the
    /// link is returned only while outbound email is unconfigured.
    /// </summary>
    Task<InvitationLinkResponse> ResetPasswordAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);

    /// <summary>Blocks sign-in, reversibly.</summary>
    Task<EmployeeDetailResponse> SuspendAsync(Guid employeeId, StatusChangeRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>Lifts a suspension.</summary>
    Task<EmployeeDetailResponse> ReinstateAsync(Guid employeeId, StatusChangeRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Deactivates the account, first running the open-work check that other modules will
    /// fill in later (spec section 7).
    /// </summary>
    Task<DeactivationResponse> DeactivateAsync(Guid employeeId, StatusChangeRequest request, Guid actorId, CancellationToken ct = default);

    /// <summary>
    /// Permanently removes a person and everything owned by their record.
    /// <para>
    /// This is a hard delete, not a status change - prefer <see cref="DeactivateAsync"/> unless
    /// the row genuinely should not exist. Owned rows (professional profile, targets, statutory
    /// record, documents, permission grants and activation tokens) go with it by cascade; the
    /// three references that cannot cascade are detached first, see the implementation.
    /// </para>
    /// </summary>
    Task<DeleteEmployeeResponse> DeleteAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);

    /// <summary>The profile of the signed-in employee.</summary>
    Task<EmployeeDetailResponse> GetOwnProfileAsync(Guid employeeId, CancellationToken ct = default);

    /// <summary>
    /// Updates the personal and contact details of the signed-in employee. Designation,
    /// permissions and status are not in the editable set (spec section 5.6).
    /// </summary>
    Task<EmployeeDetailResponse> UpdateOwnProfileAsync(Guid employeeId, UpdateMyProfileRequest request, CancellationToken ct = default);
}
