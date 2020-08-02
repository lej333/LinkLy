using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class Domain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "domain",
                table: "Links",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "domain",
                table: "Links");
        }
    }
}
