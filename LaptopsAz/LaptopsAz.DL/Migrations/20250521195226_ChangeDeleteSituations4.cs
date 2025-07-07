using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteSituations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db615d43-7c0c-46da-b1a3-565684d4d94a", "AQAAAAIAAYagAAAAEGnHqwwjO56LojhpdonZ62r4E5yu60uMdyBd4p2nrAd8gKFDBK5m/asC8w6LVp6z2A==", "48340165-bc20-4e9c-91e2-502d63f5cb55" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eec2cce-9c42-401a-9bfa-c6db2c9b7f9b", "AQAAAAIAAYagAAAAEFI4Hkzx0pigrhJ9AyCnDg4nq5MYKzofe4EqfU7AohcLVXETTAcyoae2x6hxeHxyFA==", "adf00c55-2f94-433c-92ad-28c6385e6ee9" });
        }
    }
}
