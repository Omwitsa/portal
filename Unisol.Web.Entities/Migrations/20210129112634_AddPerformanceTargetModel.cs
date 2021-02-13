using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddPerformanceTargetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfomanceActivity");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "StaffPerformance",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PerformanceTarget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformanceSectionId = table.Column<int>(nullable: true),
                    PerformanceSessionId = table.Column<int>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    Indicator = table.Column<string>(nullable: true),
                    Achievement = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    SelfScore = table.Column<double>(nullable: true),
                    FinalScore = table.Column<double>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceTarget", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "StaffPerformance");

            migrationBuilder.CreateTable(
                name: "PerfomanceActivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Achievement = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    FinalScore = table.Column<double>(nullable: true),
                    Indicator = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PerformanceSectionId = table.Column<int>(nullable: true),
                    SelfScore = table.Column<double>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: true)
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
        }
    }
}
