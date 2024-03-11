using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightScience.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoLuxs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Luxs",
                columns: table => new
                {
                    LuxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeLux = table.Column<int>(type: "int", nullable: false),
                    DataLeitura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luxs", x => x.LuxId);
                    table.ForeignKey(
                        name: "FK_Luxs_Cuturas_CuturaId",
                        column: x => x.CuturaId,
                        principalTable: "Cuturas",
                        principalColumn: "CuturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Luxs_CuturaId",
                table: "Luxs",
                column: "CuturaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Luxs");
        }
    }
}
