using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightScience.Migrations
{
    /// <inheritdoc />
    public partial class populandoCutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cuturas(CodigoCutura, Categoria, Descricao, Nome)" +
                "VALUES('01','TESTE','muitoteste','ruculateste')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
