using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Service.Interface
{
    public interface IClienteService
    {
        Task ApagarCliente(int cpf);
        Task CadastrarCliente(Cliente cliente);
        Task EditarCliente(Cliente cliente);
        Task<List<Cliente>> ListaCliente();
    }
}