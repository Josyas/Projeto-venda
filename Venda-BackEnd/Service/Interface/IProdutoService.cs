using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Service.Interface
{
    public interface IProdutoService
    {
        Task CadastroProduto(Produto produto);
    }
}