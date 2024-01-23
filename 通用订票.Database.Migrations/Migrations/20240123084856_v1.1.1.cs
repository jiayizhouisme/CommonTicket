using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "id",
                table: "Order");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("02522d9d-8d5e-4c95-828f-b968e11773d3"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("03ea0dd6-ef4e-4d43-aede-1363af5238c1"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("121d3512-9d2d-4105-b32c-1c68581b2e76"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("1a63bb5a-a01e-4ba0-83f9-3a8dab2b5fb9"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("1afe5652-e789-40d9-be19-eddf9a029cb4"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("27f13de8-da4e-46f8-8231-09ce70126858"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("2ce30480-9e69-4689-ae7c-3586431775fe"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("35bf73db-c633-425a-98ed-b9de9231fef7"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("3b8ae92b-6aa2-45bf-ac37-357255e6cbef"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("3c64b8a4-2e14-4066-bab3-04c2d7298992"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("5b28f01b-9c08-4a91-8c63-66420e854f98"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("5b60749d-e6b5-412b-a5dc-9ae868b32dcb"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("78810c7d-1b68-4093-b36e-67f063da5667"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("78818101-7cc6-41be-95c5-d35add495709"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("8bd5f6e3-f551-483a-8749-544d2e43926b"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("930801e3-f155-4621-9fc7-2e31fdc717ba"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("9450312f-b714-49b7-80ec-f1a320e491c3"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("a479a1b3-4d3a-4f7f-a848-75a5ccc4725b"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("a4b76a29-bfe0-4ce3-9c5f-a2a0c4661141"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("ac1a14b8-a4c2-4e5f-b1e2-54622d66d55f"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("ae3fe0f2-26b5-4de5-8169-80a69bf0eac1"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("b7776a3f-83e5-44c4-8c31-1c8ee9d21ad0"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("ba7acc6a-acf8-4942-82c8-378de432f570"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("c3547a92-ed1c-4f11-92d0-24f6452f79af"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("d2d326cd-3606-4df3-a26c-5a8067bc4f90"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("d6c40fbb-e1b9-410d-8cdb-ca35f3cfda8f"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("e0e332d3-1193-46c0-971f-0ece48e2fb11"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("f13c0afb-4c38-4278-8964-932b15a9f3b9"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("f8329b39-84d8-43e5-8aec-f65bdf36298d"));

            migrationBuilder.DeleteData(
                table: "Exhibition",
                keyColumn: "id",
                keyValue: new Guid("f8cacbb5-d442-4fe8-8463-e3bfd8921d46"));

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "id", "basicPrice", "createTime", "description", "imgs", "isDeleted", "name", "status" },
                values: new object[,]
                {
                    { new Guid("07254981-fb4c-496b-a0d1-e86617b3465c"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6924), null, null, false, "展馆12", 1 },
                    { new Guid("0cf7b6d5-c478-4a04-ad37-16356f0771b7"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6931), null, null, false, "展馆15", 1 },
                    { new Guid("0f40502a-f924-4ac8-a2a8-15129a1a4e43"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6926), null, null, false, "展馆13", 1 },
                    { new Guid("1f687963-6f77-408f-b161-98d363059f77"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6943), null, null, false, "展馆21", 1 },
                    { new Guid("2342f3b7-523a-41ac-b86c-1e2cb40a978d"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6927), null, null, false, "展馆14", 1 },
                    { new Guid("2cec4c39-c2fa-483c-90b4-00f7d710faaf"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6941), null, null, false, "展馆20", 1 },
                    { new Guid("355b6ef7-44f4-46f9-a3fa-2064bb7da9e9"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6940), null, null, false, "展馆19", 1 },
                    { new Guid("386f0e6d-2fd4-4892-ba1b-aaf8b1799acb"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6919), null, null, false, "展馆9", 1 },
                    { new Guid("41205128-1d31-4ae5-8788-1ab2adde3bd2"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6896), null, null, false, "展馆2", 1 },
                    { new Guid("421be45c-68ca-47b2-8691-4922f95051b8"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6949), null, null, false, "展馆24", 1 },
                    { new Guid("490cf55e-6676-4186-9ef5-54700ed1461b"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6937), null, null, false, "展馆17", 1 },
                    { new Guid("4be2c2fe-beee-4384-a015-a17d9f158180"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6954), null, null, false, "展馆28", 1 },
                    { new Guid("56b3fae1-7813-4ccd-af51-440fdbd2b3cf"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6950), null, null, false, "展馆25", 1 },
                    { new Guid("5c6c0611-9f6d-45fe-a08c-a6270284d373"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6893), null, null, false, "展馆1", 1 },
                    { new Guid("7091ef70-feff-404b-96ee-57c5c1cc288a"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6903), null, null, false, "展馆5", 1 },
                    { new Guid("9005203d-1677-4774-a749-b52b68cf7d0d"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6922), null, null, false, "展馆11", 1 },
                    { new Guid("953ccf5d-155b-449e-bbce-8a19e4caa909"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6956), null, null, false, "展馆29", 1 },
                    { new Guid("96dfba80-9ee1-4c6d-962c-4d07fc91fa1a"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6948), null, null, false, "展馆23", 1 },
                    { new Guid("a4d6eb88-5b26-4985-b7da-55d5269556db"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6856), null, null, false, "展馆0", 1 },
                    { new Guid("a720f471-75c8-4e24-9f0d-7e46887043cf"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6921), null, null, false, "展馆10", 1 },
                    { new Guid("aec0835a-c09a-462c-b333-dd5e24df4f80"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6939), null, null, false, "展馆18", 1 },
                    { new Guid("b299425e-dad7-480d-988b-6999640a2b91"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6914), null, null, false, "展馆7", 1 },
                    { new Guid("b7739784-9688-43fc-bfb8-09097d17ec20"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6933), null, null, false, "展馆16", 1 },
                    { new Guid("b785b181-4a15-4d98-a12d-9af6d46d46ed"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6904), null, null, false, "展馆6", 1 },
                    { new Guid("bdbbf235-14c4-4680-b459-959bbdab628d"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6952), null, null, false, "展馆26", 1 },
                    { new Guid("bdcb79e8-56bf-4dd6-9a9b-1ddff7a1ee06"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6944), null, null, false, "展馆22", 1 },
                    { new Guid("d1e9bc60-cbfa-43b6-ab9c-e74bf739d81b"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6899), null, null, false, "展馆4", 1 },
                    { new Guid("f889862f-0320-4d0d-a71b-085d6a06f534"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6916), null, null, false, "展馆8", 1 },
                    { new Guid("fc4bf425-f575-4161-b222-f874500c72ee"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6897), null, null, false, "展馆3", 1 },
                    { new Guid("fcc5fefb-7381-4e25-9d97-f9a5ebd4147b"), 10m, new DateTime(2024, 1, 23, 16, 34, 5, 7, DateTimeKind.Local).AddTicks(6953), null, null, false, "展馆27", 1 }
                });
        }
    }
}
