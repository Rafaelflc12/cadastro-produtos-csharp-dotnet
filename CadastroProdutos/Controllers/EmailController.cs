using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public EmailController(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        public IRepositorioWrapper _repositorioWrapper;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var emails = await _repositorioWrapper.Email.ListarTodos();
                return Ok(emails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Email email)
        {
            try
            {
                await _repositorioWrapper.Email.Criar(email);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar([FromBody] Email email)
        {
            try
            {
                await _repositorioWrapper.Email.Alterar(email);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var email = await _repositorioWrapper.Email.ObterPorId(id);
                if (email == null)
                    return NotFound();
                await _repositorioWrapper.Email.Excluir(email);

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
                var emails = await _repositorioWrapper.Email.ObterPorId(id);
                return Ok(emails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
