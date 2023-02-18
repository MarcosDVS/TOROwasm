using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TORO.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Madres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMadre = table.Column<int>(type: "int", nullable: false),
                    IdHijo = table.Column<int>(type: "int", nullable: false),
                    ColorHijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexoHijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Madres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Padres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPadre = table.Column<int>(type: "int", nullable: false),
                    IdHijo = table.Column<int>(type: "int", nullable: false),
                    ColorHijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexoHijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Preñeses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVaca = table.Column<int>(type: "int", nullable: false),
                    RazaVaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdToro = table.Column<int>(type: "int", nullable: false),
                    RazaToro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetodoPreñes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PFP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preñeses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaProd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VacasProd = table.Column<int>(type: "int", nullable: false),
                    LitrosLeche = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bovinos",
                columns: table => new
                {
                    IdBovino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPadre = table.Column<int>(type: "int", nullable: true),
                    PadresID = table.Column<int>(type: "int", nullable: false),
                    IdMadre = table.Column<int>(type: "int", nullable: true),
                    MadresID = table.Column<int>(type: "int", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoNacer = table.Column<int>(type: "int", nullable: true),
                    Costo = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bovinos", x => x.IdBovino);
                    table.ForeignKey(
                        name: "FK_Bovinos_Madres_MadresID",
                        column: x => x.MadresID,
                        principalTable: "Madres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bovinos_Padres_PadresID",
                        column: x => x.PadresID,
                        principalTable: "Padres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bovinos_MadresID",
                table: "Bovinos",
                column: "MadresID");

            migrationBuilder.CreateIndex(
                name: "IX_Bovinos_PadresID",
                table: "Bovinos",
                column: "PadresID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bovinos");

            migrationBuilder.DropTable(
                name: "Preñeses");

            migrationBuilder.DropTable(
                name: "Producciones");

            migrationBuilder.DropTable(
                name: "Madres");

            migrationBuilder.DropTable(
                name: "Padres");
        }
    }
}
