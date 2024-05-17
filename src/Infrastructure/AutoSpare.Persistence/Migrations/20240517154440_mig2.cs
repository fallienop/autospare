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
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "Product",
                table: "Part",
                newName: "Image3");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Product",
                table: "Part",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image1",
                schema: "Product",
                table: "Part",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image2",
                schema: "Product",
                table: "Part",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Product",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Image1",
                schema: "Product",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Image2",
                schema: "Product",
                table: "Part");

            migrationBuilder.RenameColumn(
                name: "Image3",
                schema: "Product",
                table: "Part",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
