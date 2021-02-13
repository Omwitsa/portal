using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class ComplaintModelModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Complaint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionDate",
                table: "Complaint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "Complaint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hostel",
                table: "Complaint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Complaint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Complaint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "ActionDate",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "Hostel",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Complaint");
        }
    }
}
