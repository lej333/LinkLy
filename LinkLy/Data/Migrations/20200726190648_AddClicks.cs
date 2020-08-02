using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class AddClicks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    link_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link_name = table.Column<string>(maxLength: 255, nullable: false),
                    link_uri = table.Column<string>(nullable: false),
                    total_clicks = table.Column<int>(nullable: false),
                    last_click = table.Column<DateTime>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    user_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.link_ID);
                });

            migrationBuilder.CreateTable(
                name: "Clicks",
                columns: table => new
                {
                    click_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link_ID = table.Column<int>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false),
                    creation_ipnumber = table.Column<string>(nullable: false),
                    browser_name = table.Column<string>(nullable: true),
                    browser_version = table.Column<string>(nullable: true),
                    os_name = table.Column<string>(nullable: true),
                    device_type = table.Column<string>(nullable: true),
                    country_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clicks", x => x.click_ID);
                    table.ForeignKey(
                        name: "FK_Clicks_Links_link_ID",
                        column: x => x.link_ID,
                        principalTable: "Links",
                        principalColumn: "link_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clicks_link_ID",
                table: "Clicks",
                column: "link_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clicks");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
