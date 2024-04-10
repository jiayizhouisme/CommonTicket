using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "XieChengTicket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketId = table.Column<int>(type: "int", nullable: false),
                    OTAPassengerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XieChengTicket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserInfo_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ota = table.Column<int>(type: "int", nullable: false),
                    totalCount = table.Column<int>(type: "int", nullable: false),
                    usedCount = table.Column<int>(type: "int", nullable: false),
                    TUserId = table.Column<int>(type: "int", nullable: false),
                    OTAPassengerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stauts = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    objectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x._id);
                    table.ForeignKey(
                        name: "FK_Ticket_XieChengTicket__id",
                        column: x => x._id,
                        principalTable: "XieChengTicket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_UserInfo_userid",
                table: "UserInfo",
                column: "userid");

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
                name: "UserInfo");

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
                name: "XieChengTicket");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
