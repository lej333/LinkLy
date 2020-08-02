using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class domains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_AspNetUsers_user_ID",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_AspNetUsers_user_ID",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "domains",
                table: "UserSettings");

            migrationBuilder.AlterColumn<string>(
                name: "user_ID",
                table: "UserSettings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "user_ID",
                table: "Links",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    domain_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    domain_name = table.Column<string>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    user_ID = table.Column<string>(nullable: true),
                    UserSettingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.domain_ID);
                    table.ForeignKey(
                        name: "FK_Domains_AspNetUsers_user_ID",
                        column: x => x.user_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Domains_UserSettings_UserSettingId",
                        column: x => x.UserSettingId,
                        principalTable: "UserSettings",
                        principalColumn: "usersetting_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domains_user_ID",
                table: "Domains",
                column: "user_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_UserSettingId",
                table: "Domains",
                column: "UserSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_AspNetUsers_user_ID",
                table: "Links",
                column: "user_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_AspNetUsers_user_ID",
                table: "UserSettings",
                column: "user_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_AspNetUsers_user_ID",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_AspNetUsers_user_ID",
                table: "UserSettings");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.AlterColumn<string>(
                name: "user_ID",
                table: "UserSettings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "domains",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_ID",
                table: "Links",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_AspNetUsers_user_ID",
                table: "Links",
                column: "user_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_AspNetUsers_user_ID",
                table: "UserSettings",
                column: "user_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
