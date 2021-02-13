using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddSupervisorToTargets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supervisor",
                table: "PerformanceTarget",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "Supervisor",
                table: "PerformanceTarget");
        }
    }
}
