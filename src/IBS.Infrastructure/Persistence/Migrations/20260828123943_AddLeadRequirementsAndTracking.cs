using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLeadRequirementsAndTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ContactedDate",
                table: "Leads",
                type: "date",
                nullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsInterested",
                table: "Leads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "NextFollowUpDate",
                table: "Leads",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallStatus",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "PropertyConfiguration",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PropertySize",
                table: "Leads",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertySizeUnit",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuotationSharedStatus",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "LeadRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadRooms_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadRoomRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadRoomRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadRoomRequirements_LeadRooms_LeadRoomId",
                        column: x => x.LeadRoomId,
                        principalTable: "LeadRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_NextFollowUpDate",
                table: "Leads",
                column: "NextFollowUpDate");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_OverallStatus",
                table: "Leads",
                column: "OverallStatus");

            migrationBuilder.CreateIndex(
                name: "IX_LeadRoomRequirements_LeadRoomId",
                table: "LeadRoomRequirements",
                column: "LeadRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadRooms_LeadId",
                table: "LeadRooms",
                column: "LeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadRoomRequirements");

            migrationBuilder.DropTable(
                name: "LeadRooms");

            migrationBuilder.DropIndex(
                name: "IX_Leads_NextFollowUpDate",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_OverallStatus",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "ContactedDate",
                table: "Leads");

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
                name: "IsInterested",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "NextFollowUpDate",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "OverallStatus",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PropertyConfiguration",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PropertySize",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PropertySizeUnit",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "QuotationSharedStatus",
                table: "Leads");
        }
    }
}
