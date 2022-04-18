using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadoraController : ControllerBase
    {
        public TransportadoraController(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        private IRepositorioWrapper _repositorioWrapper;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var transportadoras = await _repositorioWrapper.Transportadora.ListarTodos();
                return Ok(transportadoras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Transportadora transportadora)
        {
            try
            {
                await _repositorioWrapper.Transportadora.Criar(transportadora);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Transportadora transportadora)
        {
            try
            {
                await _repositorioWrapper.Transportadora.Alterar(transportadora);
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
                var transportadora = await _repositorioWrapper.Transportadora.ObterPorId(id);
                if (transportadora == null)
                    return NotFound();
                await _repositorioWrapper.Transportadora.Excluir(transportadora);

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
                var transportadoras = await _repositorioWrapper.Transportadora.ObterPorId(id);
                return Ok(transportadoras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
