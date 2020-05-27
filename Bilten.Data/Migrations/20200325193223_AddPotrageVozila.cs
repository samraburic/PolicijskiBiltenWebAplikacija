using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bilten.Data.Migrations
{
    public partial class AddPotrageVozila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PotrageVozila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPrijave = table.Column<DateTime>(nullable: false),
                    Prijavitelj = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true),
                    Zakljuceno = table.Column<bool>(nullable: true),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotrageVozila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotrageVozila_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PotrageVozila_VoziloId",
                table: "PotrageVozila",
                column: "VoziloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotrageVozila");
        }
    }
}
