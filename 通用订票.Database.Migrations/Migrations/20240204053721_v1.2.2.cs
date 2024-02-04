using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WechatBill_Order_orderId",
                table: "WechatBill");

            migrationBuilder.DropIndex(
                name: "IX_WechatBill_orderId",
                table: "WechatBill");

            migrationBuilder.DropIndex(
                name: "IX_Order_trade_no",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "WechatBill");

            migrationBuilder.DropColumn(
                name: "_id",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "trade_no",
                table: "Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_WechatBill_tradeNo",
                table: "WechatBill",
                column: "tradeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_WechatBill_Order_tradeNo",
                table: "WechatBill",
                column: "tradeNo",
                principalTable: "Order",
                principalColumn: "trade_no",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />

    }
}
