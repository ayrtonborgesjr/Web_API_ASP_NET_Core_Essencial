using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Bebidas', 'http://wwww.macoratti.net/Imagens/1.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Lanches', 'http://wwww.macoratti.net/Imagens/2.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Sobremesas', 'http://wwww.macoratti.net/Imagens/3.jpg')");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES('Coca-cola Diet', 'Refrigerante de Cola 350 ml', 5.45, 'http://wwww.macoratti.net/Imagens/coca.jpg', 50, GETDATE(), (SELECT CategoriaId FROM Categorias WHERE Nome = 'Bebidas'))");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES('Lanche de Atum', 'Lanche de Atum com maionese', 8.50, 'http://wwww.macoratti.net/Imagens/atum.jpg', 10, GETDATE(), (SELECT CategoriaId FROM Categorias WHERE Nome = 'Lanches'))");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES('Pudim 100 g', 'Pudim de leite condensado 100g', 6.75, 'http://wwww.macoratti.net/Imagens/pudim.jpg', 20, GETDATE(), (SELECT CategoriaId FROM Categorias WHERE Nome = 'Sobremesas'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
