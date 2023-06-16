using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Venda_BackEnd.DTO;
using Venda_BackEnd.Entites;
using Venda_BackEnd.Service.Interface;

namespace Venda_BackEnd.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost("novo-produto")]
        public async Task<ActionResult> CadastroProduto(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDTO = _mapper.Map<Produto>(produto);

                await _produtoService.CadastroProduto(produtoDTO);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("lista-produto")]
        public async Task<ActionResult<List<Produto>>> ListaProduto()
        {
            if (ModelState.IsValid)
            {
                var lista = await _produtoService.ListaProduto();

                return Ok(lista);
            }

            return BadRequest();
        }

        [HttpPut("altera-produto")]
        public async Task<ActionResult> EditarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.EditarProduto(produto);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("remover-produto")]
        public async Task<ActionResult> ApagarProduto(BaseDTO codigo)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.ApagarProduto(codigo.Codigo);

                return Ok();
            }

            return BadRequest();
        }
    }
}
