using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class seedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2811f38e-2dc0-471e-bb2e-f75a6ddd9c85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b8bb010-7ad9-4c17-8a53-ec9aa1d00412");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beb9c455-81f0-47c3-944b-58cb5a96ed9a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2811f38e-2dc0-471e-bb2e-f75a6ddd9c85", null, "Announcer", "ANNOUNCER" },
                    { "6b8bb010-7ad9-4c17-8a53-ec9aa1d00412", null, "Client", "CLIENT" },
                    { "beb9c455-81f0-47c3-944b-58cb5a96ed9a", null, "Admin", "ADMIN" }
                });
        }
    }
}
