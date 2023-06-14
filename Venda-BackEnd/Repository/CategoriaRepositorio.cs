using Dapper;
using System.Data;
using System.Data.Common;
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

        public async Task CadastrarCategoria(string nome)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "INSERT INTO Categoria (Nome) VALUES(@Nome)";

                await db.QueryAsync(query, new { Nome = nome});

                _conexaoDB.FecharConexao();
            }
        }

        public async Task<List<Categoria>> ListaCategoria()
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "SELECT * FROM Categoria";

                var categorias = await db.QueryAsync<Categoria>(query);

                _conexaoDB.FecharConexao();

                return categorias.ToList();
            }
        }

        public async Task AlterarCategoria(Categoria categoria)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "UPDATE Categoria SET Nome = @Nome WHERE IdCategoria = @IdCategoria";

                await db.QueryAsync(query, categoria);

                _conexaoDB.FecharConexao();
            }
        }

        public async Task ApagarCategoria(int idCategoria)
        {
            using (IDbConnection db = _conexaoDB.PegarConexao())
            {
                string query = "DELETE FROM Categoria WHERE @IdCategoria = idCategoria";

                await db.QueryAsync(query, new { IdCategoria = idCategoria });

                _conexaoDB.FecharConexao();
            }
        }
    }
}
