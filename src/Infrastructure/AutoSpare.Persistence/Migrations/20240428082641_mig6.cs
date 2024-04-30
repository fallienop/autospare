using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSpare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "Product",
                table: "Part",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Part_CategoryId",
                schema: "Product",
                table: "Part",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Categories_CategoryId",
                schema: "Product",
                table: "Part",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Categories_CategoryId",
                schema: "Product",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_CategoryId",
                schema: "Product",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Product",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");
        }
    }
}
