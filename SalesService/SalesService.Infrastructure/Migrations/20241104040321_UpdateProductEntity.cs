using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                schema: "inventory",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ProductStatus",
                schema: "inventory",
                table: "Product",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
