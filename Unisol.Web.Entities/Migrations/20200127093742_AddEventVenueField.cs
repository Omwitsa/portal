using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddEventVenueField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventVenue",
                table: "PortalEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Idno",
                table: "HrEmployees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventVenue",
                table: "PortalEvents");

            migrationBuilder.DropColumn(
                name: "Idno",
                table: "HrEmployees");
        }
    }
}
