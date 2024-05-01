using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSpare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Make_MakeId",
                schema: "Product",
                table: "Model");

            migrationBuilder.AlterColumn<Guid>(
                name: "MakeId",
                schema: "Product",
                table: "Model",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Make_MakeId",
                schema: "Product",
                table: "Model",
                column: "MakeId",
                principalSchema: "Product",
                principalTable: "Make",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Make_MakeId",
                schema: "Product",
                table: "Model");

            migrationBuilder.AlterColumn<Guid>(
                name: "MakeId",
                schema: "Product",
                table: "Model",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Make_MakeId",
                schema: "Product",
                table: "Model",
                column: "MakeId",
                principalSchema: "Product",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
