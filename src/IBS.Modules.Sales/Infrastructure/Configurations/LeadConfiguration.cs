using IBS.Modules.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Modules.Sales.Infrastructure.Configurations;

/// <summary>Mapping for <see cref="Lead"/>.</summary>
public sealed class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("Leads");
        builder.HasKey(l => l.Id);

        builder.Property(l => l.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(l => l.LastName).HasMaxLength(100).IsRequired();
        builder.Property(l => l.Email).HasMaxLength(256).IsRequired();
        builder.Property(l => l.Phone).HasMaxLength(20).IsRequired();
        builder.Property(l => l.SecondaryPhone).HasMaxLength(20);
        builder.Property(l => l.Notes).HasMaxLength(2000);
        builder.Property(l => l.PropertyName).HasMaxLength(200).IsRequired();
        builder.Property(l => l.PropertyAddress).HasMaxLength(500).IsRequired();
        builder.Property(l => l.PropertyType).HasConversion<int>();
        builder.Property(l => l.Status).HasConversion<int>();
        builder.Property(l => l.BudgetMin).HasColumnType("decimal(18,2)");
        builder.Property(l => l.BudgetMax).HasColumnType("decimal(18,2)");

        // No FK to Employee: Employee lives in the UsersAccess module, and constraining here
        // would force a cross-module project reference (see IEmployeeDirectory).
        builder.HasIndex(l => l.AssignedToEmployeeId);
        builder.HasIndex(l => l.Status);
        builder.HasIndex(l => l.CreatedAt);

        builder.Ignore(l => l.FullName);
    }
}
