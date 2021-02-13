using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class MakeLeaveRelieverMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsGenesis",
                table: "Settings",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LeaveRelieverMandatory",
                table: "Settings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveRelieverMandatory",
                table: "Settings");

            migrationBuilder.AlterColumn<bool>(
                name: "IsGenesis",
                table: "Settings",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
