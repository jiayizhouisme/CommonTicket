using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    basicPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    trade_no = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    objectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.trade_no);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    authLevel = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    objectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    sale = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Appointment_Exhibition_objectId",
                        column: x => x.objectId,
                        principalTable: "Exhibition",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "WechatBill",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false),
                    _id = table.Column<int>(type: "int", nullable: false),
                    sourceId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    payTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    paymentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    parameters = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    payedMsg = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tradeNo = table.Column<long>(type: "bigint", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WechatBill", x => x.id);
                    table.ForeignKey(
                        name: "FK_WechatBill_Order_tradeNo",
                        column: x => x.tradeNo,
                        principalTable: "Order",
                        principalColumn: "trade_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserInfo_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TUserId = table.Column<int>(type: "int", nullable: false),
                    ticketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stauts = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    objectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x._id);
                    table.ForeignKey(
                        name: "FK_Ticket_UserInfo_TUserId",
                        column: x => x.TUserId,
                        principalTable: "UserInfo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_objectId",
                table: "Appointment",
                column: "objectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_objectId",
                table: "Ticket",
                column: "objectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TUserId_startTime_endTime",
                table: "Ticket",
                columns: new[] { "TUserId", "startTime", "endTime" });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_userID",
                table: "UserInfo",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_WechatBill_tradeNo",
                table: "WechatBill",
                column: "tradeNo");
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
