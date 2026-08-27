using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHyderabadBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "City", "CreatedAt", "CreatedByEmployeeId", "Name", "Timezone", "UpdatedAt", "UpdatedByEmployeeId" },
                values: new object[] { new Guid("b7a10000-0000-4000-8000-000000000004"), null, "Hyderabad", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Hyderabad", "Asia/Kolkata", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("b7a10000-0000-4000-8000-000000000004"));
        }
    }
}
