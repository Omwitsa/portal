using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddCampusSchoolFieldToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Campus",
                table: "PortalEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "PortalEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "PortalEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearOfStudy",
                table: "PortalEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Campus",
                table: "PortalEvents");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "PortalEvents");

            migrationBuilder.DropColumn(
                name: "School",
                table: "PortalEvents");

            migrationBuilder.DropColumn(
                name: "YearOfStudy",
                table: "PortalEvents");
        }
    }
}
