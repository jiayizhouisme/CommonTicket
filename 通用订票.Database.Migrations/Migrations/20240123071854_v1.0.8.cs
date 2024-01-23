using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "id",
                table: "Ticket");
        }

        /// <inheritdoc />

    }
}
