using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class foreignkeydomains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_UserSettings_UserSettingId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_UserSettingId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "UserSettingId",
                table: "Domains");

            migrationBuilder.AddColumn<int>(
                name: "user_ID1",
                table: "Domains",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Domains_user_ID1",
                table: "Domains",
                column: "user_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_UserSettings_user_ID1",
                table: "Domains",
                column: "user_ID1",
                principalTable: "UserSettings",
                principalColumn: "usersetting_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_UserSettings_user_ID1",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_user_ID1",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "user_ID1",
                table: "Domains");

            migrationBuilder.AddColumn<int>(
                name: "UserSettingId",
                table: "Domains",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Domains_UserSettingId",
                table: "Domains",
                column: "UserSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_UserSettings_UserSettingId",
                table: "Domains",
                column: "UserSettingId",
                principalTable: "UserSettings",
                principalColumn: "usersetting_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
