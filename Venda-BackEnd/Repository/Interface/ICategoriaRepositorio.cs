using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Repository.Interface
{
    public interface ICategoriaRepositorio
    {
        Task AlterarCategoria(Categoria categoria);
        Task ApagarCategoria(int idCategoria);
        Task CadastrarCategoria(string nome);
        Task<List<Categoria>> ListaCategoria();
    }
}