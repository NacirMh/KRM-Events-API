using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class fixingRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

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
                    { "23431542-129d-4d8b-aeae-29d9fbb42014", null, "Admin", "ADMIN" },
                    { "28204736-508f-4dfb-a903-a5d025dff7f1", null, "Announcer", "ANNOUNCER" },
                    { "60e7c6f4-9699-4072-8ae7-1a455f9fe8d5", null, "Client", "CLIENT" }
                });
        }
    }
}
