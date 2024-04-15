
#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WomenClothingAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
            migrationBuilder.InsertData(
        table: "Products",
        columns: new[] { "Id", "Name", "Description", "Price", "ImageUrl" },
        values: new object[,]
        {
            { 1, "Dress 1", "Elegant dress for ladies", 50.00m, "https://via.placeholder.com/150" },
            { 2, "Jeans 1", "Comfortable jeans for everyday wear", 35.00m, "https://via.placeholder.com/150" },
            { 3, "Shirt 1", "Stylish shirt for women", 25.00m, "https://via.placeholder.com/150" },
            { 4, "Skirt 1", "Trendy skirt for any occasion", 40.00m, "https://via.placeholder.com/150" },
            { 5, "Jacket 1", "Warm jacket for chilly weather", 60.00m, "https://via.placeholder.com/150" },
            { 6, "Dress 2", "Another elegant dress for ladies", 55.00m, "https://via.placeholder.com/150" },
            { 7, "Jeans 2", "Another comfortable jeans for everyday wear", 30.00m, "https://via.placeholder.com/150" },
            { 8, "Shirt 2", "Another stylish shirt for women", 20.00m, "https://via.placeholder.com/150" },
            { 9, "Skirt 2", "Another trendy skirt for any occasion", 45.00m, "https://via.placeholder.com/150" },
            { 10, "Jacket 2", "Another warm jacket for chilly weather", 70.00m, "https://via.placeholder.com/150" },
            { 11, "Dress 3", "Casual dress with a floral print", 45.00m, "https://via.placeholder.com/150" },
            { 12, "Jeans 3", "Slim-fit jeans with distressed finish", 40.00m, "https://via.placeholder.com/150" },
            { 13, "Shirt 3", "Striped shirt with button-down collar", 30.00m, "https://via.placeholder.com/150" },
            { 14, "Skirt 3", "A-line skirt in a bold color", 35.00m, "https://via.placeholder.com/150" },
            { 15, "Jacket 3", "Faux leather moto jacket", 80.00m, "https://via.placeholder.com/150" },
            { 16, "Dress 4", "Fit-and-flare dress for special occasions", 65.00m, "https://via.placeholder.com/150" },
            { 17, "Jeans 4", "High-waisted skinny jeans", 50.00m, "https://via.placeholder.com/150" },
            { 18, "Shirt 4", "V-neck blouse with ruffled sleeves", 25.00m, "https://via.placeholder.com/150" },
            { 19, "Skirt 4", "Pleated midi skirt for a feminine look", 45.00m, "https://via.placeholder.com/150" },
            { 20, "Jacket 4", "Quilted puffer jacket for cold days", 90.00m, "https://via.placeholder.com/150" }
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
