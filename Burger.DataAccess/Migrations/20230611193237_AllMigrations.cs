using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerStation.DataAccess.Migrations
{
    public partial class AllMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhood_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientProduct",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientProduct", x => new { x.IngredientsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_IngredientProduct_Ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    NeighborhoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Neighborhood_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinalOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinalOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ana Ürün" },
                    { 2, "Yan Ürün" },
                    { 3, "İçecek" },
                    { 4, "Tatlı" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bağcılar" },
                    { 2, "Bahçelievler" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Köfte", 75m },
                    { 2, "Cheddar", 25m },
                    { 3, "Marul", 0m },
                    { 4, "Füme Et", 50m },
                    { 5, "Kaburga", 50m }
                });

            migrationBuilder.InsertData(
                table: "Neighborhood",
                columns: new[] { "Id", "DistrictId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "	100. YIL MAHALLESİ" },
                    { 2, 1, "15 TEMMUZ MAHALLESİ" },
                    { 3, 1, "BAĞLAR MAHALLESİ" },
                    { 4, 1, "BARBAROS MAHALLESİ" },
                    { 5, 1, "ÇINAR MAHALLESİ" },
                    { 6, 1, "DEMİRKAPI MAHALLESİ" },
                    { 7, 1, "FATİH MAHALLESİ" },
                    { 8, 1, "FEVZİ ÇAKMAK MAHALLESİ" },
                    { 9, 1, "GÖZTEPE MAHALLESİ" },
                    { 10, 1, "GÜNEŞLİ MAHALLESİ" },
                    { 11, 1, "HÜRRİYET MAHALLESİ" },
                    { 12, 1, "İNÖNÜ MAHALLESİ" },
                    { 13, 1, "KAZIM KARABEKİR MAHALLESİ" },
                    { 14, 1, "KEMALPAŞA MAHALLESİ" },
                    { 15, 1, "KİRAZLI MAHALLESİ" },
                    { 16, 1, "MAHMUTBEY MAHALLESİ" },
                    { 17, 1, "MERKEZ MAHALLESİ" },
                    { 18, 1, "SANCAKTEPE MAHALLESİ" },
                    { 19, 1, "YAVUZ SELİM MAHALLESİ" },
                    { 20, 1, "YENİGÜN MAHALLESİ" },
                    { 21, 1, "YENİMAHALLE MAHALLESİ" },
                    { 22, 1, "YILDIZTEPE MAHALLESİ" },
                    { 23, 2, "BAHÇELİEVLER MAHALLESİ" },
                    { 24, 2, "CUMHURİYET MAHALLESİ" },
                    { 25, 2, "ÇOBANÇEŞME MAHALLESİ" },
                    { 26, 2, "FEVZİ ÇAKMAK MAHALLESİ" },
                    { 27, 2, "HÜRRİYET MAHALLESİ" },
                    { 28, 2, "KOCASİNAN MERKEZ MAHALLESİ" },
                    { 29, 2, "SİYAVUŞPAŞA MAHALLESİ" },
                    { 30, 2, "SOĞANLI MAHALLESİ" },
                    { 31, 2, "ŞİRİNEVLER MAHALLESİ" },
                    { 32, 2, "YENİBOSNA MERKEZ MAHALLESİ" },
                    { 33, 2, "ZAFER MAHALLESİ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DistrictId",
                table: "Customer",
                column: "DistrictId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_NeighborhoodId",
                table: "Customer",
                column: "NeighborhoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrder_CustomerId",
                table: "FinalOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrder_OrderId",
                table: "FinalOrder",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientProduct_ProductsId",
                table: "IngredientProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_DistrictId",
                table: "Neighborhood",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalOrder");

            migrationBuilder.DropTable(
                name: "IngredientProduct");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "District");
        }
    }
}
