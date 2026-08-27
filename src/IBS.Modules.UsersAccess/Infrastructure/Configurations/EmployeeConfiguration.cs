using IBS.Modules.UsersAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Modules.UsersAccess.Infrastructure.Configurations;

/// <summary>Mapping for <see cref="Employee"/>, including the two rules that must hold in the database itself.</summary>
public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.PhotoUrl).HasMaxLength(500);
        builder.Property(e => e.EmployeeCode).HasMaxLength(30).IsRequired();
        builder.Property(e => e.PasswordHash).HasMaxLength(500);
        builder.Property(e => e.EmploymentType).HasConversion<int>();
        builder.Property(e => e.Status).HasConversion<int>();

        // The login identifier, so uniqueness is enforced by the database, not by a check.
        builder.HasIndex(e => e.Email).IsUnique();
        builder.HasIndex(e => e.EmployeeCode).IsUnique();
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => new { e.DepartmentId, e.BranchId });

        // Spec section 4.2: only one row may ever carry the Super Admin flag. A filtered unique
        // index makes a second one impossible even if application code is bypassed.
        builder.HasIndex(e => e.IsSuperAdmin)
            .IsUnique()
            .HasFilter("[IsSuperAdmin] = 1")
            .HasDatabaseName("UX_Employees_SingleSuperAdmin");

        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Designation)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DesignationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Branch)
            .WithMany(b => b.Employees)
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ReportingManager)
            .WithMany(e => e.DirectReports)
            .HasForeignKey(e => e.ReportingManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(e => e.FullName);
    }
}
