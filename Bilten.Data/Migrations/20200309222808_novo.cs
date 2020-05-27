using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bilten.Data.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Boja",
                table: "Vozila",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmisioniStandard",
                table: "Vozila",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GodinaProizvodnje",
                table: "Vozila",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gorivo",
                table: "Vozila",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kubikaza",
                table: "Vozila",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipVozila",
                table: "Vozila",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "kWSnaga",
                table: "Vozila",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ksSnaga",
                table: "Vozila",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boja",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "EmisioniStandard",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "GodinaProizvodnje",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "Gorivo",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "Kubikaza",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "TipVozila",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "kWSnaga",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "ksSnaga",
                table: "Vozila");
        }
    }
}
