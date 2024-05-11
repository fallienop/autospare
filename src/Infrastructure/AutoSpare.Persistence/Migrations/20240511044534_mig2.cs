using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSpare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CityCode",
                table: "CityCode");

            migrationBuilder.RenameTable(
                name: "CityCode",
                newName: "CityCodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityCodes",
                table: "CityCodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Views = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityCodes",
                table: "CityCodes");

            migrationBuilder.RenameTable(
                name: "CityCodes",
                newName: "CityCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityCode",
                table: "CityCode",
                column: "Id");
        }
    }
}
