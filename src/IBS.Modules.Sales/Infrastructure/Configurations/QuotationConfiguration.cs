using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBS.Modules.Sales.Infrastructure.Configurations;

/// <summary>Mapping for <see cref="Quotation"/>.</summary>
public sealed class QuotationConfiguration : IEntityTypeConfiguration<Quotation>
{
    public void Configure(EntityTypeBuilder<Quotation> builder)
    {
        builder.ToTable("Quotations");
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Stage).HasConversion<int>();
        builder.Property(q => q.Status).HasConversion<int>().HasDefaultValue(QuotationStatus.Draft);
        builder.Property(q => q.Title).HasMaxLength(200);

        builder.Property(q => q.Subtotal).HasColumnType("decimal(18,2)");
        builder.Property(q => q.DiscountPercent).HasColumnType("decimal(5,2)");
        builder.Property(q => q.DiscountAmount).HasColumnType("decimal(18,2)");
        builder.Property(q => q.TaxableValue).HasColumnType("decimal(18,2)");
        builder.Property(q => q.GstRatePercent).HasColumnType("decimal(5,2)");
        builder.Property(q => q.GstAmount).HasColumnType("decimal(18,2)");
        builder.Property(q => q.TransportCharges).HasColumnType("decimal(18,2)");
        builder.Property(q => q.InstallationCharges).HasColumnType("decimal(18,2)");
        builder.Property(q => q.GrandTotal).HasColumnType("decimal(18,2)");

        // Deleting a lead takes its quotations with it, exactly as it takes its rooms.
        builder.HasOne(q => q.Lead)
            .WithMany()
            .HasForeignKey(q => q.LeadId)
            .OnDelete(DeleteBehavior.Cascade);

        // A version number is unique within a stage: "Initial v2" identifies exactly one row.
        builder.HasIndex(q => new { q.LeadId, q.Stage, q.VersionNumber }).IsUnique();

        // Filtered, so that "exactly one current version per stage" is enforced by the database
        // rather than by the service. Getting it wrong means the workspace opens two versions or
        // none, and neither failure shows up until somebody reports a wrong total.
        builder.HasIndex(q => new { q.LeadId, q.Stage })
            .IsUnique()
            .HasFilter("[IsCurrent] = 1")
            .HasDatabaseName("IX_Quotations_LeadId_Stage_Current");

        builder.HasIndex(q => q.Status);

        builder.HasMany(q => q.Rooms)
            .WithOne(r => r.Quotation!)
            .HasForeignKey(r => r.QuotationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.Documents)
            .WithOne(d => d.Quotation!)
            .HasForeignKey(d => d.QuotationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(q => q.IsEditable);
    }
}

/// <summary>Mapping for <see cref="QuotationRoom"/>.</summary>
public sealed class QuotationRoomConfiguration : IEntityTypeConfiguration<QuotationRoom>
{
    public void Configure(EntityTypeBuilder<QuotationRoom> builder)
    {
        builder.ToTable("QuotationRooms");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomKey).HasMaxLength(100);
        builder.Property(r => r.RoomName).HasMaxLength(150).IsRequired();
        builder.Property(r => r.DefaultCarcassMaterial).HasMaxLength(100);
        builder.Property(r => r.DefaultShutterMaterial).HasMaxLength(100);
        builder.Property(r => r.DefaultFinish).HasMaxLength(100);
        builder.Property(r => r.Notes).HasMaxLength(1000);
        builder.Property(r => r.RoomTotal).HasColumnType("decimal(18,2)");

        // No foreign key to LeadRooms on purpose: SourceLeadRoomId records where the room was
        // copied from, and removing a room from the brief must never cascade into a quotation
        // that has already been sent.
        builder.HasIndex(r => r.QuotationId);

        builder.HasMany(r => r.LineItems)
            .WithOne(i => i.Room!)
            .HasForeignKey(i => i.QuotationRoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

/// <summary>Mapping for <see cref="QuotationLineItem"/>.</summary>
public sealed class QuotationLineItemConfiguration : IEntityTypeConfiguration<QuotationLineItem>
{
    public void Configure(EntityTypeBuilder<QuotationLineItem> builder)
    {
        builder.ToTable("QuotationLineItems");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.CategoryKey).HasMaxLength(100).IsRequired();
        builder.Property(i => i.CategoryName).HasMaxLength(150).IsRequired();
        builder.Property(i => i.ItemKey).HasMaxLength(100);
        builder.Property(i => i.ItemName).HasMaxLength(250).IsRequired();
        builder.Property(i => i.VariantKey).HasMaxLength(100);
        builder.Property(i => i.CarcassMaterial).HasMaxLength(100);
        builder.Property(i => i.ShutterMaterial).HasMaxLength(100);
        builder.Property(i => i.Finish).HasMaxLength(100);
        builder.Property(i => i.Notes).HasMaxLength(1000);
        builder.Property(i => i.InternalNotes).HasMaxLength(1000);

        builder.Property(i => i.PricingType).HasConversion<int>();
        builder.Property(i => i.UnitOfMeasure).HasConversion<int>();

        builder.Property(i => i.WidthFeet).HasColumnType("decimal(18,2)");
        builder.Property(i => i.HeightFeet).HasColumnType("decimal(18,2)");
        builder.Property(i => i.DepthFeet).HasColumnType("decimal(18,2)");

        // Three decimal places rather than two: 47.6 sq.ft is exact, but a running-foot run
        // split across a quantity is not, and rounding the quantity before the rate is applied
        // pushes the error into the money.
        builder.Property(i => i.BillableQuantity).HasColumnType("decimal(18,3)");

        builder.Property(i => i.Rate).HasColumnType("decimal(18,2)");
        builder.Property(i => i.BaseAmount).HasColumnType("decimal(18,2)");
        builder.Property(i => i.HardwareAmount).HasColumnType("decimal(18,2)");
        builder.Property(i => i.AccessoryAmount).HasColumnType("decimal(18,2)");
        builder.Property(i => i.Amount).HasColumnType("decimal(18,2)");

        builder.HasIndex(i => i.QuotationRoomId);
    }
}

/// <summary>Mapping for <see cref="QuotationDocument"/>.</summary>
public sealed class QuotationDocumentConfiguration : IEntityTypeConfiguration<QuotationDocument>
{
    public void Configure(EntityTypeBuilder<QuotationDocument> builder)
    {
        builder.ToTable("QuotationDocuments");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.BlobUrl).HasMaxLength(1000).IsRequired();
        builder.Property(d => d.FileName).HasMaxLength(255).IsRequired();
        builder.Property(d => d.ContentType).HasMaxLength(150).IsRequired();

        builder.HasIndex(d => d.QuotationId);
    }
}

/// <summary>Mapping for <see cref="QuotationCatalogEntry"/>.</summary>
public sealed class QuotationCatalogEntryConfiguration : IEntityTypeConfiguration<QuotationCatalogEntry>
{
    public void Configure(EntityTypeBuilder<QuotationCatalogEntry> builder)
    {
        builder.ToTable("QuotationCatalogEntries");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.RoomKey).HasMaxLength(100);
        builder.Property(e => e.CategoryKey).HasMaxLength(100).IsRequired();
        builder.Property(e => e.CategoryName).HasMaxLength(150).IsRequired();
        builder.Property(e => e.ItemKey).HasMaxLength(100).IsRequired();
        builder.Property(e => e.ItemName).HasMaxLength(250).IsRequired();
        builder.Property(e => e.VariantKey).HasMaxLength(100);
        builder.Property(e => e.VariantName).HasMaxLength(150);

        builder.Property(e => e.PricingType).HasConversion<int>();
        builder.Property(e => e.UnitOfMeasure).HasConversion<int>();
        builder.Property(e => e.BasePrice).HasColumnType("decimal(18,2)");

        builder.HasIndex(e => new { e.RoomKey, e.CategoryKey, e.ItemKey, e.VariantKey }).IsUnique();
        builder.HasIndex(e => new { e.RoomKey, e.CategoryKey });
    }
}

/// <summary>Mapping for <see cref="QuotationRate"/>.</summary>
public sealed class QuotationRateConfiguration : IEntityTypeConfiguration<QuotationRate>
{
    public void Configure(EntityTypeBuilder<QuotationRate> builder)
    {
        builder.ToTable("QuotationRates");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.ItemKey).HasMaxLength(100).IsRequired();
        builder.Property(r => r.VariantKey).HasMaxLength(100);
        builder.Property(r => r.CarcassMaterial).HasMaxLength(100);
        builder.Property(r => r.ShutterMaterial).HasMaxLength(100);
        builder.Property(r => r.Finish).HasMaxLength(100);
        builder.Property(r => r.UnitOfMeasure).HasConversion<int>();
        builder.Property(r => r.RatePerUnit).HasColumnType("decimal(18,2)");

        // One rate per specification per effective date. The date belongs in the key because a
        // price change is a new row, and the second change would otherwise collide with the first.
        builder.HasIndex(r => new
        {
            r.ItemKey, r.VariantKey, r.CarcassMaterial, r.ShutterMaterial, r.Finish, r.EffectiveFrom
        }).IsUnique().HasDatabaseName("IX_QuotationRates_Specification");

        builder.HasIndex(r => r.ItemKey);
    }
}
