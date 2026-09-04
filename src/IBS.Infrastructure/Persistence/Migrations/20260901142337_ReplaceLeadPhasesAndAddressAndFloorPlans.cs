using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceLeadPhasesAndAddressAndFloorPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leads_OverallStatus",
                table: "Leads");

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("06120d67-27dd-d884-3f07-a1ae95e2467c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0903ca1a-8b3e-b72c-03a6-660d9756910a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1e906300-3f3e-a9b2-c0bb-424c5b944e42"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("30ef2e87-7363-f124-8354-496d9ffe3a62"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4a47a2e7-8365-eaae-6545-ed2e7eae168b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4b3f7dbd-bdcf-4c8c-b410-3fa59546010d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("749fac03-9209-88e8-47f9-726c636103d9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7d0546f0-d49f-654b-92f0-60399eb8daa1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9c10712c-989d-ddc5-2eaa-36c92c60440e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b3fd8f3a-1bee-8715-2568-8dfd5b447285"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d772af2a-5c7d-43a1-c06a-75f067322f35"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d7ae821e-a222-3889-5c63-b8d4a26a9d73"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec698ada-87ff-2805-001d-4ddaf7c585f8"));

            migrationBuilder.RenameColumn(
                name: "PropertyAddress",
                table: "Leads",
                newName: "AddressLine1");

            migrationBuilder.AlterColumn<int>(
                name: "Phase",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 100,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Leads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Leads",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Leads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "Leads",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Leads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeadFloorPlanImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlobUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: true),
                    UploadedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadFloorPlanImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadFloorPlanImages_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("229fff54-c9ae-26ec-43ca-d0aba7c8ba85"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wallpaper", "Wallpaper", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("456f15b0-4b02-ce8f-976f-474901d990a4"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("5b4200d0-9d18-0325-2ad1-5d5f8c9e6bd5"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters", "Rafters", 1, "", 1, 2, null, null, "", "" },
                    { new Guid("63f0e8cb-7119-1a2f-fd52-4b9f2576dd59"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "jali-partition", "Jali / Partition", 1, "", 3, 1, null, null, "", "" },
                    { new Guid("96f084c0-009e-394e-7ff8-92565dd2028e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "floating-shelf", "Floating Shelf", 1, "", 0, 2, null, null, "", "" },
                    { new Guid("99efcb62-3315-a9f3-3991-9375d7af31a3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "electrical", "Electrical Work", 3, "", 6, 4, null, null, "", "" },
                    { new Guid("9c93d14d-c9c0-e19c-4c14-662c2df7c4d2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "", 2, 2, null, null, "", "" },
                    { new Guid("a645a351-e9ee-ea6d-654f-d1e4a873f076"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling", 1, "", 3, 1, null, null, "", "" },
                    { new Guid("c14f66cb-c3d6-8027-948e-28f66a1e6a52"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "plumbing", "Plumbing Work", 3, "", 7, 4, null, null, "", "" },
                    { new Guid("c5e01000-9a70-4044-05b2-bef0b439da18"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "flooring", "Flooring", 1, "", 4, 1, null, null, "", "" },
                    { new Guid("e1d6dc1a-a338-9377-67dc-dc10d97c7047"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "blinds", "Blinds", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("ec0959a6-3f22-974f-c725-45ee6340333e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "painting", "Painting", 1, "", 5, 1, null, null, "", "" },
                    { new Guid("eef1154b-e8d3-edab-f3b3-717a56b5842d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-panelling", "Wall Panelling", 1, "", 4, 1, null, null, "", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadFloorPlanImages_LeadId_SortOrder",
                table: "LeadFloorPlanImages",
                columns: new[] { "LeadId", "SortOrder" });

            // --- Data cleanup ---------------------------------------------------------
            //
            // Everything below runs while the old columns are still here; they are dropped at
            // the very end of this method, once the data that lived in them has been moved.

            // Every floor plan already on file becomes the first image of the lead's new set.
            migrationBuilder.Sql(@"
                INSERT INTO LeadFloorPlanImages
                    (Id, LeadId, BlobUrl, FileName, ContentType, SizeInBytes, UploadedAt,
                     SortOrder, CreatedAt, CreatedByEmployeeId)
                SELECT NEWID(), l.Id, l.FloorPlanBlobUrl,
                       ISNULL(l.FloorPlanFileName, 'floor-plan'),
                       l.FloorPlanContentType, l.FloorPlanSizeInBytes,
                       ISNULL(l.FloorPlanUploadedAt, l.CreatedAt), 0,
                       ISNULL(l.FloorPlanUploadedAt, l.CreatedAt), l.CreatedByEmployeeId
                FROM Leads AS l
                WHERE l.FloorPlanBlobUrl IS NOT NULL;");

            // The old 23 phases onto the new 12. Best-effort by design: the old list ran three
            // parallel stage tracks (quotation, design, final quotation) that the new one does
            // not, so the whole design block lands on Quotation discussion - a lead being
            // talked through a design is, to this list, a lead in discussion.
            //
            // The ELSE is not dead code: it catches any row written before Phase had a declared
            // default and left at 0, which was never a valid member of the old enum either.
            migrationBuilder.Sql(@"
                UPDATE Leads SET Phase = CASE Phase
                    WHEN 10 THEN 100    -- NewEnquiry                     -> NewClient
                    WHEN 11 THEN 170    -- Contacted                      -> FollowUp
                    WHEN 12 THEN 100    -- Onboarding                     -> NewClient
                    WHEN 13 THEN 110    -- RequirementsGathering          -> RequirementPending
                    WHEN 14 THEN 110    -- SiteVisitScheduled             -> RequirementPending
                    WHEN 15 THEN 110    -- SiteVisitCompleted             -> RequirementPending
                    WHEN 20 THEN 120    -- QuotationInProgress            -> QuotationPending
                    WHEN 21 THEN 130    -- QuotationShared                -> QuotationDiscussion
                    WHEN 22 THEN 130    -- QuotationRevisionRequired      -> QuotationDiscussion
                    WHEN 23 THEN 210    -- QuotationApproved              -> Interested
                    WHEN 30 THEN 130    -- DesignInProgress               -> QuotationDiscussion
                    WHEN 31 THEN 130    -- DesignShared                   -> QuotationDiscussion
                    WHEN 32 THEN 130    -- DesignRevisionRequired         -> QuotationDiscussion
                    WHEN 33 THEN 210    -- DesignApproved                 -> Interested
                    WHEN 40 THEN 120    -- FinalQuotationInProgress       -> QuotationPending
                    WHEN 41 THEN 130    -- FinalQuotationShared           -> QuotationDiscussion
                    WHEN 42 THEN 130    -- FinalQuotationRevisionRequired -> QuotationDiscussion
                    WHEN 43 THEN 210    -- FinalQuotationApproved         -> Interested
                    WHEN 44 THEN 190    -- FinalQuotationRejected         -> Lost
                    WHEN 50 THEN 200    -- AdvanceReceived                -> Closure
                    WHEN 51 THEN 200    -- ConvertedToProject             -> Closure
                    WHEN 52 THEN 190    -- Lost                           -> Lost
                    WHEN 53 THEN 200    -- Closed                         -> Closure
                    ELSE 100
                END
                WHERE Phase < 100;");

            // OverallStatus is being dropped, and two of its values say something no phase said
            // before and every phase now can: the lead has gone quiet, or it is parked. Those
            // are carried across rather than deleted with the column. Leads already closed out
            // are left alone - Lost, Closure and Fake outrank 'nobody has replied'.
            migrationBuilder.Sql(@"
                UPDATE Leads SET Phase = 150     -- NotResponding
                WHERE OverallStatus IN (7, 10)   -- Dormant, Unreachable
                  AND Phase NOT IN (180, 190, 200);

                UPDATE Leads SET Phase = 160     -- FutureClient
                WHERE OverallStatus = 2          -- OnHold
                  AND Phase NOT IN (180, 190, 200);");

            // The catalogue went from five categories to four. The seed rows above are handled
            // by EF; the lines already priced on existing quotations carry the old key as plain
            // text and are rewritten here, or they would group under a category the picker no
            // longer offers.
            migrationBuilder.Sql(@"
                UPDATE QuotationLineItems
                SET CategoryKey = 'carpentry', CategoryName = 'Carpentry'
                WHERE CategoryKey = 'custom-work';

                UPDATE QuotationLineItems
                SET CategoryKey = 'others', CategoryName = 'Others'
                WHERE CategoryKey IN ('furnishings', 'services');");

            // --- Columns the data above has now been moved out of ----------------------

            migrationBuilder.DropColumn(
                name: "FloorPlanBlobUrl",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "FloorPlanContentType",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "FloorPlanFileName",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "FloorPlanSizeInBytes",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "FloorPlanUploadedAt",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "OverallStatus",
                table: "Leads");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("229fff54-c9ae-26ec-43ca-d0aba7c8ba85"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("456f15b0-4b02-ce8f-976f-474901d990a4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5b4200d0-9d18-0325-2ad1-5d5f8c9e6bd5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("63f0e8cb-7119-1a2f-fd52-4b9f2576dd59"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("96f084c0-009e-394e-7ff8-92565dd2028e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("99efcb62-3315-a9f3-3991-9375d7af31a3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9c93d14d-c9c0-e19c-4c14-662c2df7c4d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a645a351-e9ee-ea6d-654f-d1e4a873f076"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c14f66cb-c3d6-8027-948e-28f66a1e6a52"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5e01000-9a70-4044-05b2-bef0b439da18"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1d6dc1a-a338-9377-67dc-dc10d97c7047"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec0959a6-3f22-974f-c725-45ee6340333e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("eef1154b-e8d3-edab-f3b3-717a56b5842d"));

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Leads");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Leads",
                newName: "PropertyAddress");

            migrationBuilder.AlterColumn<int>(
                name: "Phase",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Leads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FloorPlanBlobUrl",
                table: "Leads",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FloorPlanContentType",
                table: "Leads",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FloorPlanFileName",
                table: "Leads",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FloorPlanSizeInBytes",
                table: "Leads",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FloorPlanUploadedAt",
                table: "Leads",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallStatus",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("06120d67-27dd-d884-3f07-a1ae95e2467c"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "floating-shelf", "Floating Shelf", 1, "", 0, 2, null, null, "", "" },
                    { new Guid("0903ca1a-8b3e-b72c-03a6-660d9756910a"), null, "furnishings", "Furnishings", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wallpaper", "Wallpaper", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("1e906300-3f3e-a9b2-c0bb-424c5b944e42"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-panelling", "Wall Panelling", 1, "", 4, 1, null, null, "", "" },
                    { new Guid("30ef2e87-7363-f124-8354-496d9ffe3a62"), null, "furnishings", "Furnishings", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("4a47a2e7-8365-eaae-6545-ed2e7eae168b"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters", "Rafters", 1, "", 1, 2, null, null, "", "" },
                    { new Guid("4b3f7dbd-bdcf-4c8c-b410-3fa59546010d"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "jali-partition", "Jali / Partition", 1, "", 3, 1, null, null, "", "" },
                    { new Guid("749fac03-9209-88e8-47f9-726c636103d9"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "flooring", "Flooring", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("7d0546f0-d49f-654b-92f0-60399eb8daa1"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("9c10712c-989d-ddc5-2eaa-36c92c60440e"), null, "furnishings", "Furnishings", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "blinds", "Blinds", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("b3fd8f3a-1bee-8715-2568-8dfd5b447285"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "painting", "Painting", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("d772af2a-5c7d-43a1-c06a-75f067322f35"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "electrical", "Electrical Work", 3, "", 3, 4, null, null, "", "" },
                    { new Guid("d7ae821e-a222-3889-5c63-b8d4a26a9d73"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "", 2, 2, null, null, "", "" },
                    { new Guid("ec698ada-87ff-2805-001d-4ddaf7c585f8"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "plumbing", "Plumbing Work", 3, "", 4, 4, null, null, "", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_OverallStatus",
                table: "Leads",
                column: "OverallStatus");

            // --- Reversing the data cleanup -------------------------------------------
            //
            // Best-effort, and lossy in one direction that cannot be helped: the new phases are
            // fewer than the old ones, so a lead that was Design shared and is now Quotation
            // discussion comes back as Quotation shared. Going down recovers the shape of the
            // old model, not the exact row it started from.

            migrationBuilder.Sql(@"
                UPDATE Leads SET Phase = CASE Phase
                    WHEN 100 THEN 10    -- NewClient           -> NewEnquiry
                    WHEN 110 THEN 13    -- RequirementPending  -> RequirementsGathering
                    WHEN 120 THEN 20    -- QuotationPending    -> QuotationInProgress
                    WHEN 130 THEN 21    -- QuotationDiscussion -> QuotationShared
                    WHEN 140 THEN 11    -- AwaitingResponse    -> Contacted
                    WHEN 150 THEN 11    -- NotResponding       -> Contacted
                    WHEN 160 THEN 11    -- FutureClient        -> Contacted
                    WHEN 170 THEN 11    -- FollowUp            -> Contacted
                    WHEN 180 THEN 52    -- Fake                -> Lost
                    WHEN 190 THEN 52    -- Lost                -> Lost
                    WHEN 200 THEN 53    -- Closure             -> Closed
                    WHEN 210 THEN 23    -- Interested          -> QuotationApproved
                    ELSE 10
                END
                WHERE Phase >= 100;");

            // The statuses the phases absorbed, put back where they can be read off the phase.
            migrationBuilder.Sql(@"
                UPDATE Leads SET OverallStatus = CASE
                    WHEN Phase = 11 THEN 8   -- FollowUpRequired
                    WHEN Phase IN (52, 53) THEN 9  -- Closed
                    ELSE 1                   -- Active
                END;");

            migrationBuilder.Sql(@"
                UPDATE QuotationLineItems
                SET CategoryKey = 'custom-work', CategoryName = 'Custom work'
                WHERE CategoryKey = 'carpentry';

                UPDATE QuotationLineItems
                SET CategoryKey = 'furnishings', CategoryName = 'Furnishings'
                WHERE CategoryKey = 'others'
                  AND ItemKey IN ('curtains', 'blinds', 'wallpaper');

                UPDATE QuotationLineItems
                SET CategoryKey = 'services', CategoryName = 'Services'
                WHERE CategoryKey = 'others';");

            // The lead keeps its first image and loses the rest - the old columns hold one.
            migrationBuilder.Sql(@"
                UPDATE l
                SET l.FloorPlanBlobUrl = f.BlobUrl,
                    l.FloorPlanFileName = f.FileName,
                    l.FloorPlanContentType = f.ContentType,
                    l.FloorPlanSizeInBytes = f.SizeInBytes,
                    l.FloorPlanUploadedAt = f.UploadedAt
                FROM Leads AS l
                INNER JOIN (
                    SELECT LeadId, BlobUrl, FileName, ContentType, SizeInBytes, UploadedAt,
                           ROW_NUMBER() OVER (PARTITION BY LeadId ORDER BY SortOrder, UploadedAt) AS rn
                    FROM LeadFloorPlanImages
                ) AS f ON f.LeadId = l.Id AND f.rn = 1;");

            migrationBuilder.DropTable(
                name: "LeadFloorPlanImages");
        }
    }
}
