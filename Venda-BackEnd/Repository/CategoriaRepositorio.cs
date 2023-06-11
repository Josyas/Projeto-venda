using Dapper;
using System.Data;
using Venda_BackEnd.Data;
using Venda_BackEnd.Entites;
using Venda_BackEnd.Repository.Interface;

namespace Venda_BackEnd.Repository
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ConexaoDB _conexaoDB;

        public CategoriaRepositorio(ConexaoDB conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public async Task CadastrarCategoria(Categoria categoria)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "INSERT INTO Categoria (Nome) VALUES(@Nome)";

                await db.QueryAsync(query, categoria);

                _conexaoDB.FecharConexao();
            }
        }
    }
}
