using IBS.Modules.UsersAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Modules.UsersAccess.Infrastructure.Configurations;

/// <summary>Mapping for the optional 1:1 professional profile.</summary>
public sealed class EmployeeProfessionalProfileConfiguration : IEntityTypeConfiguration<EmployeeProfessionalProfile>
{
    public void Configure(EntityTypeBuilder<EmployeeProfessionalProfile> builder)
    {
        builder.ToTable("EmployeeProfessionalProfiles");
        builder.HasKey(p => p.EmployeeId);

        builder.Property(p => p.Qualification).HasMaxLength(200);
        builder.Property(p => p.Specialisation).HasMaxLength(200);
        builder.Property(p => p.PortfolioLink).HasMaxLength(500);

        // SoftwareSkills, Certifications and Languages are primitive collections: EF Core maps
        // them to a JSON column automatically, which suits short, order-preserving lists.

        builder.HasOne(p => p.Employee)
            .WithOne(e => e.ProfessionalProfile)
            .HasForeignKey<EmployeeProfessionalProfile>(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

/// <summary>Mapping for the optional 1:1 sales targets.</summary>
public sealed class EmployeeTargetsConfiguration : IEntityTypeConfiguration<EmployeeTargets>
{
    public void Configure(EntityTypeBuilder<EmployeeTargets> builder)
    {
        builder.ToTable("EmployeeTargets");
        builder.HasKey(t => t.EmployeeId);

        builder.Property(t => t.MonthlyTarget).HasPrecision(18, 2);
        builder.Property(t => t.IncentivePercent).HasPrecision(5, 2);
        builder.Property(t => t.MaxDiscountBeforeEscalation).HasPrecision(5, 2);

        builder.HasOne(t => t.Employee)
            .WithOne(e => e.Targets)
            .HasForeignKey<EmployeeTargets>(t => t.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

/// <summary>
/// Mapping for the restricted statutory record. PAN, Aadhaar and bank details are the columns
/// intended for SQL Server Always Encrypted (spec section 4.3); see the migration notes in
/// the README for enabling the column encryption key per environment.
/// </summary>
public sealed class EmployeeStatutoryConfiguration : IEntityTypeConfiguration<EmployeeStatutory>
{
    public void Configure(EntityTypeBuilder<EmployeeStatutory> builder)
    {
        builder.ToTable("EmployeeStatutory");
        builder.HasKey(s => s.EmployeeId);

        // Deterministic encryption on PAN keeps equality lookups possible; the other two are
        // randomized, which is why neither is ever used as a search key.
        builder.Property(s => s.Pan).HasMaxLength(10);
        builder.Property(s => s.Aadhaar).HasMaxLength(20);
        builder.Property(s => s.BankDetails).HasMaxLength(500);
        builder.Property(s => s.PfUan).HasMaxLength(30);
        builder.Property(s => s.Esic).HasMaxLength(30);
        builder.Property(s => s.Ctc).HasPrecision(18, 2);

        builder.HasOne(s => s.Employee)
            .WithOne(e => e.Statutory)
            .HasForeignKey<EmployeeStatutory>(s => s.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

/// <summary>Mapping for uploaded employee documents.</summary>
public sealed class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
{
    public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
    {
        builder.ToTable("EmployeeDocuments");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FileName).HasMaxLength(255).IsRequired();
        builder.Property(d => d.ContentType).HasMaxLength(100);
        builder.Property(d => d.BlobUrl).HasMaxLength(1000).IsRequired();
        builder.Property(d => d.Type).HasConversion<int>();

        builder.HasIndex(d => d.EmployeeId);

        builder.HasOne(d => d.Employee)
            .WithMany(e => e.Documents)
            .HasForeignKey(d => d.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
