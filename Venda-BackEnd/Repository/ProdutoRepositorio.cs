using Dapper;
using System.Data;
using Venda_BackEnd.Data;
using Venda_BackEnd.Entites;
using Venda_BackEnd.Repository.Interface;

namespace Venda_BackEnd.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ConexaoDB _conexaoDB;

        public ProdutoRepositorio(ConexaoDB conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public async Task Cadastrarproduto(Produto produto)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "INSERT INTO Produto (Codigo, Nome, Preco, Descricao, IdCategoria) VALUES" +
                               "(@Codigo, @Nome, @Preco, @Descricao, @IdCategoria)";

                await db.QueryAsync(query, produto);
            }
        }

        public async Task<List<Produto>> ListaProduto()
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "SELECT prod.Codigo, prod.Nome ,prod.Preco, prod.Descricao, cat.IdCategoria, cat.Nome " +
                               "FROM Produto AS prod INNER JOIN Categoria As cat ON prod.IdCategoria = cat.IdCategoria";

                var lista = await db.QueryAsync<Produto, Categoria, Produto>(query, (produto, categoria) =>
                {
                    produto.Categoria = categoria;
                    return produto;
                }, splitOn: "IdCategoria");

                return lista.ToList();
            } 
        }

        public async Task EditarProduto(Produto produto)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "INSERT INTO Produto SET @Nome = Nome, @Preco = Preco, @Descricao = Descricao, " +
                               "@IdCategoria = IdCategoria Where @Codigo = Codigo";

                await db.QueryAsync(query, produto);
            }
        }

        public async Task ApagarProduto(int codigo)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "DELETE FROM Produto WHERE Codigo = @Codigo";

                await db.QueryAsync (query, new { Codigo = codigo});
            }
        }
    }
}
