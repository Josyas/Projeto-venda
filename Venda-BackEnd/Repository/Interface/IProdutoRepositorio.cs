using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Repository.Interface
{
    public interface IProdutoRepositorio
    {
        Task Cadastrarproduto(Produto produto);
    }
}