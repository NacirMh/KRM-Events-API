using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class changedPriceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c96c150-8a52-48a5-a1a9-5c5be8991f46", null, "Admin", "ADMIN" },
                    { "95f8fca9-170c-410c-93ed-adad6f395b63", null, "Announcer", "ANNOUNCER" },
                    { "ea81137e-c1a4-444b-9d29-6ffb89a406e3", null, "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c96c150-8a52-48a5-a1a9-5c5be8991f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f8fca9-170c-410c-93ed-adad6f395b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea81137e-c1a4-444b-9d29-6ffb89a406e3");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01b39678-c098-4359-91d5-64d6dde75e95", null, "Announcer", "ANNOUNCER" },
                    { "45891d4f-f995-464e-a139-3cfc5c11fd27", null, "Client", "CLIENT" },
                    { "e9ffc93b-58a8-4b3f-973d-5636e6292787", null, "Admin", "ADMIN" }
                });
        }
    }
}
