using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "Exhibition",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "id", "basicPrice", "createTime", "description", "imgs", "isDeleted", "name", "status" },
                values: new object[,]
                {
                    { new Guid("0057133f-c267-4ff9-bab2-9a7abe240fea"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9213), null, null, false, "展馆7", 1 },
                    { new Guid("05404c19-8e46-4b19-b896-1d96b3a88421"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9207), null, null, false, "展馆3", 1 },
                    { new Guid("100ef993-829c-4a41-9aa2-75057784a1e5"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9272), null, null, false, "展馆25", 1 },
                    { new Guid("2ea9e21f-0684-43e7-9630-debf6b7382f9"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9228), null, null, false, "展馆16", 1 },
                    { new Guid("33d09127-6044-4b40-a394-9968d7e132c4"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9189), null, null, false, "展馆0", 1 },
                    { new Guid("45687701-d996-44b6-9df6-d5cfe4d7a729"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9218), null, null, false, "展馆9", 1 },
                    { new Guid("46cf3f5d-9037-49fb-8c3c-8a9c06076d05"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9233), null, null, false, "展馆20", 1 },
                    { new Guid("4fe2ba53-7f55-4ab9-9444-1b6c12f4d954"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9271), null, null, false, "展馆24", 1 },
                    { new Guid("53ba1115-40c7-4323-9f36-37265ca6b9bc"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9217), null, null, false, "展馆8", 1 },
                    { new Guid("54b6d460-9169-4729-9d66-9b0e3899cc82"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9230), null, null, false, "展馆17", 1 },
                    { new Guid("737716ee-d000-472b-bdb7-2e9fc29f19a2"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9224), null, null, false, "展馆14", 1 },
                    { new Guid("754b2502-db47-49dd-b108-da96e49cad14"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9212), null, null, false, "展馆6", 1 },
                    { new Guid("774643d8-ad21-4edc-b5fe-cb598558be54"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9220), null, null, false, "展馆10", 1 },
                    { new Guid("874b3cdf-bf8a-4963-bffe-fb2300e929fa"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9268), null, null, false, "展馆23", 1 },
                    { new Guid("a89f6614-4b24-47a4-a507-1e89c55bc3ce"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9231), null, null, false, "展馆18", 1 },
                    { new Guid("ad42985a-ec3f-4b64-a180-b613cf03bc87"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9276), null, null, false, "展馆29", 1 },
                    { new Guid("af5588be-c4ce-426b-bd99-0475a166f62d"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9274), null, null, false, "展馆27", 1 },
                    { new Guid("b60eacd1-6502-4a5f-b8ab-bc772bb157c5"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9225), null, null, false, "展馆15", 1 },
                    { new Guid("b8f5edc6-2c74-4590-9a84-958cc3e29de5"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9232), null, null, false, "展馆19", 1 },
                    { new Guid("b9c13f32-564d-4210-8d1b-14478c78a365"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9222), null, null, false, "展馆12", 1 },
                    { new Guid("bca2aedd-8a27-4cb3-a5d7-4107d1a30fd4"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9273), null, null, false, "展馆26", 1 },
                    { new Guid("c03afb6c-9dda-492f-87f0-de11cb730bdc"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9206), null, null, false, "展馆2", 1 },
                    { new Guid("d139f7fc-4c31-416b-a7a0-4b74fa833048"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9221), null, null, false, "展馆11", 1 },
                    { new Guid("d1e53726-d01a-4bea-827a-79ead0780087"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9223), null, null, false, "展馆13", 1 },
                    { new Guid("d49baf0e-f684-4e54-89ac-d73c2126c40b"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9208), null, null, false, "展馆4", 1 },
                    { new Guid("d5ca8766-10c5-42d4-a924-706f4dc6b593"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9266), null, null, false, "展馆21", 1 },
                    { new Guid("d772c8d4-0cc9-40c1-ad8d-8376911dcfca"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9204), null, null, false, "展馆1", 1 },
                    { new Guid("de2b039b-3716-4c5c-9b4e-27fc843a1938"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9275), null, null, false, "展馆28", 1 },
                    { new Guid("eb9f704d-4c32-461d-9a59-f74017bbc2a6"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9267), null, null, false, "展馆22", 1 },
                    { new Guid("ef0c1c37-2da2-4644-a684-269e244aef9f"), 10m, new DateTime(2024, 1, 23, 14, 56, 48, 572, DateTimeKind.Local).AddTicks(9211), null, null, false, "展馆5", 1 }
                });
        }

        /// <inheritdoc />
  
    }
}
