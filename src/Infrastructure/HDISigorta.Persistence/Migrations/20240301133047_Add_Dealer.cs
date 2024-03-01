using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDISigorta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Dealer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DealerName",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullAdress",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealerName",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "FullAdress",
                table: "Dealers");
        }
    }
}
