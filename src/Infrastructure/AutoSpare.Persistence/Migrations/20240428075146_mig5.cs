using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSpare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                schema: "Product",
                table: "Part",
                newName: "StartYear");

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                schema: "Product",
                table: "Part",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndYear",
                schema: "Product",
                table: "Part");

            migrationBuilder.RenameColumn(
                name: "StartYear",
                schema: "Product",
                table: "Part",
                newName: "Year");
        }
    }
}
