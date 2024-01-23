using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "CreateTime", "authLevel", "isDeleted", "password", "username" },
                values: new object[] { new Guid("43751d17-e26b-4e1e-ab25-2673b39df3fc"), new DateTime(2024, 1, 23, 14, 28, 45, 864, DateTimeKind.Local).AddTicks(9368), 1, false, "afdd0b4ad2ec172c586e2150770fbf9e", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("43751d17-e26b-4e1e-ab25-2673b39df3fc"));
        }
    }
}
