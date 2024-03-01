using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDISigorta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "ChangedPartCost",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProfitCost",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RepairedPartCost",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangedPartCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProfitCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RepairedPartCost",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
