using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class addedkeytoOpiniontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2294a9a3-a383-48b0-bed6-066528802d29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b68e3bb2-c586-4428-bb4c-0c87f51dd257");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c29a9e8a-6679-4d75-90fd-e26a7a762933");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Opinions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01b39678-c098-4359-91d5-64d6dde75e95", null, "Announcer", "ANNOUNCER" },
                    { "45891d4f-f995-464e-a139-3cfc5c11fd27", null, "Client", "CLIENT" },
                    { "e9ffc93b-58a8-4b3f-973d-5636e6292787", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_EventId",
                table: "Opinions",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions");

            migrationBuilder.DropIndex(
                name: "IX_Opinions_EventId",
                table: "Opinions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01b39678-c098-4359-91d5-64d6dde75e95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45891d4f-f995-464e-a139-3cfc5c11fd27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9ffc93b-58a8-4b3f-973d-5636e6292787");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Opinions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions",
                columns: new[] { "EventId", "ClientId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2294a9a3-a383-48b0-bed6-066528802d29", null, "Admin", "ADMIN" },
                    { "b68e3bb2-c586-4428-bb4c-0c87f51dd257", null, "Client", "CLIENT" },
                    { "c29a9e8a-6679-4d75-90fd-e26a7a762933", null, "Announcer", "ANNOUNCER" }
                });
        }
    }
}
