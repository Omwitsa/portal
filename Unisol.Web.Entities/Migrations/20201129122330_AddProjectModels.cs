using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddProjectModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpNo = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    NeedApproval = table.Column<bool>(nullable: false),
                    FundingAgency = table.Column<string>(nullable: true),
                    Sponsor = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCoReseacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpNo = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCoReseacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCoReseacher_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDisbursement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstallmentNo = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDisbursement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDisbursement_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectReport_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCoReseacher_ProjectId",
                table: "ProjectCoReseacher",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDisbursement_ProjectId",
                table: "ProjectDisbursement",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReport_ProjectId",
                table: "ProjectReport",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCoReseacher");

            migrationBuilder.DropTable(
                name: "ProjectDisbursement");

            migrationBuilder.DropTable(
                name: "ProjectReport");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
