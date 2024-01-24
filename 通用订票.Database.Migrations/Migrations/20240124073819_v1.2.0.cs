using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_TUserId_startTime_endTime_stauts",
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

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TUserId_startTime_endTime_stauts",
                table: "Ticket",
                columns: new[] { "TUserId", "startTime", "endTime", "stauts" });
        }
    }
}
