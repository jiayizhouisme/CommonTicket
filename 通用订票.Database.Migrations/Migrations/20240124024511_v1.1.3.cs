using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v113 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_startTime_endTime_TUserId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TUserId_startTime_endTime",
                table: "Ticket",
                columns: new[] { "TUserId", "startTime", "endTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_TUserId_startTime_endTime",
                table: "Ticket");

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "id", "basicPrice", "createTime", "description", "imgs", "isDeleted", "name", "status" },
                values: new object[,]
                {
                    { new Guid("01ffea7d-ec6e-4845-abc4-5e42120ddfcf"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6609), null, null, false, "展馆6", 1 },
                    { new Guid("08e9b02a-658f-45e0-9a47-1edf5c9221e9"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6640), null, null, false, "展馆27", 1 },
                    { new Guid("0ba445fe-a39d-413d-80dd-f1ad3cc1ccfb"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6610), null, null, false, "展馆7", 1 },
                    { new Guid("0e7cddd1-67e8-4c42-87f9-9f65d7c3b509"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6630), null, null, false, "展馆19", 1 },
                    { new Guid("21271ca5-7a37-4b99-8867-4f2ab3a98d08"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6632), null, null, false, "展馆21", 1 },
                    { new Guid("27ebd34f-4ac5-4de0-a8a4-8d6feb3f4d97"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6614), null, null, false, "展馆8", 1 },
                    { new Guid("2ca493a0-7f72-4962-a33a-5957bdc940af"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6601), null, null, false, "展馆1", 1 },
                    { new Guid("4baa66e8-39e8-492b-8952-65833514670e"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6625), null, null, false, "展馆16", 1 },
                    { new Guid("4ea38eaf-ee6f-43ad-92ce-702337655017"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6622), null, null, false, "展馆14", 1 },
                    { new Guid("55fc6fcc-2cb7-4b5c-9328-9dced430112a"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6621), null, null, false, "展馆13", 1 },
                    { new Guid("57144819-40c7-463f-8618-a1f8ac8c96b7"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6616), null, null, false, "展馆9", 1 },
                    { new Guid("7ea98ca7-027d-41f3-91ca-8349505c61c0"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6606), null, null, false, "展馆4", 1 },
                    { new Guid("7ed9ee8d-efe9-4210-9e36-8b72737bacca"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6604), null, null, false, "展馆3", 1 },
                    { new Guid("86df789a-d76d-43e8-b02a-6d737b661495"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6627), null, null, false, "展馆17", 1 },
                    { new Guid("8e749e3a-d51c-45a0-ad0d-37808aadddb3"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6618), null, null, false, "展馆10", 1 },
                    { new Guid("91ae4874-dc99-4466-9623-636e3959defc"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6633), null, null, false, "展馆22", 1 },
                    { new Guid("92716418-36ef-47ee-8bf6-15df4228bf2f"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6641), null, null, false, "展馆28", 1 },
                    { new Guid("9a04b635-2fd3-4c3c-be7f-8f6b32ab704c"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6634), null, null, false, "展馆23", 1 },
                    { new Guid("9fa97daf-cf5f-4885-b56b-63824c95a978"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6619), null, null, false, "展馆11", 1 },
                    { new Guid("b5b2ce4c-95c6-4f8e-a7a1-b554b5d4e4db"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6642), null, null, false, "展馆29", 1 },
                    { new Guid("b7748f8e-f668-4d5d-b1da-9f551dc42c30"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6623), null, null, false, "展馆15", 1 },
                    { new Guid("b80f3432-aa48-4c69-abb1-63c7b00b9e1e"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6639), null, null, false, "展馆26", 1 },
                    { new Guid("c1008dee-b939-4bbc-a1aa-50824d222bfc"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6620), null, null, false, "展馆12", 1 },
                    { new Guid("c2ca87c0-c0cc-4cd1-ae6f-754c793994d5"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6580), null, null, false, "展馆0", 1 },
                    { new Guid("c6024730-7f2a-4e88-95b1-f09625acb6ce"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6631), null, null, false, "展馆20", 1 },
                    { new Guid("da634b2e-77de-4f36-a145-e5e261dfe29b"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6638), null, null, false, "展馆25", 1 },
                    { new Guid("daa7b5a5-fb14-4ca4-b565-a12a8e2f797b"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6608), null, null, false, "展馆5", 1 },
                    { new Guid("e35bfbc0-a008-4c20-8255-c2256443b146"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6636), null, null, false, "展馆24", 1 },
                    { new Guid("e7345154-7d34-40d8-bccc-5c7dbb03413e"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6603), null, null, false, "展馆2", 1 },
                    { new Guid("f83d57c0-3fb9-4c1b-aa10-bdf24a1f59d4"), 10m, new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6629), null, null, false, "展馆18", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_startTime_endTime_TUserId",
                table: "Ticket",
                columns: new[] { "startTime", "endTime", "TUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TUserId",
                table: "Ticket",
                column: "TUserId");
        }
    }
}
