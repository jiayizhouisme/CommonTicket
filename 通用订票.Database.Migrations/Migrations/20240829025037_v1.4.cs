using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
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
                    beforeDays = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    basicPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    passType = table.Column<int>(type: "int", nullable: false),
                    exhibitions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isMultiPart = table.Column<bool>(type: "bit", nullable: false),
                    forbiddenRule = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MultiTicket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ticketNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalCount = table.Column<int>(type: "int", nullable: false),
                    usedCount = table.Column<int>(type: "int", nullable: false),
                    cancelCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiTicket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    trade_no = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    extraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    objectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.trade_no);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ota = table.Column<int>(type: "int", nullable: false),
                    totalCount = table.Column<int>(type: "int", nullable: false),
                    usedCount = table.Column<int>(type: "int", nullable: false),
                    cancelCount = table.Column<int>(type: "int", nullable: false),
                    verifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isMultiPart = table.Column<bool>(type: "bit", nullable: false),
                    TUserId = table.Column<int>(type: "int", nullable: false),
                    ticketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stauts = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    objectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authLevel = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    openId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
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
                    userID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WechatBill",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    paymentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    Attach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WechatBill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WechatMerchantConfig",
                columns: table => new
                {
                    appid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apiv3Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RsaPublicKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WechatMerchantConfig", x => x.appid);
                });

            migrationBuilder.CreateTable(
                name: "XieChengConfig",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AESKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AESVector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XieChengConfig", x => x.Account);
                });

            migrationBuilder.CreateTable(
                name: "XieChengOrder",
                columns: table => new
                {
                    otaOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PLU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    useStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    useEndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    itemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cancelQuantity = table.Column<int>(type: "int", nullable: false),
                    useQuantity = table.Column<int>(type: "int", nullable: false),
                    passengerIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderStatus = table.Column<int>(type: "int", nullable: false),
                    trade_no = table.Column<long>(type: "bigint", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    objectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XieChengOrder", x => x.otaOrderId);
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
                    allday = table.Column<bool>(type: "bit", nullable: false),
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
                name: "XieChengTicket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketId = table.Column<int>(type: "int", nullable: false),
                    OTAPassengerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucherStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XieChengTicket", x => x.id);
                    table.ForeignKey(
                        name: "FK_XieChengTicket_Ticket_ticketId",
                        column: x => x.ticketId,
                        principalTable: "Ticket",
                        principalColumn: "_id",
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
                name: "IX_XieChengTicket_ticketId",
                table: "XieChengTicket",
                column: "ticketId",
                unique: true);
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
                name: "WechatBill");

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
