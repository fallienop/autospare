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
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Orders_OrdersId",
                table: "OrderPart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Part_PartsId",
                table: "OrderPart");

            migrationBuilder.RenameColumn(
                name: "PartsId",
                table: "OrderPart",
                newName: "PartId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrderPart",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPart_PartsId",
                table: "OrderPart",
                newName: "IX_OrderPart_PartId");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderPart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Orders_OrderId",
                table: "OrderPart",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Part_PartId",
                table: "OrderPart",
                column: "PartId",
                principalSchema: "Product",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Orders_OrderId",
                table: "OrderPart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Part_PartId",
                table: "OrderPart");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderPart");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "OrderPart",
                newName: "PartsId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderPart",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPart_PartId",
                table: "OrderPart",
                newName: "IX_OrderPart_PartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Orders_OrdersId",
                table: "OrderPart",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Part_PartsId",
                table: "OrderPart",
                column: "PartsId",
                principalSchema: "Product",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
