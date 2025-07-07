using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddShortVideosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortVideos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortVideos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e4fc0d7-cf50-4931-b4ac-90b47d600297", "AQAAAAIAAYagAAAAEFMQ6UZ8gN6914sO830Spy8Er5taBSz2S7SroldF9f1kMqIv86vZqWVPjBIqXI9UKQ==", "d0d35b7e-1883-4d7b-98f3-146e50868db6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortVideos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56b1351c-656c-4336-b889-8828fc2833f5", "AQAAAAIAAYagAAAAECcGZo5Hkae1YMA4cT3ofeFG+crZ4tuGhDnE8mDQwU2fy0E//vywUCJLiMYWO9H3yA==", "97f7bdce-734d-43b7-a6a1-32ce625e75c5" });
        }
    }
}
