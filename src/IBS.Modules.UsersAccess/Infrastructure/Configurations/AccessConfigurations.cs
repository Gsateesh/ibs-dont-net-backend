using IBS.Modules.UsersAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Modules.UsersAccess.Infrastructure.Configurations;

/// <summary>Mapping for the permission catalogue.</summary>
public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Code).HasMaxLength(80).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.GroupName).HasMaxLength(100).IsRequired();

        // The code is the contract with the codebase, so it is unique at the database level.
        builder.HasIndex(p => p.Code).IsUnique();
    }
}

/// <summary>Mapping for the grant join table.</summary>
public sealed class EmployeePermissionConfiguration : IEntityTypeConfiguration<EmployeePermission>
{
    public void Configure(EntityTypeBuilder<EmployeePermission> builder)
    {
        builder.ToTable("EmployeePermissions");

        // Composite key: one grant per employee per permission, by construction.
        builder.HasKey(ep => new { ep.EmployeeId, ep.PermissionId });

        builder.HasOne(ep => ep.Employee)
            .WithMany(e => e.Permissions)
            .HasForeignKey(ep => ep.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ep => ep.Permission)
            .WithMany(p => p.EmployeePermissions)
            .HasForeignKey(ep => ep.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Deliberately Restrict: the granter must stay resolvable for the audit trail.
        builder.HasOne(ep => ep.GrantedByEmployee)
            .WithMany()
            .HasForeignKey(ep => ep.GrantedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(ep => ep.PermissionId);
    }
}

/// <summary>Mapping for invite and reset tokens.</summary>
public sealed class ActivationTokenConfiguration : IEntityTypeConfiguration<ActivationToken>
{
    public void Configure(EntityTypeBuilder<ActivationToken> builder)
    {
        builder.ToTable("ActivationTokens");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.TokenHash).HasMaxLength(128).IsRequired();
        builder.Property(t => t.Purpose).HasConversion<int>();

        // Redemption looks the token up by hash, so that is the index that matters.
        builder.HasIndex(t => t.TokenHash).IsUnique();
        builder.HasIndex(t => new { t.EmployeeId, t.Purpose });

        builder.HasOne(t => t.Employee)
            .WithMany(e => e.ActivationTokens)
            .HasForeignKey(t => t.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

/// <summary>Mapping for the append-only audit log.</summary>
public sealed class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Action).HasMaxLength(100).IsRequired();
        builder.Property(a => a.TargetType).HasMaxLength(100).IsRequired();
        builder.Property(a => a.MetadataJson).HasColumnType("nvarchar(max)");

        builder.HasIndex(a => a.Timestamp);
        builder.HasIndex(a => a.TargetId);
        builder.HasIndex(a => a.ActorEmployeeId);

        // The log outlives the people in it: deleting an employee must never delete their trail.
        builder.HasOne(a => a.ActorEmployee)
            .WithMany()
            .HasForeignKey(a => a.ActorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
