using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightScience.Migrations
{
    /// <inheritdoc />
    public partial class taltal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lumens_CuturaId",
                table: "Lumens");

            migrationBuilder.DropColumn(
                name: "LumensId",
                table: "Cuturas");

            migrationBuilder.CreateIndex(
                name: "IX_Lumens_CuturaId",
                table: "Lumens",
                column: "CuturaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lumens_CuturaId",
                table: "Lumens");

            migrationBuilder.AddColumn<int>(
                name: "LumensId",
                table: "Cuturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lumens_CuturaId",
                table: "Lumens",
                column: "CuturaId",
                unique: true);
        }
    }
}
