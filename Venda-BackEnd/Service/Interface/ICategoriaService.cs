using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Service.Interface
{
    public interface ICategoriaService
    {
        Task AlterarCategoria(Categoria categoria);
        Task ApagarCategoria(int idCategoria);
        Task CadastrarCategoria(string nome);
        Task<List<Categoria>> ListaCategoria();
    }
}