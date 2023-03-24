using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TORO.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Father",
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
                    table.PrimaryKey("PK_Father", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mother",
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
                    table.PrimaryKey("PK_Mother", x => x.ID);
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
                name: "UsuariosRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermisoParaCrear = table.Column<bool>(type: "bit", nullable: false),
                    PermisoParaEditar = table.Column<bool>(type: "bit", nullable: false),
                    PermisoParaEliminar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bovinos",
                columns: table => new
                {
                    IdBovino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPadre = table.Column<int>(type: "int", nullable: true),
                    IdMadre = table.Column<int>(type: "int", nullable: true),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoNacer = table.Column<int>(type: "int", nullable: true),
                    Costo = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    padreID = table.Column<int>(type: "int", nullable: false),
                    MotherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bovinos", x => x.IdBovino);
                    table.ForeignKey(
                        name: "FK_bovinos_Father_padreID",
                        column: x => x.padreID,
                        principalTable: "Father",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bovinos_Mother_MotherID",
                        column: x => x.MotherID,
                        principalTable: "Mother",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_UsuariosRoles_UsuarioRolId",
                        column: x => x.UsuarioRolId,
                        principalTable: "UsuariosRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bovinos_MotherID",
                table: "bovinos",
                column: "MotherID");

            migrationBuilder.CreateIndex(
                name: "IX_bovinos_padreID",
                table: "bovinos",
                column: "padreID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioRolId",
                table: "Usuarios",
                column: "UsuarioRolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bovinos");

            migrationBuilder.DropTable(
                name: "Preñeses");

            migrationBuilder.DropTable(
                name: "Producciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Father");

            migrationBuilder.DropTable(
                name: "Mother");

            migrationBuilder.DropTable(
                name: "UsuariosRoles");
        }
    }
}
