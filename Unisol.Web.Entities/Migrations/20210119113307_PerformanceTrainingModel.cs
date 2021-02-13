using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class PerformanceTrainingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerformanceTraining",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffPerformanceId = table.Column<int>(nullable: true),
                    Training = table.Column<string>(nullable: true),
                    Objectives = table.Column<string>(nullable: true),
                    Results = table.Column<string>(nullable: true),
                    Recommendations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceTraining_StaffPerformance_StaffPerformanceId",
                        column: x => x.StaffPerformanceId,
                        principalTable: "StaffPerformance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceTraining_StaffPerformanceId",
                table: "PerformanceTraining",
                column: "StaffPerformanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceTraining");
        }
    }
}
