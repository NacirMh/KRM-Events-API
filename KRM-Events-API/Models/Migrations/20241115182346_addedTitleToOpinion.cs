using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KRM_Events_API.Migrations
{
    /// <inheritdoc />
    public partial class addedTitleToOpinion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "3841c4f6-e9c5-485f-b639-c5668788cb21", null, "Announcer", "ANNOUNCER" },
                    { "90b0b094-2414-4198-a704-22cbc2967c5a", null, "Admin", "ADMIN" },
                    { "ddc9e4db-ed86-4957-9548-6d52afe219de", null, "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3841c4f6-e9c5-485f-b639-c5668788cb21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90b0b094-2414-4198-a704-22cbc2967c5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc9e4db-ed86-4957-9548-6d52afe219de");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Opinions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c91700b-aa73-49a1-b540-7efacbea160c", null, "Client", "CLIENT" },
                    { "864541d0-3885-42b3-9e9b-5604c6f16d8d", null, "Announcer", "ANNOUNCER" },
                    { "a9d7dc23-7102-43ce-8d28-0ca8f891ff4b", null, "Admin", "ADMIN" }
                });
        }
    }
}
