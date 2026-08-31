using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotationSharedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "QuotationSharedAt",
                table: "Leads",
                type: "date",
                nullable: true);

            // Backfill for leads that were already past the point of quoting. The real date was
            // never recorded, so the row's last-touched timestamp stands in for it - which is an
            // approximation, and deliberately preferred to leaving the column null: the fact
            // that these leads were quoted is certain, only the day is not. Anything still
            // short of a quotation, and the two terminal phases that cannot say either way,
            // are left null rather than guessed at.
            migrationBuilder.Sql(@"
                UPDATE [Leads]
                SET [QuotationSharedAt] = CAST(COALESCE([UpdatedAt], [CreatedAt]) AS date)
                WHERE [QuotationSharedAt] IS NULL
                  AND [Phase] IN (21, 22, 23, 30, 31, 32, 33, 40, 41, 42, 43, 44, 50, 51);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationSharedAt",
                table: "Leads");
        }
    }
}
