using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class AddTrashAndDeleteEnablingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "PortalMessage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ReceiverDelete",
                table: "PortalMessage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiverTrash",
                table: "PortalMessage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenderDelete",
                table: "PortalMessage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenderTrash",
                table: "PortalMessage",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "PortalMessage");

            migrationBuilder.DropColumn(
                name: "ReceiverDelete",
                table: "PortalMessage");

            migrationBuilder.DropColumn(
                name: "ReceiverTrash",
                table: "PortalMessage");

            migrationBuilder.DropColumn(
                name: "SenderDelete",
                table: "PortalMessage");

            migrationBuilder.DropColumn(
                name: "SenderTrash",
                table: "PortalMessage");
        }
    }
}
