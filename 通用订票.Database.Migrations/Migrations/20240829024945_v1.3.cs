using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "WechatMerchantConfig",
               columns: table => new
               {
                   appid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   mchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   apiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   apiv3Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   RsaPublicKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_WechatMerchantConfig", x => x.appid);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
