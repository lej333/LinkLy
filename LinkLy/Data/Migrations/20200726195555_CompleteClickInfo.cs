using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkLy.Data.Migrations
{
    public partial class CompleteClickInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country_name",
                table: "Clicks");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Clicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Clicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "host_name",
                table: "Clicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Clicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "organisation",
                table: "Clicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "postal",
                table: "Clicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "region",
                table: "Clicks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "host_name",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "organisation",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "postal",
                table: "Clicks");

            migrationBuilder.DropColumn(
                name: "region",
                table: "Clicks");

            migrationBuilder.AddColumn<string>(
                name: "country_name",
                table: "Clicks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
