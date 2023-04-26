using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    public partial class InsertSeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HairCuts",
                columns: new[] { "Id", "Barber", "Date", "Type" },
                values: new object[] { 1, "Samuel", new DateTime(2023, 4, 26, 19, 15, 44, 340, DateTimeKind.Local).AddTicks(5309), "Buzz Cut" });

            migrationBuilder.InsertData(
                table: "HairCuts",
                columns: new[] { "Id", "Barber", "Date", "Type" },
                values: new object[] { 2, "Nir", new DateTime(2023, 4, 26, 19, 15, 44, 340, DateTimeKind.Local).AddTicks(5350), "Pompadur" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HairCuts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HairCuts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
