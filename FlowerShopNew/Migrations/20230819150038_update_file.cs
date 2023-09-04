using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShopNew.Migrations
{
    /// <inheritdoc />
    public partial class update_file : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
