using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("43751d17-e26b-4e1e-ab25-2673b39df3fc"),
                column: "CreateTime",
                value: new DateTime(2024, 1, 23, 14, 29, 34, 751, DateTimeKind.Local).AddTicks(5177));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("43751d17-e26b-4e1e-ab25-2673b39df3fc"),
                column: "CreateTime",
                value: new DateTime(2024, 1, 23, 14, 28, 45, 864, DateTimeKind.Local).AddTicks(9368));
        }
    }
}
