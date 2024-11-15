using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class removedImageFromHashtag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61b93c82-70a2-4208-8ea2-57a0a5b9dd42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80d768ca-cc25-4749-8787-86b68315fe55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c47e8eb7-6ab8-4073-968c-78cc26b53b17");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Hashtags");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23431542-129d-4d8b-aeae-29d9fbb42014", null, "Admin", "ADMIN" },
                    { "28204736-508f-4dfb-a903-a5d025dff7f1", null, "Announcer", "ANNOUNCER" },
                    { "60e7c6f4-9699-4072-8ae7-1a455f9fe8d5", null, "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23431542-129d-4d8b-aeae-29d9fbb42014");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28204736-508f-4dfb-a903-a5d025dff7f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60e7c6f4-9699-4072-8ae7-1a455f9fe8d5");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Hashtags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61b93c82-70a2-4208-8ea2-57a0a5b9dd42", null, "Client", "CLIENT" },
                    { "80d768ca-cc25-4749-8787-86b68315fe55", null, "Admin", "ADMIN" },
                    { "c47e8eb7-6ab8-4073-968c-78cc26b53b17", null, "Announcer", "ANNOUNCER" }
                });
        }
    }
}
