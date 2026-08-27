namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// Optional 1:1 statutory and payroll detail (spec sections 4.3 and 5.5). Restricted:
/// readable only by the Super Admin, holders of view_sensitive_data, and the employee themself.
/// <para>
/// <see cref="Pan"/>, <see cref="Aadhaar"/> and <see cref="BankDetails"/> are stored with
/// SQL Server Always Encrypted, so they stay unreadable to a database administrator who does
/// not hold the column encryption key. The API additionally omits this whole record from
/// responses for anyone not on the allow-list - absent, never present-but-masked.
/// </para>
/// </summary>
public class EmployeeStatutory
{
    /// <summary>Primary key and foreign key - one row per employee at most.</summary>
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    /// <summary>Permanent Account Number. Always Encrypted (deterministic).</summary>
    public string? Pan { get; set; }

    /// <summary>Aadhaar number. Always Encrypted (randomized).</summary>
    public string? Aadhaar { get; set; }

    /// <summary>Provident fund universal account number.</summary>
    public string? PfUan { get; set; }

    /// <summary>Employee state insurance number.</summary>
    public string? Esic { get; set; }

    /// <summary>Bank account details as free text. Always Encrypted (randomized).</summary>
    public string? BankDetails { get; set; }

    /// <summary>Annual cost to company.</summary>
    public decimal? Ctc { get; set; }
}
