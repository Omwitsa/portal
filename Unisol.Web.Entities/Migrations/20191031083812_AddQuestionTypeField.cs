using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddQuestionTypeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationQuestionOptions_EvaluationQuestions_EvaluationQuestionId",
                table: "EvaluationQuestionOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationQuestionResponses_EvaluationQuestions_EvaluationQuestionId",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationQuestionResponses_EvaluationQuestionId",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationQuestionOptions_EvaluationQuestionId",
                table: "EvaluationQuestionOptions");

            migrationBuilder.DropColumn(
                name: "AllowMultiple",
                table: "EvaluationQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionResponse",
                table: "EvaluationQuestions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EvaluationQuestions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "EvaluationQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "EvaluationQuestions");

            migrationBuilder.AddColumn<bool>(
                name: "AllowMultiple",
                table: "EvaluationQuestions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "QuestionResponse",
                table: "EvaluationQuestions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "EvaluationQuestions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestionResponses_EvaluationQuestionId",
                table: "EvaluationQuestionResponses",
                column: "EvaluationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestionOptions_EvaluationQuestionId",
                table: "EvaluationQuestionOptions",
                column: "EvaluationQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationQuestionOptions_EvaluationQuestions_EvaluationQuestionId",
                table: "EvaluationQuestionOptions",
                column: "EvaluationQuestionId",
                principalTable: "EvaluationQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationQuestionResponses_EvaluationQuestions_EvaluationQuestionId",
                table: "EvaluationQuestionResponses",
                column: "EvaluationQuestionId",
                principalTable: "EvaluationQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
