using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceQuotationCatalogWithRoomBuildList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("018dc07f-1799-7879-4793-9851b481329b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("034b2d53-803c-5256-11c2-76d5a69834ba"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("06899d2c-932f-b3ed-f30c-22012cf5abda"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0cb883a3-5cd3-a0e9-a8f1-65f6af7764a2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0e418c62-218a-a292-b444-62b78d1e2ddd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("12458a69-e70e-a077-80b5-8c569cae3b4f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("143e910d-cd88-7362-a677-2d42a60e333c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("14c1546f-3a5f-9563-a02c-0ca05d57f026"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("17d2cd6d-77d7-961a-59e6-46b000669757"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("229fff54-c9ae-26ec-43ca-d0aba7c8ba85"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("22ca38db-31ce-a32c-4356-276a47c4bde0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2d81bc4c-c4d2-3bd7-c042-fe55398d109e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("33cdfa99-f24b-dccf-2c74-ebe72286bb36"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("34897107-6d2d-10b7-e160-bd203ce54d75"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("361ba840-afeb-141b-2b1b-721e261c2743"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("36de33d1-4bb5-a59e-83fc-a7e387c91939"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3a38fb1f-5b7d-13c5-cd8e-389d6c8f591d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("44783469-99db-ce91-8b9f-3384dc1d9ea2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("456f15b0-4b02-ce8f-976f-474901d990a4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("46d782f6-e37b-45bd-d741-c1defaf5c3e4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("55c14338-999a-8091-2f35-4713f13b982f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5a176187-d164-dc4e-aee3-6e5659504170"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5b4200d0-9d18-0325-2ad1-5d5f8c9e6bd5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5deff5ec-d3ee-13d6-1672-4d64a9eb5cd9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("60e486f2-470e-0d43-5940-3415fa30f009"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6a6e87af-fe4f-7763-d84c-8058582fb6be"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7579bff1-00f9-2a92-d58d-6315205975f4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("84d4bc6f-fac7-8785-14d0-43bafaecab62"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8c8abf07-69c4-bc92-dbfb-0a610aa2d4c9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("922457de-12cc-23db-a8fb-67451859c503"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("92b7842e-c902-956a-8b9d-de07c805dedd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("966e815d-176e-afe5-8289-a59f6bfe4f17"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9c93d14d-c9c0-e19c-4c14-662c2df7c4d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a2164309-8c53-4aac-0e2c-c724b0bca052"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a645a351-e9ee-ea6d-654f-d1e4a873f076"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a7085957-424d-dc6a-9066-29ec103a9e9f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a95ada24-25e1-5ee7-3d81-0aa976d15a80"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("aa3d16d7-0659-ed27-87e8-442b466abe54"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c745de52-4357-32ab-2411-45d7930851a4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c97585b5-a823-b633-a384-7a491a9b2f36"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cadde96c-7ff5-9a1b-92c0-f1b1323a8b86"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d32a9f7e-443c-03e6-fc51-8da6da9a23cb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d36e3ada-7a25-4434-38f0-1ec34d737b60"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d5325fd7-d90b-abd9-ba7b-8c28fdc1de6b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1d6dc1a-a338-9377-67dc-dc10d97c7047"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e27b311a-3b79-0010-5537-3de5019b9e7e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ecb39d3c-735c-8e9b-e4cd-c4c9a31ec339"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed790b1d-b05f-e6a4-6360-09fd6a1a4feb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f40782a2-03df-08cc-64cf-f795b8da0a43"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f43afed5-822e-0be3-5389-e87336c8918f"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("0a43ced1-d4a1-5514-5b0c-73fa031e3176"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("11b260d3-2c52-87f4-5321-8163421316ba"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("50b0df2a-2c57-0588-055d-7f4a83a2b621"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("51a63c00-cab8-6fe5-f7f1-3404fe9b87b3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("7bedd7f4-a36c-7a3a-bcff-76f109f68e4a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("7c7dc121-2803-0f50-590f-4bada033025a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a170f3fa-1800-8d45-0360-1311ce66ace5"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("c48dffd7-4938-ae82-e81d-e8917e93a376"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("dc60cb07-d05e-2bc9-43de-a0804f39d668"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("e84b7f95-fa20-a61c-e2f6-c5ddcc375eb5"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("f83c889a-01d9-e4bb-0ecd-b705fc4ccdfe"));

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3f648144-247f-d771-fb18-687228688a4a"),
                column: "SortOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("63f0e8cb-7119-1a2f-fd52-4b9f2576dd59"),
                column: "SortOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("99efcb62-3315-a9f3-3991-9375d7af31a3"),
                column: "SortOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ac40642d-9d0e-76a8-324a-8593f6b640ed"),
                column: "SortOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b5a8a7f2-b04b-ea3e-18af-80bd16dfbccd"),
                column: "SortOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c14f66cb-c3d6-8027-948e-28f66a1e6a52"),
                column: "SortOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5e01000-9a70-4044-05b2-bef0b439da18"),
                column: "SortOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec0959a6-3f22-974f-c725-45ee6340333e"),
                column: "SortOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("eef1154b-e8d3-edab-f3b3-717a56b5842d"),
                column: "SortOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fd9c9c00-5407-459b-eda9-a83f237019e8"),
                column: "SortOrder",
                value: 7);

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("016423b5-c35f-e21b-7e20-e812da7325bc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "master-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("02f9a7b1-e4a1-8608-f313-1b207e76ace8"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "drawing-room", 7, 1, null, null, "", "" },
                    { new Guid("091f22b0-0eee-e0e9-f917-fe04bd025644"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "living-room", 4, 2, null, null, "", "" },
                    { new Guid("0953a34b-dc99-041d-e996-c5a2ced7da0c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "arch", "Arch", 1, "kitchen", 0, 2, null, null, "", "" },
                    { new Guid("0ca90629-5d85-3933-6bfc-1b6601e65e84"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "kids-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("0f3c6702-2d92-f9ef-b3c7-d210e291d830"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "drawing-room", 4, 1, null, null, "", "" },
                    { new Guid("1291e7ad-d1ba-2ace-3786-8917e9275dc6"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "drawing-room", 6, 4, null, null, "", "" },
                    { new Guid("15d9a239-d43c-98b1-fa1f-1bfca0ee1c42"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("17347ad8-5fa8-9f04-2beb-cf2a52fb9999"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "drawing-room", 7, 2, null, null, "", "" },
                    { new Guid("17452e4a-7a23-d622-14e1-e5a5010ac2bd"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("1855560f-2d0d-6e9d-108a-8ae6977f9d46"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "guest-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("19a2638d-e298-19bd-abce-0eb2a56f0b46"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "living-room", 8, 1, null, null, "", "" },
                    { new Guid("1aef18cc-f26e-83fe-9915-8971a1c6c2b4"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "drawing-room", 9, 1, null, null, "", "" },
                    { new Guid("1bffd968-e2a8-1c80-490f-78b2a1c0aabc"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "main-door-paneling", "Main Door Paneling", 1, "main-door", 1, 1, null, null, "", "" },
                    { new Guid("1c9b3e4d-3b9a-0ec4-b172-7fa545748b99"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "master-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("1cda3973-15fb-46ca-86d9-29f0e279fef2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("1ce6193a-a9fd-19ff-7057-a9169cf66160"), 3500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tap", "Tap", 2, "kitchen", 9, 4, null, null, "", "" },
                    { new Guid("1eeb8297-0939-ee4d-2be8-89b6f3ddc3d2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "dining-room", 7, 1, null, null, "", "" },
                    { new Guid("1f97773b-fcbe-3926-095a-22ee342bd62d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "bedroom", 2, 1, null, null, "", "" },
                    { new Guid("1fe4f814-271c-70fa-23f1-e7707ee193df"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "guest-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("223779c5-73c7-361f-d324-d66bd0e20014"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("22951f32-f082-b8e8-a4ed-d3ea4979a74f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("22c76a62-b35c-02fc-0e07-359582a6171e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "dining-room", 5, 2, null, null, "", "" },
                    { new Guid("240cbf98-39c9-fbd3-4c40-1eed428c5c1f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "living-room", 7, 1, null, null, "", "" },
                    { new Guid("24717e96-f282-0d36-7cd2-f0a3b9a3d5a5"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "dining-room", 4, 1, null, null, "", "" },
                    { new Guid("25e1317b-1c2a-570c-c8e3-34f94abb3e03"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "guest-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("2836ef4d-ecd9-b771-5061-8672ea3e8287"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "kids-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("286d4e16-cf3e-c089-e342-61e75382429b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "bedroom", 2, 2, null, null, "", "" },
                    { new Guid("2b53036f-c0b1-4a71-d123-09e8f5695148"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shelf", "Shelf", 1, "utility", 2, 1, null, null, "", "" },
                    { new Guid("2ce11485-fdaf-9dc1-91ee-0ea19165aa9f"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "living-room", 5, 2, null, null, "", "" },
                    { new Guid("2ff3f8ce-627b-2337-6792-8c8a64ac9044"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "kids-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("303cd321-4595-46f5-0236-1bbb7dfeb879"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "living-room", 2, 4, null, null, "", "" },
                    { new Guid("32857d4e-2041-198d-bb44-355a1f80ea94"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "drawing-room", 5, 2, null, null, "", "" },
                    { new Guid("351a6ffc-2c38-8592-5405-9d2a79c5fe38"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "bedroom", 6, 1, null, null, "", "" },
                    { new Guid("37fd4d57-1904-7218-5390-7e318efdbb99"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("39fb1839-45ff-abd7-d967-7845f7a06788"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "kids-bedroom", 1, 4, null, null, "", "" },
                    { new Guid("3f704865-0dc4-225c-5ddf-7043c990cc05"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "living-room", 0, 2, null, null, "", "" },
                    { new Guid("452abcad-7508-04ad-a2bb-72ea868e2d1a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("46a9918f-5e5c-a1be-a3fe-16e57e20002b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dado-tiles", "Dado Tiles", 1, "utility", 2, 1, null, null, "", "" },
                    { new Guid("480c3993-eb4a-2f69-cdf3-35024c734d15"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "kitchen", 5, 2, null, null, "", "" },
                    { new Guid("486890cb-0291-5c20-4bd4-0b0debc2859f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "guest-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("4a48413f-e62f-fa9c-2bdc-92461169ffd8"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "dining-room", 6, 2, null, null, "", "" },
                    { new Guid("4ab483d7-1b47-0059-9638-ca42b00ba91a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "living-room", 3, 2, null, null, "", "" },
                    { new Guid("4c7481c0-4dbe-1e7b-323d-615e27c0679e"), 8500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sink", "Sink", 2, "kitchen", 8, 4, null, null, "", "" },
                    { new Guid("4e1c667d-5fd0-b57c-6dd7-8b65890d2b86"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "utility", 1, 1, null, null, "", "" },
                    { new Guid("4e671144-e82e-5c3a-a732-250121616d20"), 45000m, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "security-door", "Security Door", 2, "main-door", 2, 4, null, null, "", "" },
                    { new Guid("54552d0a-f321-f6d2-4a2a-6c4cf64c8c5e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dado-tiles", "Dado Tiles", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("5538bf6b-afc0-afab-5159-c7aac6e76d26"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "dining-room", 3, 1, null, null, "", "" },
                    { new Guid("5576888d-a8a0-fcba-dc2c-d273aa73c9f3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "guest-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("55ef0364-6f94-613f-277c-2e1795963a50"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "dining-room", 4, 2, null, null, "", "" },
                    { new Guid("561a8fa6-6a2b-b3b6-85c5-310380c67f6d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "master-bedroom", 1, 4, null, null, "", "" },
                    { new Guid("5725bcff-8ca4-80b5-0b61-c36373ed57df"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("5bbeb36d-f8a8-ee18-4187-3dc617f8ce25"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "dining-room", 2, 4, null, null, "", "" },
                    { new Guid("5bebe991-bb98-0bd6-d6fa-0a5f82e2e8c2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("5cf5c534-1f07-18c3-c03a-f0df0944317e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "bedroom", 3, 1, null, null, "", "" },
                    { new Guid("5d281df7-bebf-99f2-c42c-f2d822f3f0e3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "main-door", 0, 1, null, null, "", "" },
                    { new Guid("5d85aa51-829b-6a0c-5a56-ced0f93d4e2e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "drawing-room", 8, 1, null, null, "", "" },
                    { new Guid("5e23fe87-ca6d-56f2-5f97-f65552f690d2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "guest-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("5eb679f7-04fd-f0e9-c627-852f3d4d549c"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "kitchen", 4, 4, null, null, "", "" },
                    { new Guid("5ed00924-d3f8-1ddf-e27f-13009532f681"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("5f663cb3-ee93-2538-7666-1de74b24e339"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "living-room", 0, 4, null, null, "", "" },
                    { new Guid("5ffa552d-2da7-5c8e-6e2b-5d7c9b7d52de"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tall-unit", "Tall Unit", 1, "utility", 4, 1, null, null, "pantry", "Pantry" },
                    { new Guid("6069a039-958a-c47a-db27-d33a214fc65f"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "dining-room", 3, 2, null, null, "", "" },
                    { new Guid("60e3c213-a7c1-660c-b4dd-9e2b16e14616"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "master-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("60ed067c-b4c1-ae35-f7e4-02d76fc80ed3"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "bedroom", 3, 1, null, null, "", "" },
                    { new Guid("613ada14-2a82-3c4f-e507-c04931f782cc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-shelf", "Breakfast Shelf / Arch", 1, "kitchen", 7, 1, null, null, "", "" },
                    { new Guid("61e6bba7-2a87-10e4-18ac-04eb694c3f34"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "countertop", "Countertop", 1, "utility", 1, 2, null, null, "", "" },
                    { new Guid("64d317a0-a4d0-81f1-3025-9bb1db45a6e7"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("66be3a86-7410-cf9f-1fd0-3a52ad895543"), 1200m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cylinder-lights", "Cylinder Lights", 2, "utility", 5, 4, null, null, "", "" },
                    { new Guid("67646666-bf67-3eb3-5876-e9a9655c0d11"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "main-door", 0, 1, null, null, "", "" },
                    { new Guid("681b0348-772d-2600-1435-a04f3673999a"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "living-room", 6, 4, null, null, "", "" },
                    { new Guid("6cb7f51d-625e-2229-c95b-e6585577c361"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "master-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("6d0c4cba-71d3-c825-0872-0bfdb0f802ee"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "master-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("6e43f452-d004-55c5-b117-e739f182b960"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "dining-room", 6, 4, null, null, "", "" },
                    { new Guid("7013e9bc-743f-4fae-1de1-125875eab95f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "base-units", "Base Units", 1, "utility", 0, 1, null, null, "", "" },
                    { new Guid("7177cfc8-c077-947d-d38d-db429090d0ca"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "kids-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("7256070b-395b-d260-b424-38c557ba0565"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "kids-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("740b22e7-37fe-1934-4ed1-88cf46c09cba"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "kitchen", 5, 2, null, null, "", "" },
                    { new Guid("7551f391-d866-923c-8d7f-01f85c42c1c6"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "guest-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("76c70884-adab-a3c4-dbb9-8cb5229a6556"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "guest-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("7b0ef488-6b0e-3c25-9fd8-45a4df9f2894"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "bedroom", 8, 1, null, null, "", "" },
                    { new Guid("7d911351-f769-f2a3-b4d5-70fcfe3734aa"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains / Blinds", 1, "living-room", 3, 1, null, null, "", "" },
                    { new Guid("7e7f8c75-ff94-c870-d88b-264bdbefb931"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "dining-room", 1, 4, null, null, "", "" },
                    { new Guid("7ff96626-cb6c-d2b9-59b2-2e1a78dedc0b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("80e54c61-f0a2-e6a0-05d8-14dfcf525829"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "living-room", 7, 2, null, null, "", "" },
                    { new Guid("81dfbaea-489b-9cda-39aa-491c08f69698"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "drawing-room", 0, 4, null, null, "", "" },
                    { new Guid("8317d36b-d047-58c9-9c8d-c50be956f411"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "kids-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("842455d4-edc6-642e-d6b8-ee8448aa78b3"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "kids-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("84a70b46-1b55-c275-4a2a-c325c5590df2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "dining-room", 8, 1, null, null, "", "" },
                    { new Guid("84d6272a-3092-5b74-93b1-316b64086f59"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "kitchen", 7, 2, null, null, "", "" },
                    { new Guid("89a0aa9d-9566-86bc-7f0e-820df1ceffd1"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("89b1e1d6-01b6-597a-4711-0786e5655be5"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "utility", 7, 2, null, null, "", "" },
                    { new Guid("89b2e6a3-7c33-4863-42c8-211b49d51d67"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "bedroom", 1, 4, null, null, "", "" },
                    { new Guid("89e1d789-38d2-4861-a567-b9661efaa685"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("8bf70c75-0c40-1431-b3a8-5f7aa85c8e1c"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "living-room", 1, 4, null, null, "", "" },
                    { new Guid("8c5a90af-8328-4767-2a7c-90ab98bc4339"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("8cde98a8-5bf6-1e2d-afe3-56f69d20cac4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "bedroom", 6, 1, null, null, "", "" },
                    { new Guid("8d68451a-399d-a33b-1e6e-91fcead2831e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "bedroom", 9, 1, null, null, "", "" },
                    { new Guid("8d6acfb7-c5ad-568a-b454-cadf10622659"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "bedroom", 5, 2, null, null, "", "" },
                    { new Guid("8db2cdd0-6a45-3cc2-f6f4-d7fc2fcf7417"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "countertop", "Countertop", 1, "kitchen", 1, 2, null, null, "", "" },
                    { new Guid("8e912744-2d39-4669-5128-4cc4d6ab4725"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "master-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("8f0683b9-fe47-7bce-fe90-a86003c0f97b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "drawing-room", 3, 2, null, null, "", "" },
                    { new Guid("8fe0e6e4-cd54-b34e-8496-8fd61ab11a71"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "kids-bedroom", 2, 2, null, null, "", "" },
                    { new Guid("92f928e6-df2e-fad9-09cd-dd1713cc12d5"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "kids-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("93a69f8e-57cf-2716-8e58-83d5ad72549c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "living-room", 1, 1, null, null, "", "" },
                    { new Guid("948e93ce-b1fa-a11d-65c6-2ff94e5e812d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "kids-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("9606c256-8e0c-4769-9e02-42f11613ead5"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "guest-bedroom", 2, 2, null, null, "", "" },
                    { new Guid("963018bc-8482-4b9b-1c71-d3f045ff1455"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "living-room", 3, 2, null, null, "", "" },
                    { new Guid("973674ad-8917-307b-d7eb-de68b1c3b1c9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("976d1a44-2eb4-4a3c-4223-e10653e0d497"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "drawing-room", 2, 2, null, null, "", "" },
                    { new Guid("9ce9fdeb-6b1f-1095-cefd-a92a95153619"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "janitor-unit", "Janitor Unit", 1, "utility", 5, 1, null, null, "", "" },
                    { new Guid("9ea52c02-629b-5201-9e44-c89728c68f9b"), 48000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-table", "Dining Table", 2, "dining-room", 0, 4, null, null, "", "" },
                    { new Guid("a183877e-716f-b946-c20d-37a0bf2b4f4a"), 6500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accessories", "Accessories", 2, "kitchen", 0, 4, null, null, "", "" },
                    { new Guid("a2a45073-82b7-e36a-bbd9-8f98624e5559"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("a40dfb14-f3fa-98b5-65e7-8ad4f48a7ec9"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "kids-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("a59c6394-5def-733e-733e-3667e6f17abe"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("a669cd65-975e-4904-900d-02214ed2e2c5"), 6500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accessories", "Accessories", 2, "utility", 0, 4, null, null, "", "" },
                    { new Guid("a6fb7bf3-e3a1-88a5-30d8-45b3122cd583"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bar-unit", "Bar Unit", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("a7fc34ed-0d31-7f6b-3c0f-d78b91f6035e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "guest-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("a8e5c3da-98a0-b5d0-d505-62d8bab6a3b3"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "bedroom", 4, 2, null, null, "", "" },
                    { new Guid("aa8eb7ab-4b7e-763e-bae8-127881791021"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("ac2fb669-4922-bbdd-885b-919a8c62cd9e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "master-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("acf4aef2-e551-2159-ad45-4c053b87c1a6"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "drawing-room", 0, 1, null, null, "", "" },
                    { new Guid("b3cd1a04-464c-a484-7ee2-7e3332be6e7d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "utility", 6, 4, null, null, "", "" },
                    { new Guid("b88f599c-9b90-4bd5-56bd-87285f94d215"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "fluted-panel", "Fluted Panel", 1, "kitchen", 1, 1, null, null, "", "" },
                    { new Guid("b9af130b-b9e3-a6f5-20c6-09e4dfa8ba43"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("ba2f2c50-4316-dc18-87e7-ae0ae6d11c3b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("baf3c598-4a02-658c-92dc-214500406d07"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("bb19e104-876d-f532-af36-95fb7bcf7459"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("bbe388be-2ad9-5316-0b0c-8c32b0392274"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "living-room", 0, 1, null, null, "", "" },
                    { new Guid("bd2306ad-b7dc-2719-af2a-49fc171cb0da"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "living-room", 6, 1, null, null, "", "" },
                    { new Guid("bd42864a-f117-9b92-3f60-fd399cf66a34"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("bf8275cd-e391-a72f-8d59-1670386e47af"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("bff0369c-3962-ba78-394f-a8bbcda00fd2"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "kitchen", 6, 2, null, null, "", "" },
                    { new Guid("c08db93d-2cf3-8d3b-2ac7-1304d8fddd52"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("c21acf4c-f03d-69d5-bf57-d1c4fd8126ae"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "drawing-room", 10, 1, null, null, "", "" },
                    { new Guid("c292e758-2267-c963-8cb6-7917152bac09"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("c2ecb214-8196-97a6-beb5-607725cdadf9"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "drawing-room", 1, 1, null, null, "", "" },
                    { new Guid("c5fc00ce-ece2-c8f6-4747-8f78c0b88d92"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "drawing-room", 4, 2, null, null, "", "" },
                    { new Guid("c76a0438-4600-5237-f1e2-c66b141df12e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "guest-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("c7b0e1f3-5e7c-7bed-4fa3-9e8a4fbe4744"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("c8543641-52ea-2bd3-96b4-c697d6a338c4"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "iron-grills", "Iron Grills", 1, "utility", 8, 1, null, null, "", "" },
                    { new Guid("c93df9f8-8f78-94f6-5792-eec485b76bc7"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "drawing-room", 2, 4, null, null, "", "" },
                    { new Guid("c94ce885-b734-8fa2-9302-b47bd711cdd8"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("c9d6c282-34b2-f86b-16dd-bdb4524de2bc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("c9eede4e-a70e-a372-e59f-00ed5e52823a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "master-bedroom", 2, 2, null, null, "", "" },
                    { new Guid("ca174937-dffd-a8d0-4d80-79e4620ddbad"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("cf283c9f-2850-a1d1-5993-c6e6afada52e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "drawing-room", 0, 1, null, null, "", "" },
                    { new Guid("d184f702-0d39-c3e8-6ecc-c2b4137acfd7"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "dining-room", 2, 4, null, null, "", "" },
                    { new Guid("d344efbc-75ae-e70b-085f-4ba8c11d1e10"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bar-unit", "Bar Unit", 1, "drawing-room", 1, 1, null, null, "", "" },
                    { new Guid("d3e3720f-4677-0a27-bf7e-fcb64448cdc0"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "guest-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("d5ffea32-e0e6-c37a-e7b2-adabdc10499a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "dining-room", 7, 2, null, null, "", "" },
                    { new Guid("d749db7d-091d-86d8-a9d9-5dda78954b17"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "master-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("da9c4317-ec72-2819-5f4b-af3b65caa955"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "drawing-room", 1, 4, null, null, "", "" },
                    { new Guid("db38bbf2-8195-7b0f-fc80-db4c86702a08"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("db8973a2-3bd0-eaba-c464-23f693611bb7"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "drawing-room", 5, 2, null, null, "", "" },
                    { new Guid("dc07aec4-0bda-87a6-ba92-261180e2181c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("dc2627b4-f9af-4589-1eb8-fa6207dd0275"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "bedroom", 10, 1, null, null, "", "" },
                    { new Guid("dcdc6444-c6a1-b849-22c6-28126387e1c3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "dining-room", 5, 2, null, null, "", "" },
                    { new Guid("ddc11574-d840-64de-6023-c7d47c6b4daa"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-counter-arch", "Breakfast Counter - Arch", 1, "kitchen", 3, 2, null, null, "", "" },
                    { new Guid("e01f66c9-8251-9920-0e73-5b550bc8f957"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "open-shelves", "Shelves", 1, "kitchen", 4, 2, null, null, "", "" },
                    { new Guid("e041ba71-583b-abfb-09ee-db7e1163a98f"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "drawing-room", 2, 4, null, null, "", "" },
                    { new Guid("e0732ae9-2ac7-731c-201a-af8634c66c6c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "living-room", 5, 1, null, null, "", "" },
                    { new Guid("e07ea364-9cba-2ac2-f621-9780bed6d020"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "guest-bedroom", 1, 4, null, null, "", "" },
                    { new Guid("e0a73010-0ed5-3374-ede3-445731fce633"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("e32482e9-2ebd-889a-0dc9-67611b515cd1"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "kitchen", 3, 1, null, null, "", "" },
                    { new Guid("e3ebb2be-9e35-5cef-9b07-e86c022a0966"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "bedroom", 1, 2, null, null, "", "" },
                    { new Guid("e4bf6dfd-3a25-8ea7-8f59-f67e83d4e587"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "drawing-room", 6, 2, null, null, "", "" },
                    { new Guid("ea1484fa-dd7b-8200-0386-7c1557d7b585"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "dining-room", 9, 1, null, null, "", "" },
                    { new Guid("ea22d1d4-99b3-cd60-5ede-95ee312a9cbb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "living-room", 2, 1, null, null, "", "" },
                    { new Guid("ec96e3e8-f7c4-138b-8cc3-39ddf800c9e0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "drawing-room", 3, 1, null, null, "", "" },
                    { new Guid("ed117801-ad5f-c3fd-4252-f7d9700f05fc"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "groove-shutters", "Groove Shutters", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("ed18318d-2dde-a226-a70d-1e95083c452b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("ed72e572-8454-6471-f082-9ea35c18e444"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "utility", 4, 1, null, null, "", "" },
                    { new Guid("ee874ffa-921d-7c06-4d9b-00c0feaa7284"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "master-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("f0325c02-e099-589b-a748-601aaf1de3f1"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains / Blinds", 1, "drawing-room", 3, 1, null, null, "", "" },
                    { new Guid("f1a36782-3538-4b3e-5305-8e1aa541cfff"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains / Blinds", 1, "dining-room", 4, 1, null, null, "", "" },
                    { new Guid("f394106a-4e4e-74d5-dc92-4e4a0707a05d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "living-room", 2, 4, null, null, "", "" },
                    { new Guid("f3a6c3a1-6af2-cb34-791f-92d27da0bf56"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "utility", 3, 1, null, null, "", "" },
                    { new Guid("f3e07188-8fda-dabe-7b8b-a58ec2c1eb3b"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "dining-room", 10, 1, null, null, "", "" },
                    { new Guid("f5e8b08b-2461-b66b-2dd6-63e5e7645bd3"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "dining-room", 3, 4, null, null, "", "" },
                    { new Guid("f795d839-d606-9471-f535-81bc48b34fcb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "dining-room", 2, 2, null, null, "", "" },
                    { new Guid("f9ed2173-97ac-63d7-f8c0-9fc909a4992f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "master-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("fbfa8ca2-b208-7da7-c830-017be1ad0c69"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "utility", 3, 1, null, null, "", "" },
                    { new Guid("fc451b46-1cce-836b-5fcd-34609e4a05c0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "kids-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("fc5e7e57-abb3-bd3f-9d18-91a00f00b1eb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "master-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("fd3e7023-600a-279a-24c4-22d586b6de6b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "living-room", 4, 2, null, null, "", "" },
                    { new Guid("fe364e61-11ff-5b5c-e050-af1dc79932ca"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "living-room", 1, 1, null, null, "", "" }
                });

            migrationBuilder.UpdateData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4af4b50c-53f9-0d32-2e89-66e53defeb02"),
                column: "RatePerUnit",
                value: 1900m);

            migrationBuilder.UpdateData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("50cbfd48-70e4-c297-e525-af90929e2865"),
                column: "RatePerUnit",
                value: 260m);

            migrationBuilder.InsertData(
                table: "QuotationRates",
                columns: new[] { "Id", "CarcassMaterial", "CreatedAt", "CreatedByEmployeeId", "EffectiveFrom", "Finish", "IsActive", "ItemKey", "RatePerUnit", "ShutterMaterial", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey" },
                values: new object[,]
                {
                    { new Guid("039c6aa9-80c5-6841-3cfc-277813a9e27c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "main-door-paneling", 1800m, "", 1, null, null, "" },
                    { new Guid("0c9297fe-a7f4-8185-66de-810a0887ae88"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "mosquito-mesh", 350m, "", 1, null, null, "" },
                    { new Guid("12e62c24-fbfb-dbbc-8813-884661757690"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "storage-unit", 1600m, "", 1, null, null, "" },
                    { new Guid("153d6b68-950c-8450-c56a-30674dc7e687"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3200m, "", 1, null, null, "" },
                    { new Guid("1a77a17f-d906-5578-f11c-730230c4db27"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 1850m, "", 1, null, null, "hinged-7" },
                    { new Guid("1b5186b2-9740-ab06-cef6-0e297ada3683"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "cob-lights", 450m, "", 2, null, null, "" },
                    { new Guid("28a05ef8-da4e-2821-e42f-c0911c5af2e7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "beading", 350m, "", 2, null, null, "" },
                    { new Guid("30b421a4-9c7c-64af-70f7-bbb7d4901c42"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2000m, "", 1, null, null, "hinged-full" },
                    { new Guid("3bf281c2-fda8-3d00-9357-6160301c1d42"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "cove-lights", 500m, "", 2, null, null, "" },
                    { new Guid("3d1d1bf5-cc48-0c66-457f-3cfe7ba517b9"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "accent-wall-paneling", 1300m, "", 1, null, null, "" },
                    { new Guid("477d2462-f597-33f6-54c0-d0e64cc00f14"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "arch", 1100m, "", 2, null, null, "" },
                    { new Guid("4c560537-8cf3-b173-a8ec-586095507fda"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rafters-pu", 1250m, "", 2, null, null, "" },
                    { new Guid("4f7a88bc-23ff-bc2b-a0a0-14fc058422ec"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bay-window-paneling", 1350m, "", 1, null, null, "" },
                    { new Guid("57410f5e-1461-d13e-e003-46b62352da78"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "groove-shutters", 1400m, "", 1, null, null, "" },
                    { new Guid("63aee5bb-3d60-6aa5-9a15-326fcb19f6b5"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shelf", 1800m, "", 1, null, null, "" },
                    { new Guid("68551bfa-72fb-1fc0-6c35-808a482a4d9b"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "magnetic-track-lights", 900m, "", 2, null, null, "" },
                    { new Guid("6a4281e2-73c0-6799-9d4c-98f276394c32"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2300m, "", 1, null, null, "sliding-full" },
                    { new Guid("6c8e4e17-aba0-98c9-a548-bb2c5848abbf"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "countertop", 1600m, "", 2, null, null, "" },
                    { new Guid("6e86fff1-efa9-b455-0de6-974491be5ef7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2150m, "", 1, null, null, "sliding-7" },
                    { new Guid("74031370-9dcf-3a1a-e7f8-b299005e2d1a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "console-unit", 1500m, "", 1, null, null, "" },
                    { new Guid("9045633f-c77d-706e-c49e-0dc241d66c82"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "profile-lights", 550m, "", 2, null, null, "" },
                    { new Guid("972b45d9-9bc8-851a-0a31-7d288d70aa64"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wooden-ceiling", 850m, "", 1, null, null, "" },
                    { new Guid("9739a6d2-f17d-02d1-2f96-2bab5e28d2cb"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-shelf", 2600m, "", 1, null, null, "" },
                    { new Guid("9a8d0ec8-2657-f122-2401-b09d881b8b3e"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 1700m, "", 1, null, null, "used-clothes" },
                    { new Guid("9df2fd07-424d-25b4-e7d1-93cdcd74e0c9"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "study-table-wall-storage", 2200m, "", 1, null, null, "" },
                    { new Guid("a20ffbd1-c32f-3f10-a34f-63cd706b650c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "fluted-panel", 1200m, "", 1, null, null, "" },
                    { new Guid("af285b6a-9530-ace2-1bcf-45281a02ecdf"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-counter-arch", 1200m, "", 2, null, null, "" },
                    { new Guid("c4352f6c-3521-5c03-2e24-371181339e3d"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "accent-wall-wallpaper", 900m, "", 1, null, null, "" },
                    { new Guid("c4fc4430-cf12-c71e-b43c-badd25d83a26"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "seating-unit", 2100m, "", 1, null, null, "" },
                    { new Guid("d10c259b-2160-bdd2-de99-a97174ea3ac6"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "partition", 1400m, "", 1, null, null, "" },
                    { new Guid("d966e803-e6b3-6283-db9a-e799ff609e79"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bar-unit", 2000m, "", 1, null, null, "" },
                    { new Guid("e15bc135-8a46-5355-a790-1b6db34b36d3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2600m, "", 1, null, null, "sliding-glass" },
                    { new Guid("e7f7fd7c-68cb-1bb8-2540-cfd73ad6edb1"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "janitor-unit", 2200m, "", 1, null, null, "" },
                    { new Guid("ecc8d789-593b-3716-707e-f583b1796a76"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "open-shelves", 900m, "", 2, null, null, "" },
                    { new Guid("ee596b21-b4e8-bafc-3292-23ea68380cbc"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "iron-grills", 900m, "", 1, null, null, "" },
                    { new Guid("fca76c78-a5ac-2612-8350-9b06230f3314"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dado-tiles", 220m, "", 1, null, null, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("016423b5-c35f-e21b-7e20-e812da7325bc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("02f9a7b1-e4a1-8608-f313-1b207e76ace8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("091f22b0-0eee-e0e9-f917-fe04bd025644"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0953a34b-dc99-041d-e996-c5a2ced7da0c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0ca90629-5d85-3933-6bfc-1b6601e65e84"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0f3c6702-2d92-f9ef-b3c7-d210e291d830"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1291e7ad-d1ba-2ace-3786-8917e9275dc6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("15d9a239-d43c-98b1-fa1f-1bfca0ee1c42"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("17347ad8-5fa8-9f04-2beb-cf2a52fb9999"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("17452e4a-7a23-d622-14e1-e5a5010ac2bd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1855560f-2d0d-6e9d-108a-8ae6977f9d46"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("19a2638d-e298-19bd-abce-0eb2a56f0b46"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1aef18cc-f26e-83fe-9915-8971a1c6c2b4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1bffd968-e2a8-1c80-490f-78b2a1c0aabc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1c9b3e4d-3b9a-0ec4-b172-7fa545748b99"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1cda3973-15fb-46ca-86d9-29f0e279fef2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1ce6193a-a9fd-19ff-7057-a9169cf66160"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1eeb8297-0939-ee4d-2be8-89b6f3ddc3d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1f97773b-fcbe-3926-095a-22ee342bd62d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1fe4f814-271c-70fa-23f1-e7707ee193df"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("223779c5-73c7-361f-d324-d66bd0e20014"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("22951f32-f082-b8e8-a4ed-d3ea4979a74f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("22c76a62-b35c-02fc-0e07-359582a6171e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("240cbf98-39c9-fbd3-4c40-1eed428c5c1f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("24717e96-f282-0d36-7cd2-f0a3b9a3d5a5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("25e1317b-1c2a-570c-c8e3-34f94abb3e03"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2836ef4d-ecd9-b771-5061-8672ea3e8287"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("286d4e16-cf3e-c089-e342-61e75382429b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2b53036f-c0b1-4a71-d123-09e8f5695148"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2ce11485-fdaf-9dc1-91ee-0ea19165aa9f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2ff3f8ce-627b-2337-6792-8c8a64ac9044"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("303cd321-4595-46f5-0236-1bbb7dfeb879"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("32857d4e-2041-198d-bb44-355a1f80ea94"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("351a6ffc-2c38-8592-5405-9d2a79c5fe38"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("37fd4d57-1904-7218-5390-7e318efdbb99"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("39fb1839-45ff-abd7-d967-7845f7a06788"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3f704865-0dc4-225c-5ddf-7043c990cc05"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("452abcad-7508-04ad-a2bb-72ea868e2d1a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("46a9918f-5e5c-a1be-a3fe-16e57e20002b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("480c3993-eb4a-2f69-cdf3-35024c734d15"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("486890cb-0291-5c20-4bd4-0b0debc2859f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4a48413f-e62f-fa9c-2bdc-92461169ffd8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4ab483d7-1b47-0059-9638-ca42b00ba91a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4c7481c0-4dbe-1e7b-323d-615e27c0679e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4e1c667d-5fd0-b57c-6dd7-8b65890d2b86"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4e671144-e82e-5c3a-a732-250121616d20"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("54552d0a-f321-f6d2-4a2a-6c4cf64c8c5e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5538bf6b-afc0-afab-5159-c7aac6e76d26"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5576888d-a8a0-fcba-dc2c-d273aa73c9f3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("55ef0364-6f94-613f-277c-2e1795963a50"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("561a8fa6-6a2b-b3b6-85c5-310380c67f6d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5725bcff-8ca4-80b5-0b61-c36373ed57df"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5bbeb36d-f8a8-ee18-4187-3dc617f8ce25"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5bebe991-bb98-0bd6-d6fa-0a5f82e2e8c2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5cf5c534-1f07-18c3-c03a-f0df0944317e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5d281df7-bebf-99f2-c42c-f2d822f3f0e3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5d85aa51-829b-6a0c-5a56-ced0f93d4e2e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5e23fe87-ca6d-56f2-5f97-f65552f690d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5eb679f7-04fd-f0e9-c627-852f3d4d549c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5ed00924-d3f8-1ddf-e27f-13009532f681"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5f663cb3-ee93-2538-7666-1de74b24e339"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5ffa552d-2da7-5c8e-6e2b-5d7c9b7d52de"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6069a039-958a-c47a-db27-d33a214fc65f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("60e3c213-a7c1-660c-b4dd-9e2b16e14616"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("60ed067c-b4c1-ae35-f7e4-02d76fc80ed3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("613ada14-2a82-3c4f-e507-c04931f782cc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("61e6bba7-2a87-10e4-18ac-04eb694c3f34"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("64d317a0-a4d0-81f1-3025-9bb1db45a6e7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("66be3a86-7410-cf9f-1fd0-3a52ad895543"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("67646666-bf67-3eb3-5876-e9a9655c0d11"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("681b0348-772d-2600-1435-a04f3673999a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6cb7f51d-625e-2229-c95b-e6585577c361"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6d0c4cba-71d3-c825-0872-0bfdb0f802ee"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6e43f452-d004-55c5-b117-e739f182b960"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7013e9bc-743f-4fae-1de1-125875eab95f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7177cfc8-c077-947d-d38d-db429090d0ca"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7256070b-395b-d260-b424-38c557ba0565"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("740b22e7-37fe-1934-4ed1-88cf46c09cba"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7551f391-d866-923c-8d7f-01f85c42c1c6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("76c70884-adab-a3c4-dbb9-8cb5229a6556"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7b0ef488-6b0e-3c25-9fd8-45a4df9f2894"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7d911351-f769-f2a3-b4d5-70fcfe3734aa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7e7f8c75-ff94-c870-d88b-264bdbefb931"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7ff96626-cb6c-d2b9-59b2-2e1a78dedc0b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("80e54c61-f0a2-e6a0-05d8-14dfcf525829"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("81dfbaea-489b-9cda-39aa-491c08f69698"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8317d36b-d047-58c9-9c8d-c50be956f411"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("842455d4-edc6-642e-d6b8-ee8448aa78b3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("84a70b46-1b55-c275-4a2a-c325c5590df2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("84d6272a-3092-5b74-93b1-316b64086f59"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89a0aa9d-9566-86bc-7f0e-820df1ceffd1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89b1e1d6-01b6-597a-4711-0786e5655be5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89b2e6a3-7c33-4863-42c8-211b49d51d67"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89e1d789-38d2-4861-a567-b9661efaa685"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8bf70c75-0c40-1431-b3a8-5f7aa85c8e1c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8c5a90af-8328-4767-2a7c-90ab98bc4339"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8cde98a8-5bf6-1e2d-afe3-56f69d20cac4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8d68451a-399d-a33b-1e6e-91fcead2831e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8d6acfb7-c5ad-568a-b454-cadf10622659"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8db2cdd0-6a45-3cc2-f6f4-d7fc2fcf7417"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8e912744-2d39-4669-5128-4cc4d6ab4725"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8f0683b9-fe47-7bce-fe90-a86003c0f97b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8fe0e6e4-cd54-b34e-8496-8fd61ab11a71"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("92f928e6-df2e-fad9-09cd-dd1713cc12d5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("93a69f8e-57cf-2716-8e58-83d5ad72549c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("948e93ce-b1fa-a11d-65c6-2ff94e5e812d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9606c256-8e0c-4769-9e02-42f11613ead5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("963018bc-8482-4b9b-1c71-d3f045ff1455"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("973674ad-8917-307b-d7eb-de68b1c3b1c9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("976d1a44-2eb4-4a3c-4223-e10653e0d497"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9ce9fdeb-6b1f-1095-cefd-a92a95153619"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9ea52c02-629b-5201-9e44-c89728c68f9b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a183877e-716f-b946-c20d-37a0bf2b4f4a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a2a45073-82b7-e36a-bbd9-8f98624e5559"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a40dfb14-f3fa-98b5-65e7-8ad4f48a7ec9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a59c6394-5def-733e-733e-3667e6f17abe"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a669cd65-975e-4904-900d-02214ed2e2c5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a6fb7bf3-e3a1-88a5-30d8-45b3122cd583"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a7fc34ed-0d31-7f6b-3c0f-d78b91f6035e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a8e5c3da-98a0-b5d0-d505-62d8bab6a3b3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("aa8eb7ab-4b7e-763e-bae8-127881791021"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ac2fb669-4922-bbdd-885b-919a8c62cd9e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("acf4aef2-e551-2159-ad45-4c053b87c1a6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b3cd1a04-464c-a484-7ee2-7e3332be6e7d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b88f599c-9b90-4bd5-56bd-87285f94d215"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b9af130b-b9e3-a6f5-20c6-09e4dfa8ba43"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ba2f2c50-4316-dc18-87e7-ae0ae6d11c3b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("baf3c598-4a02-658c-92dc-214500406d07"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bb19e104-876d-f532-af36-95fb7bcf7459"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bbe388be-2ad9-5316-0b0c-8c32b0392274"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bd2306ad-b7dc-2719-af2a-49fc171cb0da"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bd42864a-f117-9b92-3f60-fd399cf66a34"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bf8275cd-e391-a72f-8d59-1670386e47af"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bff0369c-3962-ba78-394f-a8bbcda00fd2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c08db93d-2cf3-8d3b-2ac7-1304d8fddd52"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c21acf4c-f03d-69d5-bf57-d1c4fd8126ae"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c292e758-2267-c963-8cb6-7917152bac09"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c2ecb214-8196-97a6-beb5-607725cdadf9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5fc00ce-ece2-c8f6-4747-8f78c0b88d92"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c76a0438-4600-5237-f1e2-c66b141df12e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c7b0e1f3-5e7c-7bed-4fa3-9e8a4fbe4744"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c8543641-52ea-2bd3-96b4-c697d6a338c4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c93df9f8-8f78-94f6-5792-eec485b76bc7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c94ce885-b734-8fa2-9302-b47bd711cdd8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c9d6c282-34b2-f86b-16dd-bdb4524de2bc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c9eede4e-a70e-a372-e59f-00ed5e52823a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ca174937-dffd-a8d0-4d80-79e4620ddbad"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cf283c9f-2850-a1d1-5993-c6e6afada52e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d184f702-0d39-c3e8-6ecc-c2b4137acfd7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d344efbc-75ae-e70b-085f-4ba8c11d1e10"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d3e3720f-4677-0a27-bf7e-fcb64448cdc0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d5ffea32-e0e6-c37a-e7b2-adabdc10499a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d749db7d-091d-86d8-a9d9-5dda78954b17"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("da9c4317-ec72-2819-5f4b-af3b65caa955"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("db38bbf2-8195-7b0f-fc80-db4c86702a08"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("db8973a2-3bd0-eaba-c464-23f693611bb7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dc07aec4-0bda-87a6-ba92-261180e2181c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dc2627b4-f9af-4589-1eb8-fa6207dd0275"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dcdc6444-c6a1-b849-22c6-28126387e1c3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ddc11574-d840-64de-6023-c7d47c6b4daa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e01f66c9-8251-9920-0e73-5b550bc8f957"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e041ba71-583b-abfb-09ee-db7e1163a98f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e0732ae9-2ac7-731c-201a-af8634c66c6c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e07ea364-9cba-2ac2-f621-9780bed6d020"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e0a73010-0ed5-3374-ede3-445731fce633"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e32482e9-2ebd-889a-0dc9-67611b515cd1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3ebb2be-9e35-5cef-9b07-e86c022a0966"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4bf6dfd-3a25-8ea7-8f59-f67e83d4e587"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ea1484fa-dd7b-8200-0386-7c1557d7b585"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ea22d1d4-99b3-cd60-5ede-95ee312a9cbb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec96e3e8-f7c4-138b-8cc3-39ddf800c9e0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed117801-ad5f-c3fd-4252-f7d9700f05fc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed18318d-2dde-a226-a70d-1e95083c452b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed72e572-8454-6471-f082-9ea35c18e444"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ee874ffa-921d-7c06-4d9b-00c0feaa7284"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f0325c02-e099-589b-a748-601aaf1de3f1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f1a36782-3538-4b3e-5305-8e1aa541cfff"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f394106a-4e4e-74d5-dc92-4e4a0707a05d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f3a6c3a1-6af2-cb34-791f-92d27da0bf56"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f3e07188-8fda-dabe-7b8b-a58ec2c1eb3b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f5e8b08b-2461-b66b-2dd6-63e5e7645bd3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f795d839-d606-9471-f535-81bc48b34fcb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f9ed2173-97ac-63d7-f8c0-9fc909a4992f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fbfa8ca2-b208-7da7-c830-017be1ad0c69"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fc451b46-1cce-836b-5fcd-34609e4a05c0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fc5e7e57-abb3-bd3f-9d18-91a00f00b1eb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fd3e7023-600a-279a-24c4-22d586b6de6b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fe364e61-11ff-5b5c-e050-af1dc79932ca"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("039c6aa9-80c5-6841-3cfc-277813a9e27c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("0c9297fe-a7f4-8185-66de-810a0887ae88"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("12e62c24-fbfb-dbbc-8813-884661757690"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("153d6b68-950c-8450-c56a-30674dc7e687"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("1a77a17f-d906-5578-f11c-730230c4db27"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("1b5186b2-9740-ab06-cef6-0e297ada3683"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("28a05ef8-da4e-2821-e42f-c0911c5af2e7"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("30b421a4-9c7c-64af-70f7-bbb7d4901c42"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3bf281c2-fda8-3d00-9357-6160301c1d42"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3d1d1bf5-cc48-0c66-457f-3cfe7ba517b9"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("477d2462-f597-33f6-54c0-d0e64cc00f14"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4c560537-8cf3-b173-a8ec-586095507fda"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4f7a88bc-23ff-bc2b-a0a0-14fc058422ec"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("57410f5e-1461-d13e-e003-46b62352da78"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("63aee5bb-3d60-6aa5-9a15-326fcb19f6b5"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("68551bfa-72fb-1fc0-6c35-808a482a4d9b"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6a4281e2-73c0-6799-9d4c-98f276394c32"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6c8e4e17-aba0-98c9-a548-bb2c5848abbf"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6e86fff1-efa9-b455-0de6-974491be5ef7"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("74031370-9dcf-3a1a-e7f8-b299005e2d1a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9045633f-c77d-706e-c49e-0dc241d66c82"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("972b45d9-9bc8-851a-0a31-7d288d70aa64"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9739a6d2-f17d-02d1-2f96-2bab5e28d2cb"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9a8d0ec8-2657-f122-2401-b09d881b8b3e"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9df2fd07-424d-25b4-e7d1-93cdcd74e0c9"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a20ffbd1-c32f-3f10-a34f-63cd706b650c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("af285b6a-9530-ace2-1bcf-45281a02ecdf"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("c4352f6c-3521-5c03-2e24-371181339e3d"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("c4fc4430-cf12-c71e-b43c-badd25d83a26"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d10c259b-2160-bdd2-de99-a97174ea3ac6"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d966e803-e6b3-6283-db9a-e799ff609e79"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("e15bc135-8a46-5355-a790-1b6db34b36d3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("e7f7fd7c-68cb-1bb8-2540-cfd73ad6edb1"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("ecc8d789-593b-3716-707e-f583b1796a76"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("ee596b21-b4e8-bafc-3292-23ea68380cbc"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("fca76c78-a5ac-2612-8350-9b06230f3314"));

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3f648144-247f-d771-fb18-687228688a4a"),
                column: "SortOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("63f0e8cb-7119-1a2f-fd52-4b9f2576dd59"),
                column: "SortOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("99efcb62-3315-a9f3-3991-9375d7af31a3"),
                column: "SortOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ac40642d-9d0e-76a8-324a-8593f6b640ed"),
                column: "SortOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b5a8a7f2-b04b-ea3e-18af-80bd16dfbccd"),
                column: "SortOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c14f66cb-c3d6-8027-948e-28f66a1e6a52"),
                column: "SortOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5e01000-9a70-4044-05b2-bef0b439da18"),
                column: "SortOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec0959a6-3f22-974f-c725-45ee6340333e"),
                column: "SortOrder",
                value: 5);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("eef1154b-e8d3-edab-f3b3-717a56b5842d"),
                column: "SortOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fd9c9c00-5407-459b-eda9-a83f237019e8"),
                column: "SortOrder",
                value: 6);

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("018dc07f-1799-7879-4793-9851b481329b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Bookshelf", 1, "study-room", 1, 1, null, null, "", "" },
                    { new Guid("034b2d53-803c-5256-11c2-76d5a69834ba"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("06899d2c-932f-b3ed-f30c-22012cf5abda"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "master-bedroom", 3, 4, null, null, "", "" },
                    { new Guid("0cb883a3-5cd3-a0e9-a8f1-65f6af7764a2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-storage", "Dining Storage", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("0e418c62-218a-a292-b444-62b78d1e2ddd"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "", 1, 4, null, null, "", "" },
                    { new Guid("12458a69-e70e-a077-80b5-8c569cae3b4f"), 48000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-table", "Dining Table", 2, "", 3, 4, null, null, "", "" },
                    { new Guid("143e910d-cd88-7362-a677-2d42a60e333c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "kids-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("14c1546f-3a5f-9563-a02c-0ca05d57f026"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "living-room", 2, 1, null, null, "", "" },
                    { new Guid("17d2cd6d-77d7-961a-59e6-46b000669757"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "master-bedroom", 4, 4, null, null, "", "" },
                    { new Guid("229fff54-c9ae-26ec-43ca-d0aba7c8ba85"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wallpaper", "Wallpaper", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("22ca38db-31ce-a32c-4356-276a47c4bde0"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("2d81bc4c-c4d2-3bd7-c042-fe55398d109e"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "guest-bedroom", 3, 4, null, null, "", "" },
                    { new Guid("33cdfa99-f24b-dccf-2c74-ebe72286bb36"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "master-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("34897107-6d2d-10b7-e160-bd203ce54d75"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("361ba840-afeb-141b-2b1b-721e261c2743"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("36de33d1-4bb5-a59e-83fc-a7e387c91939"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "bedroom", 5, 1, null, null, "", "" },
                    { new Guid("3a38fb1f-5b7d-13c5-cd8e-389d6c8f591d"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "display-unit", "Display Unit", 1, "living-room", 3, 1, null, null, "", "" },
                    { new Guid("44783469-99db-ce91-8b9f-3384dc1d9ea2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "kids-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("456f15b0-4b02-ce8f-976f-474901d990a4"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("46d782f6-e37b-45bd-d741-c1defaf5c3e4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("55c14338-999a-8091-2f35-4713f13b982f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "master-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("5a176187-d164-dc4e-aee3-6e5659504170"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "living-room", 1, 1, null, null, "", "" },
                    { new Guid("5b4200d0-9d18-0325-2ad1-5d5f8c9e6bd5"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters", "Rafters", 1, "", 1, 2, null, null, "", "" },
                    { new Guid("5deff5ec-d3ee-13d6-1672-4d64a9eb5cd9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 0, 1, null, null, "openable", "Openable" },
                    { new Guid("60e486f2-470e-0d43-5940-3415fa30f009"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "bedroom", 4, 4, null, null, "", "" },
                    { new Guid("6a6e87af-fe4f-7763-d84c-8058582fb6be"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "guest-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("7579bff1-00f9-2a92-d58d-6315205975f4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "pooja-room", 0, 1, null, null, "", "" },
                    { new Guid("84d4bc6f-fac7-8785-14d0-43bafaecab62"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "guest-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("8c8abf07-69c4-bc92-dbfb-0a610aa2d4c9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "foyer", 0, 1, null, null, "", "" },
                    { new Guid("922457de-12cc-23db-a8fb-67451859c503"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("92b7842e-c902-956a-8b9d-de07c805dedd"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 1, 1, null, null, "sliding", "Sliding" },
                    { new Guid("966e815d-176e-afe5-8289-a59f6bfe4f17"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "guest-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("9c93d14d-c9c0-e19c-4c14-662c2df7c4d2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "", 2, 2, null, null, "", "" },
                    { new Guid("a2164309-8c53-4aac-0e2c-c724b0bca052"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "guest-bedroom", 4, 4, null, null, "", "" },
                    { new Guid("a645a351-e9ee-ea6d-654f-d1e4a873f076"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling", 1, "", 3, 1, null, null, "", "" },
                    { new Guid("a7085957-424d-dc6a-9066-29ec103a9e9f"), 22000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-table", "Console Table", 2, "", 2, 4, null, null, "", "" },
                    { new Guid("a95ada24-25e1-5ee7-3d81-0aa976d15a80"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dresser", "Dresser Unit", 1, "kids-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("aa3d16d7-0659-ed27-87e8-442b466abe54"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "kids-bedroom", 3, 4, null, null, "", "" },
                    { new Guid("c745de52-4357-32ab-2411-45d7930851a4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft-storage", "Loft Storage", 1, "bedroom", 2, 1, null, null, "", "" },
                    { new Guid("c97585b5-a823-b633-a384-7a491a9b2f36"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "study-room", 0, 2, null, null, "", "" },
                    { new Guid("cadde96c-7ff5-9a1b-92c0-f1b1323a8b86"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "living-room", 0, 2, null, null, "", "" },
                    { new Guid("d32a9f7e-443c-03e6-fc51-8da6da9a23cb"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "bedroom", 7, 2, null, null, "", "" },
                    { new Guid("d36e3ada-7a25-4434-38f0-1ec34d737b60"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rolling-shutter-unit", "Rolling Shutter Unit", 1, "kitchen", 7, 1, null, null, "", "" },
                    { new Guid("d5325fd7-d90b-abd9-ba7b-8c28fdc1de6b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "master-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("e1d6dc1a-a338-9377-67dc-dc10d97c7047"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "blinds", "Blinds", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("e27b311a-3b79-0010-5537-3de5019b9e7e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("ecb39d3c-735c-8e9b-e4cd-c4c9a31ec339"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "", 0, 4, null, null, "", "" },
                    { new Guid("ed790b1d-b05f-e6a4-6360-09fd6a1a4feb"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "utility-storage", "Utility Storage", 1, "utility", 0, 1, null, null, "", "" },
                    { new Guid("f40782a2-03df-08cc-64cf-f795b8da0a43"), 42000m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bed-unit", "Bed Unit", 2, "bedroom", 3, 4, null, null, "", "" },
                    { new Guid("f43afed5-822e-0be3-5389-e87336c8918f"), 8500m, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "side-table", "Side Table", 2, "kids-bedroom", 4, 4, null, null, "", "" }
                });

            migrationBuilder.UpdateData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4af4b50c-53f9-0d32-2e89-66e53defeb02"),
                column: "RatePerUnit",
                value: 1700m);

            migrationBuilder.UpdateData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("50cbfd48-70e4-c297-e525-af90929e2865"),
                column: "RatePerUnit",
                value: 220m);

            migrationBuilder.InsertData(
                table: "QuotationRates",
                columns: new[] { "Id", "CarcassMaterial", "CreatedAt", "CreatedByEmployeeId", "EffectiveFrom", "Finish", "IsActive", "ItemKey", "RatePerUnit", "ShutterMaterial", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey" },
                values: new object[,]
                {
                    { new Guid("0a43ced1-d4a1-5514-5b0c-73fa031e3176"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 1850m, "", 1, null, null, "openable" },
                    { new Guid("11b260d3-2c52-87f4-5321-8163421316ba"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dresser", 1900m, "", 1, null, null, "" },
                    { new Guid("50b0df2a-2c57-0588-055d-7f4a83a2b621"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "display-unit", 1800m, "", 1, null, null, "" },
                    { new Guid("51a63c00-cab8-6fe5-f7f1-3404fe9b87b3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rolling-shutter-unit", 4100m, "", 1, null, null, "" },
                    { new Guid("7bedd7f4-a36c-7a3a-bcff-76f109f68e4a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wallpaper", 120m, "", 1, null, null, "" },
                    { new Guid("7c7dc121-2803-0f50-590f-4bada033025a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "utility-storage", 1450m, "", 1, null, null, "" },
                    { new Guid("a170f3fa-1800-8d45-0360-1311ce66ace5"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "blinds", 380m, "", 1, null, null, "" },
                    { new Guid("c48dffd7-4938-ae82-e81d-e8917e93a376"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rafters", 950m, "", 2, null, null, "" },
                    { new Guid("dc60cb07-d05e-2bc9-43de-a0804f39d668"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "loft-storage", 1500m, "", 1, null, null, "" },
                    { new Guid("e84b7f95-fa20-a61c-e2f6-c5ddcc375eb5"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2150m, "", 1, null, null, "sliding" },
                    { new Guid("f83c889a-01d9-e4bb-0ecd-b705fc4ccdfe"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dining-storage", 1900m, "", 1, null, null, "" }
                });
        }
    }
}
