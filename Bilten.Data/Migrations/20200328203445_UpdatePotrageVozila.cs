using Microsoft.EntityFrameworkCore.Migrations;

namespace Bilten.Data.Migrations
{
    public partial class UpdatePotrageVozila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zakljuceno",
                table: "PotrageVozila",
                newName: "Obustavljena");

            migrationBuilder.AddColumn<bool>(
                name: "Aktivna",
                table: "PotrageVozila",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "PotrageVozila",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktivna",
                table: "PotrageVozila");

            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "PotrageVozila");

            migrationBuilder.RenameColumn(
                name: "Obustavljena",
                table: "PotrageVozila",
                newName: "Zakljuceno");
        }
    }
}
