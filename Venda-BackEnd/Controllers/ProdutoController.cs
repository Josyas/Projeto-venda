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
    }
}
