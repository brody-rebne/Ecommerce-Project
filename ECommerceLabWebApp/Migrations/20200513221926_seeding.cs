using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceLabWebApp.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartID = table.Column<string>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    CartID1 = table.Column<int>(nullable: true),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.CartID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartID1",
                        column: x => x.CartID1,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageUrl", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Spicy Pickled Pigs Feet", "/../img/PigFeet.jpg", "Pigs Feet", 2m, "12345" },
                    { 2, "One package of delicous cheese", "/../img/cheese.jpg", "Cheese", 1m, "23456" },
                    { 3, "Four raw eggs", "/../img/cheese.jpg", "Eggs", 5m, "34567" },
                    { 4, "Small bag of Chicken and Waffles chips", "/../img/Chips.jpg", "Chips", 3m, "45678" },
                    { 5, "One medium sized bag of jerky", "/../img/Jerky.jpg", "Jerky", 7m, "56789" },
                    { 6, "One can of delicous Lutefisk", "/../img/Lutefisk.jpg", "Lutefisk", 8m, "67890" },
                    { 7, "High in protein", "/../img/Caterpillar.jpg", "Catepillars", 5m, "78901" },
                    { 8, "One bag of microwavable Pork Rinds", "/../img/PorkRindsjpg", "Pork Rinds", 3m, "89012" },
                    { 9, "America's Favorite!", "/../img/ViennaSausage.jpg", "Vienna Sausage", 1m, "90123" },
                    { 10, "One can of beans", "/../img/beans.jpg", "Beans", 1m, "01235" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID1",
                table: "CartItems",
                column: "CartID1");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
