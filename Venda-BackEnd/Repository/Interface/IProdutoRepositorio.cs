using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Repository.Interface
{
    public interface IProdutoRepositorio
    {
        Task ApagarProduto(int codigo);
        Task Cadastrarproduto(Produto produto);
        Task EditarProduto(Produto produto);
        Task<List<Produto>> ListaProduto();
    }
}