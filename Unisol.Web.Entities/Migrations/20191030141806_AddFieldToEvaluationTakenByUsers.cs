using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddFieldToEvaluationTakenByUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AcademicYear",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Campus",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertType",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LecturerName",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Programme",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Schools",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearOfStudy",
                table: "EvaluationTakenUnitWiseByUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "Campus",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "CertType",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "LecturerName",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "Programme",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "Schools",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropColumn(
                name: "YearOfStudy",
                table: "EvaluationTakenUnitWiseByUsers");

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
    }
}
