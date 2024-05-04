using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAPI.Migrations
{
    /// <inheritdoc />
    public partial class intermedias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsigRecursosEsp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecursoEspeId = table.Column<int>(type: "int", nullable: false),
                    ActividadInvId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsigRecursosEsp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsigRecursosEsp_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsigRecursosEsp_RecursosEspe_RecursoEspeId",
                        column: x => x.RecursoEspeId,
                        principalTable: "RecursosEspe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartInvestigadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigadorId = table.Column<int>(type: "int", nullable: false),
                    InvestigacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartInvestigadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartInvestigadores_Investigaciones_InvestigacionId",
                        column: x => x.InvestigacionId,
                        principalTable: "Investigaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartInvestigadores_Investigadores_InvestigadorId",
                        column: x => x.InvestigadorId,
                        principalTable: "Investigadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsigRecursosEsp_ActividadId",
                table: "AsigRecursosEsp",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_AsigRecursosEsp_RecursoEspeId",
                table: "AsigRecursosEsp",
                column: "RecursoEspeId");

            migrationBuilder.CreateIndex(
                name: "IX_PartInvestigadores_InvestigacionId",
                table: "PartInvestigadores",
                column: "InvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartInvestigadores_InvestigadorId",
                table: "PartInvestigadores",
                column: "InvestigadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsigRecursosEsp");

            migrationBuilder.DropTable(
                name: "PartInvestigadores");
        }
    }
}
