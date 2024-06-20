using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightScience.Migrations
{
    /// <inheritdoc />
    public partial class ahhhhhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luxs_Cuturas_CuturaId",
                table: "Luxs");

            migrationBuilder.DropIndex(
                name: "IX_Luxs_CuturaId",
                table: "Luxs");

            migrationBuilder.DropColumn(
                name: "CuturaId",
                table: "Luxs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuturaId",
                table: "Luxs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Luxs_CuturaId",
                table: "Luxs",
                column: "CuturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Luxs_Cuturas_CuturaId",
                table: "Luxs",
                column: "CuturaId",
                principalTable: "Cuturas",
                principalColumn: "CuturaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
