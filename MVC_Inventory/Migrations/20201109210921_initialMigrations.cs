using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Inventory.Migrations
{
    public partial class initialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Quantity = table.Column<int>(type: "int(10)", nullable: false),
                    Discontinued = table.Column<string>(type: "char(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Discontinued", "Name", "Quantity" },
                values: new object[,]
                {
                    { -1, "1", "iPhone", 12 },
                    { -2, "1", "iPad", 2 },
                    { -3, "1", "iMac", 12 },
                    { -4, "0", "iPod", 12 },
                    { -5, "1", "Apple Watch", 4 },
                    { -6, "1", "Apple Home", 20 },
                    { -7, "0", "Apple Glasses", 10 },
                    { -8, "1", "Airpods", 19 },
                    { -9, "1", "MacBook", 7 },
                    { -10, "1", "Mac Mini", 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
