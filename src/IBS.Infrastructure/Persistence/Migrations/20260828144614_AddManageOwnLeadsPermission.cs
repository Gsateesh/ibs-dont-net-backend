using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddManageOwnLeadsPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByEmployeeId", "Description", "GroupName", "Name", "SortOrder", "UpdatedAt", "UpdatedByEmployeeId" },
                values: new object[] { new Guid("9e5b0000-0000-4000-8000-000000000021"), "manage_own_leads", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "View and edit only the leads assigned to them. Cannot reassign or delete a lead.", "Sales pipeline", "Can manage own leads", 21, null, null });

            // Backfill. The Leads module used to be readable by any signed-in employee; it now
            // needs one of the two leads permissions, so without this everyone currently working
            // a lead would lose the page the moment this ships. Grants the new permission to
            // employees who actually have a lead assigned and do not already hold a leads
            // permission. GrantedByEmployeeId is null - the same convention the seed tool uses
            // for a grant no person made.
            migrationBuilder.Sql(@"
                INSERT INTO [EmployeePermissions] ([EmployeeId], [PermissionId], [GrantedByEmployeeId], [GrantedAt])
                SELECT DISTINCT
                    e.[Id],
                    '9E5B0000-0000-4000-8000-000000000021',
                    NULL,
                    SYSDATETIMEOFFSET()
                FROM [Employees] e
                WHERE EXISTS (SELECT 1 FROM [Leads] l WHERE l.[AssignedToEmployeeId] = e.[Id])
                  AND e.[Status] IN (1, 2)
                  AND NOT EXISTS (
                        SELECT 1
                        FROM [EmployeePermissions] ep
                        JOIN [Permissions] p ON p.[Id] = ep.[PermissionId]
                        WHERE ep.[EmployeeId] = e.[Id]
                          AND p.[Code] IN ('manage_leads', 'manage_own_leads'));");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // The grants must go before the catalogue row they point at, or the delete below
            // trips the foreign key.
            migrationBuilder.Sql(
                "DELETE FROM [EmployeePermissions] " +
                "WHERE [PermissionId] = '9E5B0000-0000-4000-8000-000000000021';");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9e5b0000-0000-4000-8000-000000000021"));
        }
    }
}
