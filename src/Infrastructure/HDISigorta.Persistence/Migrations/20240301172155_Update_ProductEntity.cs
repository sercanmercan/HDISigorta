﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDISigorta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_ProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DealerId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "Products");
        }
    }
}
