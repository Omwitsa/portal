using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddSureveyResponseRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "ClearanceSurveyResponse");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "ClearanceSurveyResponse");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "ClearanceSurveyResponse");

            migrationBuilder.CreateTable(
                name: "ClearanceSurveyResponseRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionName = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    ClearanceSurveyResponseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceSurveyResponseRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClearanceSurveyResponseRef_ClearanceSurveyResponse_ClearanceSurveyResponseId",
                        column: x => x.ClearanceSurveyResponseId,
                        principalTable: "ClearanceSurveyResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceSurveyResponseRef_ClearanceSurveyResponseId",
                table: "ClearanceSurveyResponseRef",
                column: "ClearanceSurveyResponseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClearanceSurveyResponseRef");

            migrationBuilder.AddColumn<int>(
                name: "Question",
                table: "ClearanceSurveyResponse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "ClearanceSurveyResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "ClearanceSurveyResponse",
                nullable: true);
        }
    }
}
