using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_ID",
                table: "Links",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Links_user_ID",
                table: "Links",
                column: "user_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_AspNetUsers_user_ID",
                table: "Links",
                column: "user_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_AspNetUsers_user_ID",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_user_ID",
                table: "Links");

            migrationBuilder.AlterColumn<string>(
                name: "user_ID",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
