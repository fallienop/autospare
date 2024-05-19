using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSpare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Tires",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Tires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tires_CompanyId",
                table: "Tires",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tires_Companies_CompanyId",
                table: "Tires",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tires_Companies_CompanyId",
                table: "Tires");

            migrationBuilder.DropIndex(
                name: "IX_Tires_CompanyId",
                table: "Tires");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Tires");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Tires");
        }
    }
}
