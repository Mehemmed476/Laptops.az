using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteSituations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f62ece6a-29e5-433e-9acb-89089de9e05b", "AQAAAAIAAYagAAAAEPueX1LjLsxou5XOw48Mq/U3sgnB6YfHW9MEXPU3mM6K/i77SsCTQ9XpWsYqB71b+g==", "45fff195-5717-4b7b-aa3f-ca8298c4eab4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "618d33f8-cb10-41bb-b21f-71330981e7b3", "AQAAAAIAAYagAAAAEIOit5OgXFzf4wb6m2P+URY3XaB7jUHxiLbqYHd1bos3e9GT/kqfVVoPvcMZrFNi5Q==", "59d6c120-f49e-497f-a77d-02623f68e85c" });
        }
    }
}
