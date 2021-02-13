using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class PerformanceResponseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffPerformanceResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformanceSessionId = table.Column<int>(nullable: true),
                    EmpNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPerformanceResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceActivityResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformanceSectionId = table.Column<int>(nullable: true),
                    PerfomanceActivityId = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    SelfScore = table.Column<double>(nullable: true),
                    FinalScore = table.Column<double>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    StaffPerformanceResponseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceActivityResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceActivityResponse_StaffPerformanceResponse_StaffPerformanceResponseId",
                        column: x => x.StaffPerformanceResponseId,
                        principalTable: "StaffPerformanceResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceQuestionnaireResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformanceQuestionnaireId = table.Column<int>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    StaffPerformanceResponseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceQuestionnaireResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceQuestionnaireResponse_StaffPerformanceResponse_StaffPerformanceResponseId",
                        column: x => x.StaffPerformanceResponseId,
                        principalTable: "StaffPerformanceResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceActivityResponse_StaffPerformanceResponseId",
                table: "PerformanceActivityResponse",
                column: "StaffPerformanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceQuestionnaireResponse_StaffPerformanceResponseId",
                table: "PerformanceQuestionnaireResponse",
                column: "StaffPerformanceResponseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceActivityResponse");

            migrationBuilder.DropTable(
                name: "PerformanceQuestionnaireResponse");

            migrationBuilder.DropTable(
                name: "StaffPerformanceResponse");
        }
    }
}
