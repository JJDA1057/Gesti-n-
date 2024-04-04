using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investigaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investigadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Afiliacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    investigacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Investigaciones_investigacionId",
                        column: x => x.investigacionId,
                        principalTable: "Investigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Autores = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvestigacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Investigaciones_InvestigacionId",
                        column: x => x.InvestigacionId,
                        principalTable: "Investigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestigacionInvestigador",
                columns: table => new
                {
                    InvestigacionesAsignadasId = table.Column<int>(type: "int", nullable: false),
                    InvestigadoresAsignadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigacionInvestigador", x => new { x.InvestigacionesAsignadasId, x.InvestigadoresAsignadosId });
                    table.ForeignKey(
                        name: "FK_InvestigacionInvestigador_Investigaciones_InvestigacionesAsignadasId",
                        column: x => x.InvestigacionesAsignadasId,
                        principalTable: "Investigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestigacionInvestigador_Investigadores_InvestigadoresAsignadosId",
                        column: x => x.InvestigadoresAsignadosId,
                        principalTable: "Investigadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecursosEspe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadRequerida = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActividadadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosEspe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursosEspe_Actividades_ActividadadId",
                        column: x => x.ActividadadId,
                        principalTable: "Actividades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvestigacionRecursoEspe",
                columns: table => new
                {
                    InvestigacionesId = table.Column<int>(type: "int", nullable: false),
                    RecursosEspecializadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigacionRecursoEspe", x => new { x.InvestigacionesId, x.RecursosEspecializadosId });
                    table.ForeignKey(
                        name: "FK_InvestigacionRecursoEspe_Investigaciones_InvestigacionesId",
                        column: x => x.InvestigacionesId,
                        principalTable: "Investigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestigacionRecursoEspe_RecursosEspe_RecursosEspecializadosId",
                        column: x => x.RecursosEspecializadosId,
                        principalTable: "RecursosEspe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_investigacionId",
                table: "Actividades",
                column: "investigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigacionInvestigador_InvestigadoresAsignadosId",
                table: "InvestigacionInvestigador",
                column: "InvestigadoresAsignadosId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigacionRecursoEspe_RecursosEspecializadosId",
                table: "InvestigacionRecursoEspe",
                column: "RecursosEspecializadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_InvestigacionId",
                table: "Publicaciones",
                column: "InvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursosEspe_ActividadadId",
                table: "RecursosEspe",
                column: "ActividadadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigacionInvestigador");

            migrationBuilder.DropTable(
                name: "InvestigacionRecursoEspe");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Investigadores");

            migrationBuilder.DropTable(
                name: "RecursosEspe");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Investigaciones");
        }
    }
}
