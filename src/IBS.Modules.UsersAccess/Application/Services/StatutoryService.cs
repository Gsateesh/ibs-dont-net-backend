using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Application.Dtos;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.SharedKernel.Auditing;
using IBS.SharedKernel.Exceptions;
using IBS.SharedKernel.Security;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.UsersAccess.Application.Services;

/// <summary>
/// The restricted statutory record (spec sections 4.3 and 5.5). Readable by the Super Admin,
/// holders of view_sensitive_data, and the employee themself - and by nobody else, in the
/// strong sense that the record is absent from the response rather than masked.
/// </summary>
public interface IStatutoryService
{
    /// <summary>Reads the statutory record. Throws Forbidden for anyone off the allow-list.</summary>
    Task<StatutoryDto> GetAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);

    /// <summary>Creates or replaces the statutory record.</summary>
    Task<StatutoryDto> UpsertAsync(Guid employeeId, StatutoryDto request, Guid actorId, CancellationToken ct = default);

    /// <summary>Whether the actor may see the record at all, used to shape the detail response.</summary>
    Task<bool> CanViewAsync(Guid employeeId, Guid actorId, CancellationToken ct = default);
}

/// <inheritdoc cref="IStatutoryService" />
public sealed class StatutoryService(
    IUsersAccessDbContext db,
    IPermissionChecker permissions,
    IAuditLogWriter audit) : IStatutoryService
{
    public async Task<bool> CanViewAsync(Guid employeeId, Guid actorId, CancellationToken ct = default) =>
        actorId == employeeId ||
        await permissions.HasPermissionAsync(actorId, PermissionCodes.ViewSensitiveData, ct);

    public async Task<StatutoryDto> GetAsync(Guid employeeId, Guid actorId, CancellationToken ct = default)
    {
        await RequireAccessAsync(employeeId, actorId, ct);

        var record = await db.EmployeeStatutories
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.EmployeeId == employeeId, ct);

        if (record is null)
        {
            // Nothing recorded yet: an empty shape, not a 404, so the form can bind to it.
            return new StatutoryDto();
        }

        await audit.WriteAsync(AuditActions.StatutoryViewed, nameof(Employee), employeeId, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return new StatutoryDto
        {
            Pan = record.Pan,
            Aadhaar = record.Aadhaar,
            PfUan = record.PfUan,
            Esic = record.Esic,
            BankDetails = record.BankDetails,
            Ctc = record.Ctc
        };
    }

    public async Task<StatutoryDto> UpsertAsync(
        Guid employeeId, StatutoryDto request, Guid actorId, CancellationToken ct = default)
    {
        await RequireAccessAsync(employeeId, actorId, ct);

        if (!await db.Employees.AnyAsync(e => e.Id == employeeId, ct))
        {
            throw new NotFoundException("Employee", employeeId);
        }

        var record = await db.EmployeeStatutories.FirstOrDefaultAsync(s => s.EmployeeId == employeeId, ct);

        if (record is null)
        {
            record = new EmployeeStatutory { EmployeeId = employeeId };
            db.EmployeeStatutories.Add(record);
        }

        record.Pan = request.Pan?.Trim();
        record.Aadhaar = request.Aadhaar?.Trim();
        record.PfUan = request.PfUan?.Trim();
        record.Esic = request.Esic?.Trim();
        record.BankDetails = request.BankDetails?.Trim();
        record.Ctc = request.Ctc;

        // Values are never echoed into the audit log - the point of the record is that it stays put.
        await audit.WriteAsync(AuditActions.StatutoryUpdated, nameof(Employee), employeeId, actorId, null, ct);
        await db.SaveChangesAsync(ct);

        return request;
    }

    private async Task RequireAccessAsync(Guid employeeId, Guid actorId, CancellationToken ct)
    {
        if (!await CanViewAsync(employeeId, actorId, ct))
        {
            throw new ForbiddenException("Statutory details require the view_sensitive_data permission.");
        }
    }
}
