using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddFileUrlToProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Project");
        }
    }
}
