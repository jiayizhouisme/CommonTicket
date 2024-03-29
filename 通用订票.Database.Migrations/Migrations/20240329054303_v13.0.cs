using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v130 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
           
            migrationBuilder.CreateTable(
                name: "XieChengOrder",
                columns: table => new
                {
                    trade_no = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PLU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    otaOrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    useStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    useEndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    objectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XieChengOrder", x => x.trade_no);
                });

            migrationBuilder.CreateTable(
                name: "XieChengPassenger",
                columns: table => new
                {
                    passengerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationalityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XieChengPassenger", x => x.passengerId);
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "WechatBill");

            migrationBuilder.DropTable(
                name: "XieChengConfig");

            migrationBuilder.DropTable(
                name: "XieChengOrder");

            migrationBuilder.DropTable(
                name: "XieChengPassenger");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
