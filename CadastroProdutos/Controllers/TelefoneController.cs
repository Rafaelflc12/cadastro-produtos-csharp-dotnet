using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        public TelefoneController(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        public IRepositorioWrapper _repositorioWrapper;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var telefones = await _repositorioWrapper.Telefone.ListarTodos();
                return Ok(telefones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Telefone telefone)
        {
            try
            {
                await _repositorioWrapper.Telefone.Criar(telefone);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Telefone Telefone)
        {
            try
            {
                await _repositorioWrapper.Telefone.Alterar(Telefone);
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
                var telefone = await _repositorioWrapper.Telefone.ObterPorId(id);
                if (telefone == null)
                    return NotFound();
                await _repositorioWrapper.Telefone.Excluir(telefone);

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
                var telefones = await _repositorioWrapper.Telefone.ObterPorId(id);
                return Ok(telefones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
