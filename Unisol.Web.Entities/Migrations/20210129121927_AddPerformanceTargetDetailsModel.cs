using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddPerformanceTargetDetailsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achievement",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "Activity",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "FinalScore",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "Indicator",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "PerformanceSectionId",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "SelfScore",
                table: "PerformanceTarget");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "PerformanceTarget");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "PerformanceTarget",
                newName: "EmpNo");

            migrationBuilder.CreateTable(
                name: "PerformanceTargetDetail",
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
                    Notes = table.Column<string>(nullable: true),
                    PerformanceTargetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceTargetDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceTargetDetail_PerformanceTarget_PerformanceTargetId",
                        column: x => x.PerformanceTargetId,
                        principalTable: "PerformanceTarget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceTargetDetail_PerformanceTargetId",
                table: "PerformanceTargetDetail",
                column: "PerformanceTargetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceTargetDetail");

            migrationBuilder.RenameColumn(
                name: "EmpNo",
                table: "PerformanceTarget",
                newName: "Target");

            migrationBuilder.AddColumn<string>(
                name: "Achievement",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FinalScore",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indicator",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerformanceSectionId",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SelfScore",
                table: "PerformanceTarget",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "PerformanceTarget",
                nullable: true);
        }
    }
}
