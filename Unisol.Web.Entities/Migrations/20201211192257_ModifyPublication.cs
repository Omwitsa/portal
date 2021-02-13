using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class ModifyPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookISBN",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromPage",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalTitle",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicationPlace",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToPage",
                table: "Publication",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookISBN",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "FromPage",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "JournalTitle",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "PublicationPlace",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "ToPage",
                table: "Publication");
        }
    }
}
