using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddFieldToEvaluationResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicYear",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Campus",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertType",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LecturerName",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Programme",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Schools",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "EvaluationQuestionResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearOfStudy",
                table: "EvaluationQuestionResponses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "Campus",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "CertType",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "LecturerName",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "Programme",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "Schools",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "EvaluationQuestionResponses");

            migrationBuilder.DropColumn(
                name: "YearOfStudy",
                table: "EvaluationQuestionResponses");
        }
    }
}
