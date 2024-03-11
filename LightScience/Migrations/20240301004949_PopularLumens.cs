using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightScience.Migrations
{
    /// <inheritdoc />
    public partial class PopularLumens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lumens(CuturaId ,QuantidadeLumen, MedidaLuminosidade, DataLeitura)" +
                "VALUES ('1','735','500','19/02/2004')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
