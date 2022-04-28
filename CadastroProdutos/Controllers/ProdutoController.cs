using Contratos;
using Entidade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IProdutoRepositorio _produtoRepositorio;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try { 
            
                var produtos = await _produtoRepositorio.ListarTodos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Produto produto)
        {
            try
            {
                await _produtoRepositorio.Criar(produto);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar([FromBody] Produto produto)
        {
            try
            {
                await _produtoRepositorio.Alterar(produto);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var produto = await _produtoRepositorio.ObterPorId(id);
                if (produto == null)
                    return NotFound();
                await _produtoRepositorio.Excluir(produto);

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
                var produtos = await _produtoRepositorio.ObterPorId(id);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }
    }


}
