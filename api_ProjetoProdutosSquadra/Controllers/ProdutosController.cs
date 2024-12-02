using api_ProjetoProdutosSquadra.Interface;
using api_ProjetoProdutosSquadra.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_ProjetoProdutosSquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
       
        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok( _produtoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarEstoque")]
        public IActionResult ListarEmEstoque() 
        {
            try
            {
                return Ok(_produtoRepository.ListarEmEstoque());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarID/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CadastrarProduto")]
        public IActionResult CadastrarProduto (Produto produto)
        {
            try
            {
                _produtoRepository.Cadastrar(produto);
                return StatusCode(201, produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarProduto/{id}")]
        public IActionResult DeletarProduto (int id)
        {
            try
            {
                _produtoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarEstoque/{id}")]
        public IActionResult AlterarEstoque (int id, int novaQuantidade)
        {
            try
            {
                _produtoRepository.AtualizarEstoqueProduto(id, novaQuantidade);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

  
}
