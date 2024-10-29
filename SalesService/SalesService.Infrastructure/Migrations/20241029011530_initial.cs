using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customer");

            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "inventory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Amount = table.Column<int>(type: "INT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    ProductStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoldIn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    SoldBy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ProductAmount = table.Column<byte>(type: "TINYINT", nullable: false),
                    ProductUnitPrice = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    ProductUnitDiscount = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    SaleTotalPrice = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    SaleStatus = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "sale");
        }
    }
}
