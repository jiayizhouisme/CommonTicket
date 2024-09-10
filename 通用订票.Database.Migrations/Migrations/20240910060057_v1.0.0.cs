using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "WechatBillRefund",
                columns: table => new
                {
                    refundId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aftersalesId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    sourceId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    paymentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tradeNo = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WechatBillRefund", x => x.refundId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "MultiTicket");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "WebRouteConfig");

            migrationBuilder.DropTable(
                name: "WechatBill");

            migrationBuilder.DropTable(
                name: "WechatBillRefund");

            migrationBuilder.DropTable(
                name: "WechatMerchantConfig");

            migrationBuilder.DropTable(
                name: "XieChengConfig");

            migrationBuilder.DropTable(
                name: "XieChengOrder");

            migrationBuilder.DropTable(
                name: "XieChengPassenger");

            migrationBuilder.DropTable(
                name: "XieChengTicket");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
