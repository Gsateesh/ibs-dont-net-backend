using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuotationCatalogEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ItemKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VariantKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VariantName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PricingType = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationCatalogEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuotationRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VariantKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarcassMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShutterMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Finish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    RatePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectiveFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stage = table.Column<int>(type: "int", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    ClonedFromQuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GstRatePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GstAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallationCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreparedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SharedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SharedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApprovedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlobUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    GeneratedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    GeneratedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationDocuments_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    SourceLeadRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DefaultCarcassMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DefaultShutterMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DefaultFinish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RoomTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationRooms_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotationRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ItemKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VariantKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    PricingType = table.Column<int>(type: "int", nullable: false),
                    CarcassMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShutterMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Finish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WidthFeet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HeightFeet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepthFeet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    BillableQuantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRateOverridden = table.Column<bool>(type: "bit", nullable: false),
                    BaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HardwareAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccessoryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationLineItems_QuotationRooms_QuotationRoomId",
                        column: x => x.QuotationRoomId,
                        principalTable: "QuotationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9e5b0000-0000-4000-8000-000000000005"),
                column: "Description",
                value: "Build and revise quotation drafts, and generate their PDFs.");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByEmployeeId", "Description", "GroupName", "Name", "SortOrder", "UpdatedAt", "UpdatedByEmployeeId" },
                values: new object[] { new Guid("9e5b0000-0000-4000-8000-000000000022"), "approve_quotations", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Email a quotation to the client and record their approval or rejection.", "Sales pipeline", "Can issue and approve quotations", 22, null, null });

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("018dc07f-1799-7879-4793-9851b481329b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Bookshelf", 1, "study-room", 1, 1, null, null, "", "" },
                    { new Guid("034b2d53-803c-5256-11c2-76d5a69834ba"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("06120d67-27dd-d884-3f07-a1ae95e2467c"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "floating-shelf", "Floating Shelf", 1, "", 0, 2, null, null, "", "" },
                    { new Guid("06899d2c-932f-b3ed-f30c-22012cf5abda"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "master-bedroom", 3, 4, null, null, "", "" },
                    { new Guid("0903ca1a-8b3e-b72c-03a6-660d9756910a"), null, "furnishings", "Furnishings", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wallpaper", "Wallpaper", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("0cb883a3-5cd3-a0e9-a8f1-65f6af7764a2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-storage", "Dining Storage", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("0e418c62-218a-a292-b444-62b78d1e2ddd"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "", 1, 4, null, null, "", "" },
                    { new Guid("12458a69-e70e-a077-80b5-8c569cae3b4f"), 48000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-table", "Dining Table", 2, "", 3, 4, null, null, "", "" },
                    { new Guid("143e910d-cd88-7362-a677-2d42a60e333c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "kids-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("14c1546f-3a5f-9563-a02c-0ca05d57f026"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "living-room", 2, 1, null, null, "", "" },
                    { new Guid("17d2cd6d-77d7-961a-59e6-46b000669757"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "master-bedroom", 4, 4, null, null, "", "" },
                    { new Guid("1e906300-3f3e-a9b2-c0bb-424c5b944e42"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-panelling", "Wall Panelling", 1, "", 4, 1, null, null, "", "" },
                    { new Guid("22ca38db-31ce-a32c-4356-276a47c4bde0"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("2d81bc4c-c4d2-3bd7-c042-fe55398d109e"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "guest-bedroom", 3, 4, null, null, "", "" },
                    { new Guid("30ef2e87-7363-f124-8354-496d9ffe3a62"), null, "furnishings", "Furnishings", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("33cdfa99-f24b-dccf-2c74-ebe72286bb36"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "master-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("34897107-6d2d-10b7-e160-bd203ce54d75"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("361ba840-afeb-141b-2b1b-721e261c2743"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("36de33d1-4bb5-a59e-83fc-a7e387c91939"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "bedroom", 5, 1, null, null, "", "" },
                    { new Guid("3a38fb1f-5b7d-13c5-cd8e-389d6c8f591d"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "display-unit", "Display Unit", 1, "living-room", 3, 1, null, null, "", "" },
                    { new Guid("3f648144-247f-d771-fb18-687228688a4a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "bedroom", 6, 2, null, null, "", "" },
                    { new Guid("44783469-99db-ce91-8b9f-3384dc1d9ea2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "kids-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("46d782f6-e37b-45bd-d741-c1defaf5c3e4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("4a47a2e7-8365-eaae-6545-ed2e7eae168b"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters", "Rafters", 1, "", 1, 2, null, null, "", "" },
                    { new Guid("4b3f7dbd-bdcf-4c8c-b410-3fa59546010d"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "jali-partition", "Jali / Partition", 1, "", 3, 1, null, null, "", "" },
                    { new Guid("54a33f97-e744-65f6-9f16-9d83900b66b3"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "kitchen", 1, 1, null, null, "wooden", "Wooden" },
                    { new Guid("55c14338-999a-8091-2f35-4713f13b982f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "master-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("56241518-5690-f55e-eede-d4298bdada13"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "kitchen", 2, 1, null, null, "glass", "Glass" },
                    { new Guid("5a176187-d164-dc4e-aee3-6e5659504170"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "living-room", 1, 1, null, null, "", "" },
                    { new Guid("5deff5ec-d3ee-13d6-1672-4d64a9eb5cd9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("60e486f2-470e-0d43-5940-3415fa30f009"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "bedroom", 4, 4, null, null, "", "" },
                    { new Guid("6a6e87af-fe4f-7763-d84c-8058582fb6be"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "guest-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("749fac03-9209-88e8-47f9-726c636103d9"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "flooring", "Flooring", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("7579bff1-00f9-2a92-d58d-6315205975f4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "pooja-room", 0, 1, null, null, "", "" },
                    { new Guid("7afc6fc9-132c-ac4b-9b2c-aab07ea5addc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tall-unit", "Tall Unit", 1, "kitchen", 4, 1, null, null, "pantry", "Pantry" },
                    { new Guid("7d0546f0-d49f-654b-92f0-60399eb8daa1"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("84d4bc6f-fac7-8785-14d0-43bafaecab62"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "guest-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("8622bcbe-b62b-9825-cdb6-ab4dadf8330d"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "kitchen", 3, 1, null, null, "", "" },
                    { new Guid("8c8abf07-69c4-bc92-dbfb-0a610aa2d4c9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "foyer", 0, 1, null, null, "", "" },
                    { new Guid("8ef4477b-108c-93c9-bed3-d6b95ea8013f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-counter", "Breakfast Counter", 1, "kitchen", 6, 2, null, null, "", "" },
                    { new Guid("922457de-12cc-23db-a8fb-67451859c503"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("92b7842e-c902-956a-8b9d-de07c805dedd"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("966e815d-176e-afe5-8289-a59f6bfe4f17"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "guest-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("9c10712c-989d-ddc5-2eaa-36c92c60440e"), null, "furnishings", "Furnishings", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "blinds", "Blinds", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("a2164309-8c53-4aac-0e2c-c724b0bca052"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "guest-bedroom", 4, 4, null, null, "", "" },
                    { new Guid("a7085957-424d-dc6a-9066-29ec103a9e9f"), 22000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-table", "Console Table", 2, "", 2, 4, null, null, "", "" },
                    { new Guid("a95ada24-25e1-5ee7-3d81-0aa976d15a80"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "kids-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("aa3d16d7-0659-ed27-87e8-442b466abe54"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "kids-bedroom", 3, 4, null, null, "", "" },
                    { new Guid("ac40642d-9d0e-76a8-324a-8593f6b640ed"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "master-bedroom", 6, 2, null, null, "", "" },
                    { new Guid("b3fd8f3a-1bee-8715-2568-8dfd5b447285"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "painting", "Painting", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("b5a8a7f2-b04b-ea3e-18af-80bd16dfbccd"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "kids-bedroom", 6, 2, null, null, "", "" },
                    { new Guid("c745de52-4357-32ab-2411-45d7930851a4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "bedroom", 2, 1, null, null, "", "" },
                    { new Guid("c97585b5-a823-b633-a384-7a491a9b2f36"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "study-room", 0, 2, null, null, "", "" },
                    { new Guid("cadde96c-7ff5-9a1b-92c0-f1b1323a8b86"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "living-room", 0, 2, null, null, "", "" },
                    { new Guid("d32a9f7e-443c-03e6-fc51-8da6da9a23cb"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "bedroom", 7, 2, null, null, "", "" },
                    { new Guid("d36e3ada-7a25-4434-38f0-1ec34d737b60"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rolling-shutter-unit", "Rolling Shutter Unit", 1, "kitchen", 7, 1, null, null, "", "" },
                    { new Guid("d5325fd7-d90b-abd9-ba7b-8c28fdc1de6b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "master-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("d552ec0b-c683-f55e-3bb5-d8c2b158b8e9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tall-unit", "Tall Unit", 1, "kitchen", 5, 1, null, null, "appliance", "Appliance" },
                    { new Guid("d772af2a-5c7d-43a1-c06a-75f067322f35"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "electrical", "Electrical Work", 3, "", 3, 4, null, null, "", "" },
                    { new Guid("d7ae821e-a222-3889-5c63-b8d4a26a9d73"), null, "custom-work", "Custom work", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "", 2, 2, null, null, "", "" },
                    { new Guid("e27b311a-3b79-0010-5537-3de5019b9e7e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("ec4f75b5-a3b7-216a-03dd-169088351ecb"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "base-units", "Base Units", 1, "kitchen", 0, 1, null, null, "", "" },
                    { new Guid("ec698ada-87ff-2805-001d-4ddaf7c585f8"), null, "services", "Services", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "plumbing", "Plumbing Work", 3, "", 4, 4, null, null, "", "" },
                    { new Guid("ecb39d3c-735c-8e9b-e4cd-c4c9a31ec339"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "", 0, 4, null, null, "", "" },
                    { new Guid("ed790b1d-b05f-e6a4-6360-09fd6a1a4feb"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "utility-storage", "Utility Storage", 1, "utility", 0, 1, null, null, "", "" },
                    { new Guid("f40782a2-03df-08cc-64cf-f795b8da0a43"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "bedroom", 3, 4, null, null, "", "" },
                    { new Guid("f43afed5-822e-0be3-5389-e87336c8918f"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "kids-bedroom", 4, 4, null, null, "", "" },
                    { new Guid("fd9c9c00-5407-459b-eda9-a83f237019e8"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "guest-bedroom", 6, 2, null, null, "", "" }
                });

            migrationBuilder.InsertData(
                table: "QuotationRates",
                columns: new[] { "Id", "CarcassMaterial", "CreatedAt", "CreatedByEmployeeId", "EffectiveFrom", "Finish", "IsActive", "ItemKey", "RatePerUnit", "ShutterMaterial", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey" },
                values: new object[,]
                {
                    { new Guid("0a43ced1-d4a1-5514-5b0c-73fa031e3176"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 1850m, "", 1, null, null, "openable" },
                    { new Guid("11b260d3-2c52-87f4-5321-8163421316ba"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dresser", 1900m, "", 1, null, null, "" },
                    { new Guid("2069b4dc-8e26-d3e5-b145-7d81b717a9e6"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Acrylic", true, "wall-units", 3600m, "HDHMR", 1, null, null, "wooden" },
                    { new Guid("2cb4e615-90cd-e74d-7691-f83918fbb31a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "loft", 2400m, "", 1, null, null, "" },
                    { new Guid("3df61d4e-92d0-2908-1f04-4f2ab63f9b22"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "base-units", 3800m, "", 1, null, null, "" },
                    { new Guid("4af4b50c-53f9-0d32-2e89-66e53defeb02"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bookshelf", 1700m, "", 1, null, null, "" },
                    { new Guid("50b0df2a-2c57-0588-055d-7f4a83a2b621"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "display-unit", 1800m, "", 1, null, null, "" },
                    { new Guid("50cbfd48-70e4-c297-e525-af90929e2865"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "false-ceiling", 220m, "", 1, null, null, "" },
                    { new Guid("51a63c00-cab8-6fe5-f7f1-3404fe9b87b3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rolling-shutter-unit", 4100m, "", 1, null, null, "" },
                    { new Guid("57a75156-a75e-bd88-d33d-024027456c7e"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Acrylic", true, "base-units", 4200m, "HDHMR", 1, null, null, "" },
                    { new Guid("6057afbf-feb6-8ab8-a818-1ec7e95caf77"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "study-table", 2600m, "", 2, null, null, "" },
                    { new Guid("63858fb0-ae6b-4fbb-16d8-05c54da5a105"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3200m, "", 1, null, null, "wooden" },
                    { new Guid("63e8ca8d-4725-1f5a-d280-6e788de7a9ca"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "ms-rods", 600m, "", 2, null, null, "" },
                    { new Guid("6f9ad67f-03de-62a2-a6be-006fe4d0edb6"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "crockery-unit", 1950m, "", 1, null, null, "" },
                    { new Guid("766c30b8-be5c-596c-10db-94a0f318ffc7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "flooring", 180m, "", 1, null, null, "" },
                    { new Guid("7bedd7f4-a36c-7a3a-bcff-76f109f68e4a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wallpaper", 120m, "", 1, null, null, "" },
                    { new Guid("7c7dc121-2803-0f50-590f-4bada033025a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "utility-storage", 1450m, "", 1, null, null, "" },
                    { new Guid("7f583bea-6d0a-06e9-dc07-18746126a4e3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "painting", 45m, "", 1, null, null, "" },
                    { new Guid("8a4f5987-ebd3-26f2-fe44-0b787a908443"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "pooja-unit", 2600m, "", 1, null, null, "" },
                    { new Guid("8d378ed8-d938-cdbb-f743-2deab5d25104"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shoe-rack", 1600m, "", 1, null, null, "" },
                    { new Guid("92a5cdc8-65cb-de09-4d07-a0c62b8793ca"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3400m, "", 1, null, null, "glass" },
                    { new Guid("98f973c8-e209-70c0-46e1-605d98593fff"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "floating-shelf", 1200m, "", 2, null, null, "" },
                    { new Guid("9e830e1e-e44c-6094-8dcd-7e33e1c27bfc"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tv-unit", 2400m, "", 2, null, null, "" },
                    { new Guid("a170f3fa-1800-8d45-0360-1311ce66ace5"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "blinds", 380m, "", 1, null, null, "" },
                    { new Guid("a1ee74b0-7711-b449-aa7f-768cea50e2c8"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Glass", true, "wall-units", 3800m, "Profile", 1, null, null, "glass" },
                    { new Guid("a96f91e9-a77f-2392-3fb3-0e7e20dd99cb"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-counter", 2800m, "", 2, null, null, "" },
                    { new Guid("b684da8b-af3f-0930-d65a-b86e97343af8"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tall-unit", 3900m, "", 1, null, null, "appliance" },
                    { new Guid("c48dffd7-4938-ae82-e81d-e8917e93a376"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rafters", 950m, "", 2, null, null, "" },
                    { new Guid("da00908b-0152-62a9-cab5-19686f1d7762"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tall-unit", 3600m, "", 1, null, null, "pantry" },
                    { new Guid("dc60cb07-d05e-2bc9-43de-a0804f39d668"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "loft-storage", 1500m, "", 1, null, null, "" },
                    { new Guid("dd98ac50-3071-a054-8878-60a8822decae"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-panelling", 1100m, "", 1, null, null, "" },
                    { new Guid("e4e8451b-b1d7-9c37-0c8f-48a799164eb0"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "jali-partition", 1400m, "", 1, null, null, "" },
                    { new Guid("e84b7f95-fa20-a61c-e2f6-c5ddcc375eb5"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2150m, "", 1, null, null, "sliding" },
                    { new Guid("f83c889a-01d9-e4bb-0ecd-b705fc4ccdfe"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dining-storage", 1900m, "", 1, null, null, "" },
                    { new Guid("fabaa00d-555e-d02c-09c5-05f49a21338c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "curtains", 450m, "", 1, null, null, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuotationCatalogEntries_RoomKey_CategoryKey",
                table: "QuotationCatalogEntries",
                columns: new[] { "RoomKey", "CategoryKey" });

            migrationBuilder.CreateIndex(
                name: "IX_QuotationCatalogEntries_RoomKey_CategoryKey_ItemKey_VariantKey",
                table: "QuotationCatalogEntries",
                columns: new[] { "RoomKey", "CategoryKey", "ItemKey", "VariantKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuotationDocuments_QuotationId",
                table: "QuotationDocuments",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationLineItems_QuotationRoomId",
                table: "QuotationLineItems",
                column: "QuotationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRates_ItemKey",
                table: "QuotationRates",
                column: "ItemKey");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRates_Specification",
                table: "QuotationRates",
                columns: new[] { "ItemKey", "VariantKey", "CarcassMaterial", "ShutterMaterial", "Finish", "EffectiveFrom" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuotationRooms_QuotationId",
                table: "QuotationRooms",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_LeadId_Stage_Current",
                table: "Quotations",
                columns: new[] { "LeadId", "Stage" },
                unique: true,
                filter: "[IsCurrent] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_LeadId_Stage_VersionNumber",
                table: "Quotations",
                columns: new[] { "LeadId", "Stage", "VersionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_Status",
                table: "Quotations",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotationCatalogEntries");

            migrationBuilder.DropTable(
                name: "QuotationDocuments");

            migrationBuilder.DropTable(
                name: "QuotationLineItems");

            migrationBuilder.DropTable(
                name: "QuotationRates");

            migrationBuilder.DropTable(
                name: "QuotationRooms");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9e5b0000-0000-4000-8000-000000000022"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9e5b0000-0000-4000-8000-000000000005"),
                column: "Description",
                value: "Prepare, revise and issue quotations.");
        }
    }
}
