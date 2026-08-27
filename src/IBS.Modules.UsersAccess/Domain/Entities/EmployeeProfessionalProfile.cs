namespace IBS.Modules.UsersAccess.Domain.Entities;

/// <summary>
/// Optional 1:1 professional detail (spec section 4.3). Kept in its own table rather than as
/// nullable columns on <see cref="Employee"/> because it is genuinely optional.
/// </summary>
public class EmployeeProfessionalProfile
{
    /// <summary>Primary key and foreign key - one row per employee at most.</summary>
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public string? Qualification { get; set; }

    public string? Specialisation { get; set; }

    public int? ExperienceYears { get; set; }

    /// <summary>Software the person can work in, e.g. AutoCAD, SketchUp, 3ds Max.</summary>
    public List<string> SoftwareSkills { get; set; } = [];

    public List<string> Certifications { get; set; } = [];

    public string? PortfolioLink { get; set; }

    public List<string> Languages { get; set; } = [];
}
