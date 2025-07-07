using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSliderItemConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SliderItems",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bf3fa64-ced4-4541-a3df-0437ba7d7ca2", "AQAAAAIAAYagAAAAEDTDvV9UteVDaiLFdeHFHibXE2bY0kPhH16LaWg9JL5yEG1VUSGiiF9pDm/gQFGfWQ==", "83ec4f7f-8ad7-4e59-954e-beb6360e3e3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SliderItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ecb9d95-a341-45f7-8c92-d1ca6c1679e1", "AQAAAAIAAYagAAAAEJgxmjoI6NsT8WKuxJ97Fy7adeeBfk0bheSFxWSwfn4WqjeNAqbySKHChU2dPuEMdg==", "70461e7f-9c3a-4c08-b016-a073cb425878" });
        }
    }
}
