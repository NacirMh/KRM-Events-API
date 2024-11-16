using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class addedTitleToContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a27ac80-8b6f-42a1-80fa-7799e5ee79b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fbe5bd3-1da6-46f2-819a-df182321af59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b420ecd0-e4ac-45a7-8c1c-7ab6ad1e848a");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Opinions");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Opinions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a27ac80-8b6f-42a1-80fa-7799e5ee79b1", null, "Admin", "ADMIN" },
                    { "7fbe5bd3-1da6-46f2-819a-df182321af59", null, "Announcer", "ANNOUNCER" },
                    { "b420ecd0-e4ac-45a7-8c1c-7ab6ad1e848a", null, "Client", "CLIENT" }
                });
        }
    }
}
