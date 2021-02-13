using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class ChangeStatusToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PerformanceTarget",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "PerformanceTarget",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
