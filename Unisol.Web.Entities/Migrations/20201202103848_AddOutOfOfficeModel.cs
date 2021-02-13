using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddOutOfOfficeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PunchMethods",
                table: "MissedPunch");

            migrationBuilder.CreateTable(
                name: "OutOfOffice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpNo = table.Column<string>(nullable: true),
                    Supervisor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutOfOffice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutOfOffice");

            migrationBuilder.AddColumn<int>(
                name: "PunchMethods",
                table: "MissedPunch",
                nullable: false,
                defaultValue: 0);
        }
    }
}
