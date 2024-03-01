using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDISigorta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Dealer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_AspNetUsers_AppUsersId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Dealers_AppUsersId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "AppUsersId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dealers");

            migrationBuilder.AddColumn<Guid>(
                name: "DealerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUsersId",
                table: "Dealers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Dealers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_AppUsersId",
                table: "Dealers",
                column: "AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_AspNetUsers_AppUsersId",
                table: "Dealers",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
