using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteSituations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecs_Products_ProductID",
                table: "ProductSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "618d33f8-cb10-41bb-b21f-71330981e7b3", "AQAAAAIAAYagAAAAEIOit5OgXFzf4wb6m2P+URY3XaB7jUHxiLbqYHd1bos3e9GT/kqfVVoPvcMZrFNi5Q==", "59d6c120-f49e-497f-a77d-02623f68e85c" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecs_Products_ProductID",
                table: "ProductSpecs",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                table: "Reviews",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecs_Products_ProductID",
                table: "ProductSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bf3fa64-ced4-4541-a3df-0437ba7d7ca2", "AQAAAAIAAYagAAAAEDTDvV9UteVDaiLFdeHFHibXE2bY0kPhH16LaWg9JL5yEG1VUSGiiF9pDm/gQFGfWQ==", "83ec4f7f-8ad7-4e59-954e-beb6360e3e3b" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecs_Products_ProductID",
                table: "ProductSpecs",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserID",
                table: "Reviews",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
