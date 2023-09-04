using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShopNew.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductCategory",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategory",
                table: "Products");
        }
    }
}
