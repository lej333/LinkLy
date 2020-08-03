using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class lastclicknull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_ID1",
                table: "Domains",
                type: "int",
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
    }
}
