using Venda_BackEnd.Entites;
using Venda_BackEnd.Repository.Interface;
using Venda_BackEnd.Service.Interface;

namespace Venda_BackEnd.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteReposiotrio _clienteReposiotrio;

        public ClienteService(IClienteReposiotrio clienteReposiotrio)
        {
            _clienteReposiotrio = clienteReposiotrio;
        }

        public async Task CadastrarCliente(Cliente cliente)
        {
            await _clienteReposiotrio.CadastrarCliente(cliente);
        }

        public async Task<List<Cliente>> ListaCliente()
        {
            var lista = await _clienteReposiotrio.ListaCliente();

            return lista;
        }

        public async Task EditarCliente(Cliente cliente)
        {
           await _clienteReposiotrio.EditarCliente(cliente);
        }

        public async Task ApagarCliente(int cpf)
        {
            await _clienteReposiotrio.ApagarCliente(cpf);
        }
    }
}
