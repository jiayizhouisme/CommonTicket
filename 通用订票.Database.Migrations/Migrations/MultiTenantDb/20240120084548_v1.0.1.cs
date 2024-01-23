using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations.MultiTenantDb
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Host = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Schema = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ConnectionString = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "TenantId", "ConnectionString", "CreatedTime", "EmailAddress", "Host", "Name", "PhoneNumber", "Schema" },
                values: new object[,]
                {
                    { new Guid("383afb88-f519-fff8-b364-6d563bf3687f"), "Data Source=localhost;Initial Catalog=Common;user id=admin;password=Aa123456;TrustServerCertificate=true;Max Pool Size=64; Min Pool Size=5", new DateTimeOffset(new DateTime(2020, 10, 6, 20, 19, 7, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, "localhost:44313", "默认租户", null, null },
                    { new Guid("c5798cb6-16d6-0f42-eb56-59c695353bc0"), null, new DateTimeOffset(new DateTime(2020, 10, 6, 20, 20, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, "localhost:5000", "其他租户", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
