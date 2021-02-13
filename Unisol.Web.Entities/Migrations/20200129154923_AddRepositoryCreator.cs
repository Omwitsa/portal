using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddRepositoryCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DocumentRepositoryFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DocumentRepository",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DocumentRepositoryFiles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DocumentRepository");
        }
    }
}
