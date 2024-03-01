using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDISigorta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_ProductHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangedPartCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProfitCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProfitMargin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RepairedPartCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "ProductHistories");

            migrationBuilder.RenameColumn(
                name: "RiskCost",
                table: "Products",
                newName: "RepairOrChangedPartCost");

            migrationBuilder.AddColumn<double>(
                name: "ProfitCost",
                table: "ProductHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProfitMargin",
                table: "ProductHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RepairOrChangedPartCost",
                table: "ProductHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RiskCost",
                table: "ProductHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalRepairOrChangedPartCost",
                table: "ProductHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitCost",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "ProfitMargin",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "RepairOrChangedPartCost",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "RiskCost",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "TotalRepairOrChangedPartCost",
                table: "ProductHistories");

            migrationBuilder.RenameColumn(
                name: "RepairOrChangedPartCost",
                table: "Products",
                newName: "RiskCost");

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
                name: "ProfitMargin",
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

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "ProductHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
