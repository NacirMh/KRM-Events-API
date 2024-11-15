using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class addedKeyToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c91700b-aa73-49a1-b540-7efacbea160c", null, "Client", "CLIENT" },
                    { "864541d0-3885-42b3-9e9b-5604c6f16d8d", null, "Announcer", "ANNOUNCER" },
                    { "a9d7dc23-7102-43ce-8d28-0ca8f891ff4b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c91700b-aa73-49a1-b540-7efacbea160c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "864541d0-3885-42b3-9e9b-5604c6f16d8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9d7dc23-7102-43ce-8d28-0ca8f891ff4b");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                columns: new[] { "EventId", "ClientId" });

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
    }
}
