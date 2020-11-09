using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Inventory.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Discontinued", "Name", "Quantity" },
                values: new object[,]
                {
                    { -1, 1, "iPhone", 12 },
                    { -2, 1, "iPad", 2 },
                    { -3, 1, "iMac", 12 },
                    { -4, 0, "iPod", 12 },
                    { -5, 1, "Apple Watch", 4 },
                    { -6, 1, "Apple Home", 20 },
                    { -7, 1, "Apple Glasses", 0 },
                    { -8, 1, "Airpods", 19 },
                    { -9, 1, "MacBook", 7 },
                    { -10, 1, "Mac Mini", 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
