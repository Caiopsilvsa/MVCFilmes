using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Filmes.Migrations
{
    /// <inheritdoc />
    public partial class CampoPontoadicionado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ponto",
                table: "Filme",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ponto",
                table: "Filme");
        }
    }
}
