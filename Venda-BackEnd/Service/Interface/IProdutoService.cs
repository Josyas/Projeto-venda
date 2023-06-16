using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Service.Interface
{
    public interface IProdutoService
    {
        Task ApagarProduto(int codigo);
        Task CadastroProduto(Produto produto);
        Task EditarProduto(Produto produto);
        Task<List<Produto>> ListaProduto();
    }
}