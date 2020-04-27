using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceLabWebApp.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageUrl", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Description of Widget", "", "Widget", 30m, "12345" },
                    { 2, "Description of Sprocket", "", "Sprocket", 45m, "23456" },
                    { 3, "Description of Thingamabob", "", "Thingamabob", 15m, "34567" },
                    { 4, "Description of Gizmo", "", "Gizmo", 200m, "45678" },
                    { 5, "Description of Gadget", "", "Gadget", 70m, "56789" },
                    { 6, "Description of Device", "", "Device", 90m, "67890" },
                    { 7, "Description of Doohickey", "", "Doohickey", 5m, "78901" },
                    { 8, "Description of Rube Goldberg Machine", "", "Rube Goldberg Machine", 42m, "89012" },
                    { 9, "Description of Contraption", "", "Contraption", 100m, "90123" },
                    { 10, "Description of Whatchamacallit", "", "Whatchamacallit", 0m, "01234" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
