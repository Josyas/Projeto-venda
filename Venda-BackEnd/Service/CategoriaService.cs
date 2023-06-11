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

        public async Task CadastrarCategoria(Categoria categoria)
        {
            await _categoriaRepositorio.CadastrarCategoria(categoria);
        }
    }
}
