using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLeadCustomerCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerNumber",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Every existing row lands on the column's default of 0, which the unique index
            // below would then reject the moment a second lead exists. Numbered in creation
            // order before the index goes on, so the backfill reads the same way new leads are
            // numbered from here on - oldest first.
            migrationBuilder.Sql("""
                ;WITH Ordered AS (
                    SELECT Id, ROW_NUMBER() OVER (ORDER BY CreatedAt, Id) AS Rn
                    FROM Leads
                )
                UPDATE L
                SET L.CustomerNumber = Ordered.Rn
                FROM Leads L
                INNER JOIN Ordered ON Ordered.Id = L.Id;
                """);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CustomerNumber",
                table: "Leads",
                column: "CustomerNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leads_CustomerNumber",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "Leads");
        }
    }
}
