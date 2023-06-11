using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Service.Interface
{
    public interface ICategoriaService
    {
        Task CadastrarCategoria(Categoria categoria);
    }
}