using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        public FornecedorController(IRepositorioWrapper repositorioWrapper)
        {
            _repositorioWrapper = repositorioWrapper;
        }
        private IRepositorioWrapper _repositorioWrapper;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var fornecedores = await _repositorioWrapper.Fornecedor.ListarTodos();
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

                
            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _repositorioWrapper.Fornecedor.Criar(fornecedor);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _repositorioWrapper.Fornecedor.Alterar(fornecedor);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        public async Task<IActionResult> Excluir(int id )
        {
            try
            {
                var fornecedor =  await _repositorioWrapper.Fornecedor.ObterPorId(id);
                if (fornecedor == null)
                    return NotFound();
                await _repositorioWrapper.Fornecedor.Excluir(fornecedor);
                
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
                var fornecedores = await _repositorioWrapper.Fornecedor.ObterPorId(id);
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
