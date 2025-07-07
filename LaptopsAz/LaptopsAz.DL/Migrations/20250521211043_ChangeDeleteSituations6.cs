using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopsAz.DL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteSituations6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71c22796-8b4d-4374-8e1e-780f38ec953e", "AQAAAAIAAYagAAAAEAygXBEns8GuJEKjT1cuqJIQeLRJbG2ehBfCflAc0AbNUJU0bZZdd1O0nsm9SjyK3w==", "c78690dd-410f-4b0d-b9f9-a0312a344701" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4c96c2b-e1be-4ef8-81c6-08ca56c2198f", "AQAAAAIAAYagAAAAECnFjQj4iFQ4qQsCfn66hmeKmStpTpYahn1VpM5fZhZrJqZUjIed7t9BoIP0aevlWA==", "e5006687-a762-40e2-9009-56b735f110f7" });
        }
    }
}
