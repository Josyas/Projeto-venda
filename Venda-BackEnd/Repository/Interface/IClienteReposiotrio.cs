using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Repository.Interface
{
    public interface IClienteReposiotrio
    {
        Task ApagarCliente(int cpf);
        Task CadastrarCliente(Cliente cliente);
        Task EditarCliente(Cliente cliente);
        Task<List<Cliente>> ListaCliente();
    }
}