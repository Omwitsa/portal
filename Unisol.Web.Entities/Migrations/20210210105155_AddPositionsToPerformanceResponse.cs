using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddPositionsToPerformanceResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "StaffPerformanceResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCat",
                table: "StaffPerformanceResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "StaffPerformanceResponse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "StaffPerformanceResponse");

            migrationBuilder.DropColumn(
                name: "JobCat",
                table: "StaffPerformanceResponse");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "StaffPerformanceResponse");
        }
    }
}
