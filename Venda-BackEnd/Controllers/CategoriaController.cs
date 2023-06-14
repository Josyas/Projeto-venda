using Microsoft.AspNetCore.Mvc;
using Venda_BackEnd.DTO;
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
        public async Task<ActionResult> CadastrarCategoria(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.CadastrarCategoria(categoria.Nome);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<Categoria>> ListaCategoria()
        {
            if (ModelState.IsValid)
            {
                var categorias = await _categoriaService.ListaCategoria();

                return Ok(categorias);
            }

            return BadRequest();
        }

        [HttpPut("atualiza-cliente")]
        public async Task<ActionResult> AlteraCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.AlterarCategoria(categoria);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("remove-categoria")]
        public async Task<ActionResult> ApagarCategoria(BaseDTO idCategoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.ApagarCategoria(idCategoria.Id);

                return Ok();
            }

            return BadRequest();
        }
    }
}
