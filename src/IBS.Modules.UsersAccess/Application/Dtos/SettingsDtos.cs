using System.ComponentModel.DataAnnotations;

namespace IBS.Modules.UsersAccess.Application.Dtos;

/// <summary>Company profile as shown in Settings.</summary>
public sealed class CompanyResponse
{
    public Guid Id { get; set; }

    /// <example>Interior Business Solutions Pvt Ltd</example>
    public string LegalName { get; set; } = string.Empty;

    /// <example>29ABCDE1234F1Z5</example>
    public string? Gstin { get; set; }

    public string? RegisteredAddress { get; set; }

    public string? LogoUrl { get; set; }

    public DateOnly FinancialYearStart { get; set; }

    /// <example>INR</example>
    public string Currency { get; set; } = "INR";
}

/// <summary>Editable company profile fields.</summary>
public sealed class UpdateCompanyRequest
{
    [Required, MaxLength(250)]
    public string LegalName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Gstin { get; set; }

    [MaxLength(1000)]
    public string? RegisteredAddress { get; set; }

    [MaxLength(500)]
    public string? LogoUrl { get; set; }

    [Required]
    public DateOnly FinancialYearStart { get; set; }

    [Required, MaxLength(3), MinLength(3)]
    public string Currency { get; set; } = "INR";
}

/// <summary>A branch, with the in-use count that governs whether it can be deleted.</summary>
public sealed class BranchResponse
{
    public Guid Id { get; set; }

    /// <example>Bengaluru</example>
    public string Name { get; set; } = string.Empty;

    public string? City { get; set; }

    public string? Address { get; set; }

    /// <example>Asia/Kolkata</example>
    public string Timezone { get; set; } = "Asia/Kolkata";

    /// <summary>Employees currently assigned. Deletion is blocked while this is above zero.</summary>
    public int EmployeeCount { get; set; }
}

/// <summary>Create or update payload for a branch.</summary>
public sealed class BranchRequest
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    [Required, MaxLength(60)]
    public string Timezone { get; set; } = "Asia/Kolkata";
}

/// <summary>A department, with the in-use count that governs whether it can be deleted.</summary>
public sealed class DepartmentResponse
{
    public Guid Id { get; set; }

    /// <example>Design</example>
    public string Name { get; set; } = string.Empty;

    public int EmployeeCount { get; set; }
}

/// <summary>Create or update payload for a department.</summary>
public sealed class DepartmentRequest
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;
}

/// <summary>A designation. Descriptive only - it grants nothing (spec section 5.1).</summary>
public sealed class DesignationResponse
{
    public Guid Id { get; set; }

    /// <example>Interior Designer</example>
    public string Name { get; set; } = string.Empty;

    /// <summary>Drives whether the sales targets section is offered on the Add Person form.</summary>
    public bool IsSalesRole { get; set; }

    public int EmployeeCount { get; set; }
}

/// <summary>Create or update payload for a designation.</summary>
public sealed class DesignationRequest
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    public bool IsSalesRole { get; set; }
}
