using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
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

        // Assigned once in LeadService.CreateAsync from the current max, the same pattern
        // FloorPlanImage.SortOrder already uses in this module - no DB sequence, since lead
        // creation is low-volume enough that the pattern's small race window is an acceptable
        // trade for staying consistent with the rest of the codebase. The unique index below is
        // the backstop: a collision fails loudly at SaveChanges rather than issuing a duplicate.
        builder.Property(l => l.CustomerNumber).IsRequired();
        builder.HasIndex(l => l.CustomerNumber).IsUnique();
        builder.Ignore(l => l.CustomerCode);

        builder.Property(l => l.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(l => l.LastName).HasMaxLength(100);
        builder.Property(l => l.Email).HasMaxLength(256).IsRequired();
        builder.Property(l => l.Phone).HasMaxLength(20).IsRequired();
        builder.Property(l => l.SecondaryPhone).HasMaxLength(20);
        builder.Property(l => l.Notes).HasMaxLength(2000);
        builder.Property(l => l.PropertyName).HasMaxLength(200).IsRequired();
        builder.Property(l => l.AddressLine1).HasMaxLength(500).IsRequired();
        builder.Property(l => l.AddressLine2).HasMaxLength(500);
        builder.Property(l => l.City).HasMaxLength(100);
        builder.Property(l => l.PinCode).HasMaxLength(12);
        builder.Property(l => l.State).HasMaxLength(100);
        builder.Property(l => l.PropertyType).HasConversion<int>();
        builder.Property(l => l.PropertySizeUnit).HasConversion<int>();
        builder.Property(l => l.PropertyConfiguration).HasConversion<int>();
        builder.Property(l => l.Phase)
            .HasConversion<int>()
            .HasDefaultValue(LeadPhase.NewClient);
        builder.Property(l => l.PropertySize).HasColumnType("decimal(18,2)");
        builder.Property(l => l.BudgetMin).HasColumnType("decimal(18,2)");
        builder.Property(l => l.BudgetMax).HasColumnType("decimal(18,2)");

        // No FK to Employee: Employee lives in the UsersAccess module, and constraining here
        // would force a cross-module project reference (see IEmployeeDirectory).
        builder.HasIndex(l => l.AssignedToEmployeeId);
        builder.HasIndex(l => l.Phase);
        builder.HasIndex(l => l.CreatedAt);

        // The follow-up worklist ("who do I have to call today") sorts on this.
        builder.HasIndex(l => l.NextFollowUpDate);

        builder.HasMany(l => l.FloorPlans)
            .WithOne(f => f.Lead!)
            .HasForeignKey(f => f.LeadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.Rooms)
            .WithOne(r => r.Lead!)
            .HasForeignKey(r => r.LeadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(l => l.FullName);
    }
}

/// <summary>Mapping for <see cref="LeadRoom"/>.</summary>
public sealed class LeadRoomConfiguration : IEntityTypeConfiguration<LeadRoom>
{
    public void Configure(EntityTypeBuilder<LeadRoom> builder)
    {
        builder.ToTable("LeadRooms");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomKey).HasMaxLength(100);
        builder.Property(r => r.RoomName).HasMaxLength(150).IsRequired();
        builder.Property(r => r.Notes).HasMaxLength(1000);

        builder.HasIndex(r => r.LeadId);

        builder.HasMany(r => r.Requirements)
            .WithOne(i => i.Room!)
            .HasForeignKey(i => i.LeadRoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

/// <summary>Mapping for <see cref="LeadRoomRequirement"/>.</summary>
public sealed class LeadRoomRequirementConfiguration : IEntityTypeConfiguration<LeadRoomRequirement>
{
    public void Configure(EntityTypeBuilder<LeadRoomRequirement> builder)
    {
        builder.ToTable("LeadRoomRequirements");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ItemKey).HasMaxLength(100);
        builder.Property(i => i.ItemName).HasMaxLength(200).IsRequired();
        builder.Property(i => i.Notes).HasMaxLength(1000);

        builder.HasIndex(i => i.LeadRoomId);
    }
}

/// <summary>Mapping for <see cref="LeadFloorPlanImage"/>.</summary>
public sealed class LeadFloorPlanImageConfiguration : IEntityTypeConfiguration<LeadFloorPlanImage>
{
    public void Configure(EntityTypeBuilder<LeadFloorPlanImage> builder)
    {
        builder.ToTable("LeadFloorPlanImages");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.BlobUrl).HasMaxLength(1000).IsRequired();
        builder.Property(f => f.FileName).HasMaxLength(255).IsRequired();
        builder.Property(f => f.ContentType).HasMaxLength(150);

        // The viewer pages through these in order, so they are always read as a sorted set.
        builder.HasIndex(f => new { f.LeadId, f.SortOrder });
    }
}
