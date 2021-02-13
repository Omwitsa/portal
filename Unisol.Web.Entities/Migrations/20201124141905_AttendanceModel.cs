using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AttendanceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpNo = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Device = table.Column<string>(nullable: true),
                    DeviceNo = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAttendance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeAttendance");
        }
    }
}
