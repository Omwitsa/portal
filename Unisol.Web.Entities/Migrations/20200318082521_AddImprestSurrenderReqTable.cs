using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddImprestSurrenderReqTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImprestSurrenderReqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImpRef = table.Column<string>(nullable: true),
                    PayeeRef = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    SurReqDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImprestSurrenderReqs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImprestSurrenderReqs");
        }
    }
}
