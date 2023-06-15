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
                string query = "INSERT INTO Produto (Codigo, Preco, Descricao, IdCategoria) VALUES" +
                               "(@Codigo, @Preco, @Descricao, @IdCategoria)";

                await db.QueryAsync(query, produto);
            }
        }
    }
}
