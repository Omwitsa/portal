using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class PerformanceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffPerformance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPerformance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffPerformanceId = table.Column<int>(nullable: true),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceQuestionnaire_StaffPerformance_StaffPerformanceId",
                        column: x => x.StaffPerformanceId,
                        principalTable: "StaffPerformance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffPerformanceId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceSection_StaffPerformance_StaffPerformanceId",
                        column: x => x.StaffPerformanceId,
                        principalTable: "StaffPerformance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfomanceActivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformanceSectionId = table.Column<int>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    Indicator = table.Column<string>(nullable: true),
                    Achievement = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    SelfScore = table.Column<double>(nullable: true),
                    FinalScore = table.Column<double>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfomanceActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfomanceActivity_PerformanceSection_PerformanceSectionId",
                        column: x => x.PerformanceSectionId,
                        principalTable: "PerformanceSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfomanceActivity_PerformanceSectionId",
                table: "PerfomanceActivity",
                column: "PerformanceSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceQuestionnaire_StaffPerformanceId",
                table: "PerformanceQuestionnaire",
                column: "StaffPerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceSection_StaffPerformanceId",
                table: "PerformanceSection",
                column: "StaffPerformanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfomanceActivity");

            migrationBuilder.DropTable(
                name: "PerformanceQuestionnaire");

            migrationBuilder.DropTable(
                name: "PerformanceSection");

            migrationBuilder.DropTable(
                name: "StaffPerformance");
        }
    }
}
