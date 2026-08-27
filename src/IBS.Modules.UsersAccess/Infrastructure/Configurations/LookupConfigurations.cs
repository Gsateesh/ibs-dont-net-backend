using IBS.Modules.UsersAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Modules.UsersAccess.Infrastructure.Configurations;

/// <summary>Mapping for the single company row.</summary>
public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.LegalName).HasMaxLength(250).IsRequired();
        builder.Property(c => c.Gstin).HasMaxLength(20);
        builder.Property(c => c.RegisteredAddress).HasMaxLength(1000);
        builder.Property(c => c.LogoUrl).HasMaxLength(500);
        builder.Property(c => c.Currency).HasMaxLength(3).IsRequired();
    }
}

/// <summary>Mapping for branches.</summary>
public sealed class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).HasMaxLength(150).IsRequired();
        builder.Property(b => b.City).HasMaxLength(100);
        builder.Property(b => b.Address).HasMaxLength(500);
        builder.Property(b => b.Timezone).HasMaxLength(60).IsRequired();

        builder.HasIndex(b => b.Name).IsUnique();
    }
}

/// <summary>Mapping for departments.</summary>
public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).HasMaxLength(150).IsRequired();
        builder.HasIndex(d => d.Name).IsUnique();
    }
}

/// <summary>Mapping for designations. Descriptive only - it carries no access.</summary>
public sealed class DesignationConfiguration : IEntityTypeConfiguration<Designation>
{
    public void Configure(EntityTypeBuilder<Designation> builder)
    {
        builder.ToTable("Designations");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).HasMaxLength(150).IsRequired();
        builder.HasIndex(d => d.Name).IsUnique();
    }
}
