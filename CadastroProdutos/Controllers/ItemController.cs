using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        private IRepositorioWrapper _repositorioWrapper;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var items = await _repositorioWrapper.Item.ListarTodos();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Item item)
        {
            try
            {
                await _repositorioWrapper.Item.Criar(item);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Item item)
        {
            try
            {
                await _repositorioWrapper.Item.Alterar(item);
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
                var item = await _repositorioWrapper.Item.ObterPorId(id);
                if (item == null)
                    return NotFound();
                await _repositorioWrapper.Item.Excluir(item);

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
                var items = await _repositorioWrapper.Item.ObterPorId(id);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
