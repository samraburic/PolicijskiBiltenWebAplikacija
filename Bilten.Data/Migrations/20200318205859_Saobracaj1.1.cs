using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bilten.Data.Migrations
{
    public partial class Saobracaj11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaobracajDetalji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DogadjajId = table.Column<int>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaobracajDetalji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaobracajDetalji_Dogadjaj_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SaobracajDetalji_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VozilaSlike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VoziloId = table.Column<int>(nullable: false),
                    SlikaPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VozilaSlike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VozilaSlike_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaobracajDetalji_DogadjajId",
                table: "SaobracajDetalji",
                column: "DogadjajId");

            migrationBuilder.CreateIndex(
                name: "IX_SaobracajDetalji_VoziloId",
                table: "SaobracajDetalji",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_VozilaSlike_VoziloId",
                table: "VozilaSlike",
                column: "VoziloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaobracajDetalji");

            migrationBuilder.DropTable(
                name: "VozilaSlike");
        }
    }
}
