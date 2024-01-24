using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_startTime_endTime_TUserId_objectId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_objectId",
                table: "Ticket",
                column: "objectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_startTime_endTime_TUserId",
                table: "Ticket",
                columns: new[] { "startTime", "endTime", "TUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_objectId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_startTime_endTime_TUserId",
                table: "Ticket");

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("01ffea7d-ec6e-4845-abc4-5e42120ddfcf"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("08e9b02a-658f-45e0-9a47-1edf5c9221e9"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("0ba445fe-a39d-413d-80dd-f1ad3cc1ccfb"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("0e7cddd1-67e8-4c42-87f9-9f65d7c3b509"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("21271ca5-7a37-4b99-8867-4f2ab3a98d08"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("27ebd34f-4ac5-4de0-a8a4-8d6feb3f4d97"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("2ca493a0-7f72-4962-a33a-5957bdc940af"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("4baa66e8-39e8-492b-8952-65833514670e"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("4ea38eaf-ee6f-43ad-92ce-702337655017"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("55fc6fcc-2cb7-4b5c-9328-9dced430112a"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("57144819-40c7-463f-8618-a1f8ac8c96b7"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("7ea98ca7-027d-41f3-91ca-8349505c61c0"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("7ed9ee8d-efe9-4210-9e36-8b72737bacca"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("86df789a-d76d-43e8-b02a-6d737b661495"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("8e749e3a-d51c-45a0-ad0d-37808aadddb3"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("91ae4874-dc99-4466-9623-636e3959defc"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("92716418-36ef-47ee-8bf6-15df4228bf2f"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("9a04b635-2fd3-4c3c-be7f-8f6b32ab704c"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("9fa97daf-cf5f-4885-b56b-63824c95a978"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b5b2ce4c-95c6-4f8e-a7a1-b554b5d4e4db"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b7748f8e-f668-4d5d-b1da-9f551dc42c30"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b80f3432-aa48-4c69-abb1-63c7b00b9e1e"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("c1008dee-b939-4bbc-a1aa-50824d222bfc"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("c2ca87c0-c0cc-4cd1-ae6f-754c793994d5"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("c6024730-7f2a-4e88-95b1-f09625acb6ce"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("da634b2e-77de-4f36-a145-e5e261dfe29b"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("daa7b5a5-fb14-4ca4-b565-a12a8e2f797b"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("e35bfbc0-a008-4c20-8255-c2256443b146"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("e7345154-7d34-40d8-bccc-5c7dbb03413e"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("f83d57c0-3fb9-4c1b-aa10-bdf24a1f59d4"));

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "id", "basicPrice", "createTime", "description", "imgs", "isDeleted", "name", "status" },
                values: new object[,]
                {
                    { new Guid("02522d9d-8d5e-4c95-828f-b968e11773d3"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2930), null, null, false, "展馆1", 1 },
                    { new Guid("03ea0dd6-ef4e-4d43-aede-1363af5238c1"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2909), null, null, false, "展馆0", 1 },
                    { new Guid("121d3512-9d2d-4105-b32c-1c68581b2e76"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2946), null, null, false, "展馆6", 1 },
                    { new Guid("1a63bb5a-a01e-4ba0-83f9-3a8dab2b5fb9"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2948), null, null, false, "展馆8", 1 },
                    { new Guid("1afe5652-e789-40d9-be19-eddf9a029cb4"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2952), null, null, false, "展馆10", 1 },
                    { new Guid("27f13de8-da4e-46f8-8231-09ce70126858"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2945), null, null, false, "展馆5", 1 },
                    { new Guid("2ce30480-9e69-4689-ae7c-3586431775fe"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2931), null, null, false, "展馆2", 1 },
                    { new Guid("35bf73db-c633-425a-98ed-b9de9231fef7"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2960), null, null, false, "展馆15", 1 },
                    { new Guid("3b8ae92b-6aa2-45bf-ac37-357255e6cbef"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2959), null, null, false, "展馆14", 1 },
                    { new Guid("3c64b8a4-2e14-4066-bab3-04c2d7298992"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2970), null, null, false, "展馆22", 1 },
                    { new Guid("5b28f01b-9c08-4a91-8c63-66420e854f98"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2969), null, null, false, "展馆21", 1 },
                    { new Guid("5b60749d-e6b5-412b-a5dc-9ae868b32dcb"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2979), null, null, false, "展馆29", 1 },
                    { new Guid("78810c7d-1b68-4093-b36e-67f063da5667"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2954), null, null, false, "展馆12", 1 },
                    { new Guid("78818101-7cc6-41be-95c5-d35add495709"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2973), null, null, false, "展馆25", 1 },
                    { new Guid("8bd5f6e3-f551-483a-8749-544d2e43926b"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2963), null, null, false, "展馆17", 1 },
                    { new Guid("930801e3-f155-4621-9fc7-2e31fdc717ba"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2964), null, null, false, "展馆18", 1 },
                    { new Guid("9450312f-b714-49b7-80ec-f1a320e491c3"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2961), null, null, false, "展馆16", 1 },
                    { new Guid("a479a1b3-4d3a-4f7f-a848-75a5ccc4725b"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2947), null, null, false, "展馆7", 1 },
                    { new Guid("a4b76a29-bfe0-4ce3-9c5f-a2a0c4661141"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2953), null, null, false, "展馆11", 1 },
                    { new Guid("ac1a14b8-a4c2-4e5f-b1e2-54622d66d55f"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2957), null, null, false, "展馆13", 1 },
                    { new Guid("ae3fe0f2-26b5-4de5-8169-80a69bf0eac1"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2950), null, null, false, "展馆9", 1 },
                    { new Guid("b7776a3f-83e5-44c4-8c31-1c8ee9d21ad0"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2934), null, null, false, "展馆4", 1 },
                    { new Guid("ba7acc6a-acf8-4942-82c8-378de432f570"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2966), null, null, false, "展馆20", 1 },
                    { new Guid("c3547a92-ed1c-4f11-92d0-24f6452f79af"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2972), null, null, false, "展馆24", 1 },
                    { new Guid("d2d326cd-3606-4df3-a26c-5a8067bc4f90"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2977), null, null, false, "展馆28", 1 },
                    { new Guid("d6c40fbb-e1b9-410d-8cdb-ca35f3cfda8f"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2971), null, null, false, "展馆23", 1 },
                    { new Guid("e0e332d3-1193-46c0-971f-0ece48e2fb11"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2975), null, null, false, "展馆27", 1 },
                    { new Guid("f13c0afb-4c38-4278-8964-932b15a9f3b9"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2933), null, null, false, "展馆3", 1 },
                    { new Guid("f8329b39-84d8-43e5-8aec-f65bdf36298d"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2974), null, null, false, "展馆26", 1 },
                    { new Guid("f8cacbb5-d442-4fe8-8463-e3bfd8921d46"), 10m, new DateTime(2024, 1, 23, 16, 48, 56, 61, DateTimeKind.Local).AddTicks(2965), null, null, false, "展馆19", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_startTime_endTime_TUserId_objectId",
                table: "Ticket",
                columns: new[] { "startTime", "endTime", "TUserId", "objectId" });
        }
    }
}
