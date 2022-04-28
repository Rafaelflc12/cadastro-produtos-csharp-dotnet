using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }
        public IPedidoRepositorio _pedidoRepositorio;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var pedidos = await _pedidoRepositorio.ListarTodos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Pedido pedido)
        {
            try
            {
                await _pedidoRepositorio.Criar(pedido);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Pedido pedido)
        {
            try
            {
                await _pedidoRepositorio.Alterar(pedido);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var pedido = await _pedidoRepositorio.ObterPorId(id);
                if (pedido == null)
                    return NotFound();
                await _pedidoRepositorio.Excluir(pedido);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var pedidos = await _pedidoRepositorio.ObterPorId(id);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
