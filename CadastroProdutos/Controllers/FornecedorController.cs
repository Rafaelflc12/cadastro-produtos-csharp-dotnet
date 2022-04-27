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
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IFornecedorRepositorio _fornecedorRepositorio;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var fornecedores = await _fornecedorRepositorio.ListarTodos();
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
                await _fornecedorRepositorio.Criar(fornecedor);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar([FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _fornecedorRepositorio.Alterar(fornecedor);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id )
        {
            try
            {
                var fornecedor =  await _fornecedorRepositorio.ObterPorId(id);
                if (fornecedor == null)
                    return NotFound();
                await _fornecedorRepositorio.Excluir(fornecedor);
                
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
                var fornecedores = await _fornecedorRepositorio.ObterPorId(id);
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
