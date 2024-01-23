using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_startTime_endTime_TUserId",
                table: "Ticket");

            

            migrationBuilder.AlterColumn<string>(
                name: "objectId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "trade_no",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_startTime_endTime_TUserId_objectId",
                table: "Ticket",
                columns: new[] { "startTime", "endTime", "TUserId", "objectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_trade_no",
                table: "Order",
                column: "trade_no");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_startTime_endTime_TUserId_objectId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Order_trade_no",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("07254981-fb4c-496b-a0d1-e86617b3465c"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("0cf7b6d5-c478-4a04-ad37-16356f0771b7"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("0f40502a-f924-4ac8-a2a8-15129a1a4e43"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("1f687963-6f77-408f-b161-98d363059f77"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("2342f3b7-523a-41ac-b86c-1e2cb40a978d"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("2cec4c39-c2fa-483c-90b4-00f7d710faaf"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("355b6ef7-44f4-46f9-a3fa-2064bb7da9e9"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("386f0e6d-2fd4-4892-ba1b-aaf8b1799acb"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("41205128-1d31-4ae5-8788-1ab2adde3bd2"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("421be45c-68ca-47b2-8691-4922f95051b8"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("490cf55e-6676-4186-9ef5-54700ed1461b"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("4be2c2fe-beee-4384-a015-a17d9f158180"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("56b3fae1-7813-4ccd-af51-440fdbd2b3cf"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("5c6c0611-9f6d-45fe-a08c-a6270284d373"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("7091ef70-feff-404b-96ee-57c5c1cc288a"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("9005203d-1677-4774-a749-b52b68cf7d0d"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("953ccf5d-155b-449e-bbce-8a19e4caa909"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("96dfba80-9ee1-4c6d-962c-4d07fc91fa1a"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("a4d6eb88-5b26-4985-b7da-55d5269556db"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("a720f471-75c8-4e24-9f0d-7e46887043cf"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("aec0835a-c09a-462c-b333-dd5e24df4f80"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b299425e-dad7-480d-988b-6999640a2b91"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b7739784-9688-43fc-bfb8-09097d17ec20"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b785b181-4a15-4d98-a12d-9af6d46d46ed"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("bdbbf235-14c4-4680-b459-959bbdab628d"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("bdcb79e8-56bf-4dd6-9a9b-1ddff7a1ee06"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("d1e9bc60-cbfa-43b6-ab9c-e74bf739d81b"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("f889862f-0320-4d0d-a71b-085d6a06f534"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("fc4bf425-f575-4161-b222-f874500c72ee"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("fcc5fefb-7381-4e25-9d97-f9a5ebd4147b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "objectId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "trade_no",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "id", "basicPrice", "createTime", "description", "imgs", "isDeleted", "name", "status" },
                values: new object[,]
                {
                    { new Guid("147ea712-2302-48d2-9f68-cbcbe3bde8cc"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4109), null, null, false, "展馆19", 1 },
                    { new Guid("1f79cb85-8a97-4112-8510-649163fdb639"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4091), null, null, false, "展馆5", 1 },
                    { new Guid("2c5f0c40-4c97-4b74-a0c9-593ecd533e0f"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4118), null, null, false, "展馆29", 1 },
                    { new Guid("33db0a37-416b-46f6-ad18-d43e341daf40"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4073), null, null, false, "展馆1", 1 },
                    { new Guid("34fb8b7e-5136-4740-adea-95f1a9c4b45b"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4094), null, null, false, "展馆8", 1 },
                    { new Guid("3d66ba02-7d75-41d2-a8da-eded810b819f"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4110), null, null, false, "展馆21", 1 },
                    { new Guid("44f363fb-0185-46c1-a75d-bb145a026ec8"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4103), null, null, false, "展馆15", 1 },
                    { new Guid("4696b35e-9358-4c57-b847-464fed6e6640"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4093), null, null, false, "展馆7", 1 },
                    { new Guid("4ed6b9b3-4584-4e3d-a1dc-791546fed9f9"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4059), null, null, false, "展馆0", 1 },
                    { new Guid("4ee67853-4169-4451-8b0f-d3f0e998c7ca"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4099), null, null, false, "展馆10", 1 },
                    { new Guid("5218e573-aa65-4c98-a600-e4a2f0abb1af"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4118), null, null, false, "展馆28", 1 },
                    { new Guid("5dd82b1c-cd7b-4a6d-9665-d76b31f0c1db"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4104), null, null, false, "展馆16", 1 },
                    { new Guid("68a52747-132f-49cc-a631-e0ce4124f71d"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4106), null, null, false, "展馆17", 1 },
                    { new Guid("6e2e5918-fd88-46de-9bbb-df88b99bad76"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4100), null, null, false, "展馆12", 1 },
                    { new Guid("706bd6bf-8fa1-4526-83ff-5b77ed38581e"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4111), null, null, false, "展馆22", 1 },
                    { new Guid("777dfb3a-b3d7-4b0a-afe3-1db2d6d67d5c"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4116), null, null, false, "展馆26", 1 },
                    { new Guid("795966f7-ffa6-4f51-95a4-3565879bb2cd"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4101), null, null, false, "展馆13", 1 },
                    { new Guid("80b9a62e-2228-474e-924a-a3196634c1b5"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4112), null, null, false, "展馆23", 1 },
                    { new Guid("9b091e2d-1592-494e-b275-ee20e2b2fdde"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4117), null, null, false, "展馆27", 1 },
                    { new Guid("b2c88838-a45c-4fc4-9101-758fd7477ba3"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4096), null, null, false, "展馆9", 1 },
                    { new Guid("b837b254-f091-4a18-80ea-da66e02f9d1b"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4092), null, null, false, "展馆6", 1 },
                    { new Guid("bd3d8e68-d79f-4c52-8420-6fc447e8fe00"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4088), null, null, false, "展馆3", 1 },
                    { new Guid("c40aff43-9651-4aad-93ce-818487b122de"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4114), null, null, false, "展馆25", 1 },
                    { new Guid("c7431144-a585-453e-afc6-f539492d33a3"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4102), null, null, false, "展馆14", 1 },
                    { new Guid("d1797bee-8787-4ec3-b018-e0326fa458ea"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4110), null, null, false, "展馆20", 1 },
                    { new Guid("d69b6be1-3cc0-4f1d-8004-5e0fcf1ddb6b"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4099), null, null, false, "展馆11", 1 },
                    { new Guid("ddce1676-0ffd-41fc-8b36-d0356e6e0e6f"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4087), null, null, false, "展馆2", 1 },
                    { new Guid("ea366433-74e2-4429-a702-fccfdc223ef4"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4089), null, null, false, "展馆4", 1 },
                    { new Guid("f9496255-e8ef-4d8e-a452-43a0664a0317"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4108), null, null, false, "展馆18", 1 },
                    { new Guid("fb5a986f-d93d-4ea8-8c76-00d17be67126"), 10m, new DateTime(2024, 1, 23, 15, 18, 53, 483, DateTimeKind.Local).AddTicks(4113), null, null, false, "展馆24", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_startTime_endTime_TUserId",
                table: "Ticket",
                columns: new[] { "startTime", "endTime", "TUserId" });
        }
    }
}
