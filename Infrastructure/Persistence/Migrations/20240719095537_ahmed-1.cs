using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ahmed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { new Guid("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"), new DateTime(2024, 7, 19, 9, 55, 37, 288, DateTimeKind.Utc).AddTicks(8780), "Default Description", new DateTime(2024, 7, 19, 9, 55, 37, 288, DateTimeKind.Utc).AddTicks(8781), "Default Company" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { new Guid("a248dbf5-34d2-402c-b5d4-b882911d8768"), new DateTime(2024, 7, 19, 9, 55, 37, 290, DateTimeKind.Utc).AddTicks(2028), "Default Description", new DateTime(2024, 7, 19, 9, 55, 37, 290, DateTimeKind.Utc).AddTicks(2029), "Default Company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "LastUpdatedDate", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("a6cec149-f87b-43e0-b4e8-43fa24e05c58"), new DateTime(2024, 7, 19, 9, 55, 37, 290, DateTimeKind.Utc).AddTicks(3490), "Default Description", "Default@gmail.com", new DateTime(2024, 7, 19, 9, 55, 37, 290, DateTimeKind.Utc).AddTicks(3490), "Default Name", new byte[] { 150, 64, 215, 160, 0, 146, 156, 179, 214, 212, 16, 29, 128, 117, 73, 193, 183, 69, 33, 208, 150, 119, 171, 203, 114, 207, 162, 1, 70, 56, 37, 253, 12, 20, 38, 32, 219, 224, 198, 24, 72, 123, 33, 112, 99, 37, 205, 37, 51, 185, 112, 79, 224, 137, 205, 114, 25, 22, 218, 161, 129, 157, 94, 128 }, new byte[] { 75, 243, 92, 60, 207, 118, 105, 137, 119, 57, 98, 44, 233, 204, 47, 132, 153, 142, 137, 150, 162, 11, 170, 205, 189, 173, 137, 173, 113, 140, 245, 103, 83, 45, 188, 63, 208, 190, 183, 169, 218, 225, 195, 253, 17, 55, 227, 85, 66, 43, 182, 192, 139, 249, 104, 248, 157, 70, 94, 208, 197, 173, 43, 147, 71, 155, 166, 246, 213, 42, 209, 79, 80, 169, 248, 46, 181, 69, 130, 43, 238, 253, 43, 214, 35, 244, 14, 132, 15, 28, 141, 223, 70, 163, 168, 255, 6, 155, 200, 243, 3, 168, 182, 108, 17, 209, 179, 159, 158, 230, 209, 41, 254, 1, 50, 218, 3, 174, 131, 0, 116, 55, 221, 144, 33, 167, 26, 180 } });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "LastUpdatedDate", "Name", "OrderStatus", "ProductCount", "TotalPrice", "UnitPrice", "UserId" },
                values: new object[] { new Guid("3419f0b4-29ed-4603-a6af-80838c5cacdd"), new Guid("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"), new DateTime(2024, 7, 19, 9, 55, 37, 288, DateTimeKind.Utc).AddTicks(9210), new DateTime(2024, 7, 19, 9, 55, 37, 288, DateTimeKind.Utc).AddTicks(9210), "Default Company", 0, 100, 1000m, 10m, new Guid("a6cec149-f87b-43e0-b4e8-43fa24e05c58") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "Description", "LastUpdatedDate", "Name", "Price", "ProductCategoryId", "StockCount" },
                values: new object[] { new Guid("b520d963-aad4-4df9-b0ec-e89f5c82d52d"), new Guid("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"), new DateTime(2024, 7, 19, 9, 55, 37, 290, DateTimeKind.Utc).AddTicks(2434), "Default Description", new DateTime(2024, 7, 19, 9, 55, 37, 290, DateTimeKind.Utc).AddTicks(2434), "Default Name", 100m, new Guid("a248dbf5-34d2-402c-b5d4-b882911d8768"), 100 });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("3419f0b4-29ed-4603-a6af-80838c5cacdd"), new Guid("b520d963-aad4-4df9-b0ec-e89f5c82d52d") });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
