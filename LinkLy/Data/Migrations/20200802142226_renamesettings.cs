using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class renamesettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    setting_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    domains = table.Column<string>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    user_ID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.setting_ID);
                    table.ForeignKey(
                        name: "FK_UserSettings_AspNetUsers_user_ID",
                        column: x => x.user_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_user_ID",
                table: "UserSettings",
                column: "user_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    setting_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    domains = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.setting_ID);
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_user_ID",
                        column: x => x.user_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_user_ID",
                table: "Settings",
                column: "user_ID");
        }
    }
}
