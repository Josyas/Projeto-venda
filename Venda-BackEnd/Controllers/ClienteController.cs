using Microsoft.AspNetCore.Mvc;
using Venda_BackEnd.DTO;
using Venda_BackEnd.Entites;
using Venda_BackEnd.Service.Interface;

namespace Venda_BackEnd.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("novo-cliente")]
        public async Task<ActionResult> CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
              await _clienteService.CadastrarCliente(cliente);

              return Ok();
            }

            return BadRequest();
        }

        [HttpGet("clientes")]
        public async Task<ActionResult<List<Cliente>>> ListaCliente()
        {
            if (ModelState.IsValid)
            {
                var clientes = await _clienteService.ListaCliente();

                return Ok(clientes);
            }

            return BadRequest();
        }

        [HttpPut("atualiza-cliente")]
        public async Task<ActionResult> EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.EditarCliente(cliente);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("remove-cliente")]
        public async Task<ActionResult> ApagarCliente(BaseDTO cpfCliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.ApagarCliente(cpfCliente.Cpf);

                return Ok();
            }

            return BadRequest();
        }
    }
}
