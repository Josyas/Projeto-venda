using Dapper;
using System.Data;
using Venda_BackEnd.Data;
using Venda_BackEnd.Entites;
using Venda_BackEnd.Repository.Interface;

namespace Venda_BackEnd.Repository
{
    public class ClienteRepositorio : IClienteReposiotrio
    {
        private readonly ConexaoDB _conexaoDB;

        public ClienteRepositorio(ConexaoDB conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public async Task CadastrarCliente(Cliente cliente)
        {
            using IDbConnection db = _conexaoDB.PegarConexao();

            string query = "INSERT INTO Cliente (Cpf, Nome, Endereco, DataNascimento, Telefone, Email) " +
                           "VALUES (@Cpf, @Nome, @Endereco, @DataNascimento, @Telefone, @Email)";

            await db.QueryAsync(query, cliente);

            _conexaoDB.FecharConexao();
        }

        public async Task<List<Cliente>> ListaCliente()
        {
            using IDbConnection db = _conexaoDB.PegarConexao();

            string query = "SELECT * FROM Cliente";

            var lista = await db.QueryAsync<Cliente>(query);

            _conexaoDB.FecharConexao();

            return lista.ToList();
        }

        public async Task EditarCliente(Cliente cliente)
        {
            using IDbConnection db = _conexaoDB.PegarConexao();

            string query = "UPDATE Cliente SET Cpf = @Cpf, Nome = @Nome, Endereco = @Endereco," +
                           "DataNascimento = @DataNascimento, Telefone = @Telefone, Email = @Email WHERE Cpf = @Cpf";

            await db.QueryAsync(query, cliente);

            _conexaoDB.FecharConexao();
        }

        public async Task ApagarCliente(int cpf)
        {
            using IDbConnection db = _conexaoDB.PegarConexao();

            string query = "DELETE FROM Cliente WHERE Cpf = @Cpf";

            await db.QueryAsync(query, new { Cpf = cpf });

            _conexaoDB.FecharConexao();
        }
    }
}
