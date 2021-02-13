using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class ClearaceQuestinnaireTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClearanceQuestionnaireTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceQuestionnaireTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClearanceQuestionSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<string>(nullable: true),
                    ClearanceQuestionnaireTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceQuestionSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClearanceQuestionSection_ClearanceQuestionnaireTemplate_ClearanceQuestionnaireTemplateId",
                        column: x => x.ClearanceQuestionnaireTemplateId,
                        principalTable: "ClearanceQuestionnaireTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClearanceQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    QuestionType = table.Column<int>(nullable: true),
                    ClearanceQuestionSectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClearanceQuestion_ClearanceQuestionSection_ClearanceQuestionSectionId",
                        column: x => x.ClearanceQuestionSectionId,
                        principalTable: "ClearanceQuestionSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceQuestion_ClearanceQuestionSectionId",
                table: "ClearanceQuestion",
                column: "ClearanceQuestionSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceQuestionSection_ClearanceQuestionnaireTemplateId",
                table: "ClearanceQuestionSection",
                column: "ClearanceQuestionnaireTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClearanceQuestion");

            migrationBuilder.DropTable(
                name: "ClearanceQuestionSection");

            migrationBuilder.DropTable(
                name: "ClearanceQuestionnaireTemplate");
        }
    }
}
