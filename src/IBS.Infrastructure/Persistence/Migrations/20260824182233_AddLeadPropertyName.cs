using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLeadPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "Leads",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "Leads");
        }
    }
}
