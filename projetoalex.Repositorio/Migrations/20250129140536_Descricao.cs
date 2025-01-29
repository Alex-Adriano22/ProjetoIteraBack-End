using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoalex.Repositorio.Migrations
{
    public partial class Descricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "Descricao1",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao1",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "Preco");
        }
    }
}
