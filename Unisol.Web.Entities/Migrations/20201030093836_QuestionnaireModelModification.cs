using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class QuestionnaireModelModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "ClearanceQuestion");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ClearanceQuestion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ClearanceQuestion");

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "ClearanceQuestion",
                nullable: true);
        }
    }
}
