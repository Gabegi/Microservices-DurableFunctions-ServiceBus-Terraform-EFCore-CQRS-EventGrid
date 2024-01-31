using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "CustomerId", "LastUpdated", "RequestId", "TanicLevelOutOfTen", "WineName", "WinePrice", "WineQuantity", "WineType" },
                values: new object[] { 1001, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Chianti", 30f, 2, "Red" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1001);

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "CustomerId", "LastUpdated", "TanicLevelOutOfTen", "WineName", "WinePrice", "WineQuantity", "WineType" },
                values: new object[] { 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Chianti", 30f, 2, "Red" });
        }
    }
}
