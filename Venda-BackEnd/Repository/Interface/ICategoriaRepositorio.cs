using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Repository.Interface
{
    public interface ICategoriaRepositorio
    {
        Task CadastrarCategoria(Categoria categoria);
    }
}