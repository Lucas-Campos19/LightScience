using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightScience.Migrations
{
    /// <inheritdoc />
    public partial class migracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuturas",
                columns: table => new
                {
                    CuturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LumensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuturas", x => x.CuturaId);
                });

            migrationBuilder.CreateTable(
                name: "Lumens",
                columns: table => new
                {
                    LumenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeLumen = table.Column<int>(type: "int", nullable: false),
                    MedidaLuminosidade = table.Column<int>(type: "int", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLeitura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lumens", x => x.LumenId);
                    table.ForeignKey(
                        name: "FK_Lumens_Cuturas_CuturaId",
                        column: x => x.CuturaId,
                        principalTable: "Cuturas",
                        principalColumn: "CuturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lumens_CuturaId",
                table: "Lumens",
                column: "CuturaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lumens");

            migrationBuilder.DropTable(
                name: "Cuturas");
        }
    }
}
