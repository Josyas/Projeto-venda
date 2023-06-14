using Venda_BackEnd.Entites;
using Venda_BackEnd.Repository.Interface;
using Venda_BackEnd.Service.Interface;

namespace Venda_BackEnd.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaService(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task CadastrarCategoria(string nome)
        {
            await _categoriaRepositorio.CadastrarCategoria(nome);
        }

        public async Task<List<Categoria>> ListaCategoria()
        {
            var categorias = await _categoriaRepositorio.ListaCategoria();

            return categorias;
        }

        public async Task AlterarCategoria(Categoria categoria)
        {
            await _categoriaRepositorio.AlterarCategoria(categoria);
        }

        public async Task ApagarCategoria(int idCategoria)
        {
            await _categoriaRepositorio.ApagarCategoria(idCategoria);
        }
    }
}
