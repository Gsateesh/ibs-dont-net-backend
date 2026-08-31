using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <summary>
    /// Replaces the generic pipeline Status and the separate QuotationSharedStatus with a
    /// single Phase describing the studio's actual journey, and narrows OverallStatus to
    /// liveness only by retiring its three outcome values.
    /// </summary>
    /// <remarks>
    /// Scaffolded, then reordered by hand. EF put the DropColumn calls first, which would have
    /// reset every existing lead to the Phase default before anything had a chance to read
    /// where it actually was. The old columns are now read into Phase and only then dropped.
    /// </remarks>
    public partial class AddLeadPhase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Phase",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 10);

            // Phase from the two columns it replaces. QuotationSharedStatus is the more
            // specific of the two wherever it has moved off NotShared, so it is checked first;
            // Status only decides the phase for leads that never reached a quotation.
            //
            // The old Rejected quotation state maps to QuotationRevisionRequired rather than
            // to Lost. It was terminal in the old model, but guessing "lost" would bury a lead
            // nobody looks at again, where an over-active phase is one click to correct.
            migrationBuilder.Sql(@"
                UPDATE [Leads]
                SET [Phase] =
                    CASE
                        WHEN [Status] = 5 THEN 51                       -- Won            -> ConvertedToProject
                        WHEN [Status] = 6 THEN 52                       -- Lost           -> Lost
                        WHEN [QuotationSharedStatus] = 5 THEN 23        -- Approved       -> QuotationApproved
                        WHEN [QuotationSharedStatus] = 6 THEN 22        -- Rejected       -> QuotationRevisionRequired
                        WHEN [QuotationSharedStatus] = 4 THEN 22        -- RevisionReq'd  -> QuotationRevisionRequired
                        WHEN [QuotationSharedStatus] = 3 THEN 21        -- Shared         -> QuotationShared
                        WHEN [QuotationSharedStatus] = 2 THEN 20        -- InProgress     -> QuotationInProgress
                        WHEN [Status] = 4 THEN 21                       -- Negotiation    -> QuotationShared
                        WHEN [Status] = 3 THEN 13                       -- Qualified      -> RequirementsGathering
                        WHEN [Status] = 2 THEN 11                       -- Contacted      -> Contacted
                        ELSE 10                                         -- New            -> NewEnquiry
                    END;");

            // OverallStatus carried outcomes that Phase now owns. Where the outcome was only
            // ever recorded there, move it across before the value disappears.
            migrationBuilder.Sql(@"
                UPDATE [Leads] SET [Phase] = 51 WHERE [OverallStatus] = 4 AND [Phase] <> 51;
                UPDATE [Leads] SET [Phase] = 52 WHERE [OverallStatus] IN (5, 6) AND [Phase] NOT IN (51, 52);");

            // Converted (4), NotInterested (5) and Lost (6) all become Closed (9): no longer
            // being worked, with the phase saying which way it went.
            migrationBuilder.Sql("UPDATE [Leads] SET [OverallStatus] = 9 WHERE [OverallStatus] IN (4, 5, 6);");

            migrationBuilder.DropIndex(
                name: "IX_Leads_Status",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "QuotationSharedStatus",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Leads");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Phase",
                table: "Leads",
                column: "Phase");
        }

        /// <inheritdoc />
        /// <remarks>
        /// Lossy on purpose, and the only part that cannot be undone: Closed collapsed three
        /// former values into one, so rolling back cannot tell a converted lead from a lost
        /// one and returns every closed lead to Active. Phase is mapped back as closely as the
        /// coarser old columns allow.
        /// </remarks>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuotationSharedStatus",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.Sql(@"
                UPDATE [Leads]
                SET [Status] =
                    CASE
                        WHEN [Phase] IN (51, 50) THEN 5                 -- converted/advance -> Won
                        WHEN [Phase] IN (52, 53) THEN 6                 -- lost/closed       -> Lost
                        WHEN [Phase] BETWEEN 20 AND 44 THEN 4           -- any quote/design  -> Negotiation
                        WHEN [Phase] = 13 THEN 3                        -- requirements      -> Qualified
                        WHEN [Phase] IN (11, 12, 14, 15) THEN 2         -- contacted onward  -> Contacted
                        ELSE 1                                          --                   -> New
                    END,
                    [QuotationSharedStatus] =
                    CASE
                        WHEN [Phase] IN (23, 43) THEN 5                 -- approved
                        WHEN [Phase] = 44 THEN 6                        -- rejected
                        WHEN [Phase] IN (22, 42) THEN 4                 -- revision required
                        WHEN [Phase] IN (21, 41) THEN 3                 -- shared
                        WHEN [Phase] IN (20, 40) THEN 2                 -- in progress
                        ELSE 1                                          -- not shared
                    END;");

            migrationBuilder.Sql("UPDATE [Leads] SET [OverallStatus] = 1 WHERE [OverallStatus] = 9;");

            migrationBuilder.DropIndex(
                name: "IX_Leads_Phase",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Phase",
                table: "Leads");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Status",
                table: "Leads",
                column: "Status");
        }
    }
}
