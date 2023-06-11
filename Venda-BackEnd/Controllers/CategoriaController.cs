using Microsoft.AspNetCore.Mvc;
using Venda_BackEnd.Entites;
using Venda_BackEnd.Service.Interface;

namespace Venda_BackEnd.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost("nova-categoria")]
        public async Task<ActionResult> CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.CadastrarCategoria(categoria);

                return Ok();
            }

            return BadRequest();
        }
    }
}
