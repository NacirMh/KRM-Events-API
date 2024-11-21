using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class changedNameOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b98f91d-129f-44ee-8ff5-207368684e4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e0d2ee-0fed-4245-8650-90d65a5ae2d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f36a82c9-3eb4-4e6c-8e65-e7114e19515b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5de1e2f4-4932-4101-9554-4892dbd373fe", null, "Announcer", "ANNOUNCER" },
                    { "9af33333-bf03-49eb-b967-61860026fbe8", null, "Client", "CLIENT" },
                    { "ef067651-be67-4370-911d-3f4c1e555426", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5de1e2f4-4932-4101-9554-4892dbd373fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af33333-bf03-49eb-b967-61860026fbe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef067651-be67-4370-911d-3f4c1e555426");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b98f91d-129f-44ee-8ff5-207368684e4b", null, "Admin", "ADMIN" },
                    { "e8e0d2ee-0fed-4245-8650-90d65a5ae2d9", null, "Announcer", "ANNOUNCER" },
                    { "f36a82c9-3eb4-4e6c-8e65-e7114e19515b", null, "Client", "CLIENT" }
                });
        }
    }
}
