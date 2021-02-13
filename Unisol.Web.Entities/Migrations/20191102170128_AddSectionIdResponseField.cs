using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddSectionIdResponseField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationQuestionResponseOptions_EvaluationQuestionResponses_EvaluationQuestionResponseId",
                table: "EvaluationQuestionResponseOptions");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationQuestionResponseOptions_EvaluationQuestionResponseId",
                table: "EvaluationQuestionResponseOptions");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationSectionId",
                table: "EvaluationQuestionResponses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluationSectionId",
                table: "EvaluationQuestionResponses");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestionResponseOptions_EvaluationQuestionResponseId",
                table: "EvaluationQuestionResponseOptions",
                column: "EvaluationQuestionResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationQuestionResponseOptions_EvaluationQuestionResponses_EvaluationQuestionResponseId",
                table: "EvaluationQuestionResponseOptions",
                column: "EvaluationQuestionResponseId",
                principalTable: "EvaluationQuestionResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
