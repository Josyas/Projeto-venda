using Venda_BackEnd.Entites;
using Venda_BackEnd.Repository.Interface;
using Venda_BackEnd.Service.Interface;

namespace Venda_BackEnd.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task CadastroProduto(Produto produto)
        {
            await _produtoRepositorio.Cadastrarproduto(produto);
        }

        public async Task<List<Produto>> ListaProduto()
        {
            var lista = await _produtoRepositorio.ListaProduto();

            return lista;
        }

        public async Task EditarProduto(Produto produto)
        {
            await _produtoRepositorio.EditarProduto(produto);
        }

        public async Task ApagarProduto(int codigo)
        {
            await _produtoRepositorio.ApagarProduto(codigo);
        }
    }
}
