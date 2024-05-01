using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSpare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                schema: "Product",
                table: "Part",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "Product",
                table: "Part",
                newName: "ImageName");
        }
    }
}
