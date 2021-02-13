using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class addSurveyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "ClearanceSurveyResponse");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "ClearanceSurveyResponse");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "ClearanceSurveyResponse",
                newName: "Question");

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "ClearanceSurveyResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurveyName",
                table: "ClearanceSurveyResponse",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClearanceSurvey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TempleteName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceSurvey", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClearanceSurvey");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "ClearanceSurveyResponse");

            migrationBuilder.DropColumn(
                name: "SurveyName",
                table: "ClearanceSurveyResponse");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "ClearanceSurveyResponse",
                newName: "SurveyId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "ClearanceSurveyResponse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "ClearanceSurveyResponse",
                nullable: false,
                defaultValue: 0);
        }
    }
}
