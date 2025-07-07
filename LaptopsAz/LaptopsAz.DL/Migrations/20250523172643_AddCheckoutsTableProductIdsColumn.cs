using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckoutsTableProductIdsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductIds",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd572d59-a0f7-4f8c-8e99-372cc2433bdf", "AQAAAAIAAYagAAAAEI3mQ5RbsG/GRgL0qUDDCE5nsGxHv5hbvHHmxtN5hZnFCXLxTh2P1SsKHYq5gRwGVw==", "f6c12f9a-09dc-41ff-9351-cf4947537124" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "Checkouts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91e3eada-b7ad-4b04-9915-4ae230206975", "AQAAAAIAAYagAAAAEA9uC0EN7uWHWaRXPplkgvqKGJLl/RHk6D3N+dshjxzApQ8TS6bbB8loHsaUiyYpGg==", "97e9548f-e763-41fd-80db-fb03eb80a82c" });
        }
    }
}
