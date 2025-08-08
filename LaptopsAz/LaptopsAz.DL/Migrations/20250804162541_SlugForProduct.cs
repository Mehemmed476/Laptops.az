using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class SlugForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8361564-6bb5-48f4-88ba-f3b199e9d7d0", "AQAAAAIAAYagAAAAELNXFEy/lnoC2pyLcgZQ0oc8tvh4hSeRl5xp0rrmyfwrw+x54IwPF6Q8ySjCaPFHGA==", "302fc5b2-ed89-43c8-982d-e14664589b1c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e4fc0d7-cf50-4931-b4ac-90b47d600297", "AQAAAAIAAYagAAAAEFMQ6UZ8gN6914sO830Spy8Er5taBSz2S7SroldF9f1kMqIv86vZqWVPjBIqXI9UKQ==", "d0d35b7e-1883-4d7b-98f3-146e50868db6" });
        }
    }
}
