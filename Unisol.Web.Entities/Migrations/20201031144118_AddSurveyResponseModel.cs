using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddSurveyResponseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClearanceSurveyResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Admnno = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceSurveyResponse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClearanceSurveyResponse");
        }
    }
}
