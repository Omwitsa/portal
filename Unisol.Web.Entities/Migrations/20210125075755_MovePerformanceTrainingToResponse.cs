using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class MovePerformanceTrainingToResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceTraining_StaffPerformance_StaffPerformanceId",
                table: "PerformanceTraining");

            migrationBuilder.RenameColumn(
                name: "StaffPerformanceId",
                table: "PerformanceTraining",
                newName: "StaffPerformanceResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformanceTraining_StaffPerformanceId",
                table: "PerformanceTraining",
                newName: "IX_PerformanceTraining_StaffPerformanceResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceTraining_StaffPerformanceResponse_StaffPerformanceResponseId",
                table: "PerformanceTraining",
                column: "StaffPerformanceResponseId",
                principalTable: "StaffPerformanceResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceTraining_StaffPerformanceResponse_StaffPerformanceResponseId",
                table: "PerformanceTraining");

            migrationBuilder.RenameColumn(
                name: "StaffPerformanceResponseId",
                table: "PerformanceTraining",
                newName: "StaffPerformanceId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformanceTraining_StaffPerformanceResponseId",
                table: "PerformanceTraining",
                newName: "IX_PerformanceTraining_StaffPerformanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceTraining_StaffPerformance_StaffPerformanceId",
                table: "PerformanceTraining",
                column: "StaffPerformanceId",
                principalTable: "StaffPerformance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
