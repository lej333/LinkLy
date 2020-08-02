using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class newrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clicks_Links_link_ID1",
                table: "Clicks");

            migrationBuilder.DropIndex(
                name: "IX_Clicks_link_ID1",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "link_ID1",
                table: "Clicks");

            migrationBuilder.CreateIndex(
                name: "IX_Clicks_link_ID",
                table: "Clicks",
                column: "link_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clicks_Links_link_ID",
                table: "Clicks",
                column: "link_ID",
                principalTable: "Links",
                principalColumn: "link_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clicks_Links_link_ID",
                table: "Clicks");

            migrationBuilder.DropIndex(
                name: "IX_Clicks_link_ID",
                table: "Clicks");

            migrationBuilder.AddColumn<int>(
                name: "link_ID1",
                table: "Clicks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clicks_link_ID1",
                table: "Clicks",
                column: "link_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clicks_Links_link_ID1",
                table: "Clicks",
                column: "link_ID1",
                principalTable: "Links",
                principalColumn: "link_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
