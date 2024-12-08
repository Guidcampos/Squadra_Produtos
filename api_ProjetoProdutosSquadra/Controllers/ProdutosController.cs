using api_ProjetoProdutosSquadra.Interface;
using api_ProjetoProdutosSquadra.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
       
        /// <summary>
        /// Rota para listar todos os produtos da aplicação, *TODOS* tem acesso!
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarTodos")]
        [Authorize]

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
        /// <summary>
        /// Rota para listar apenas PRODUTOS EM ESTOQUE, *TODOS* tem acesso! 
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarEstoque")]
        [Authorize]

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

        /// <summary>
        /// Rota para listar um PRODUTO PELO ID, *TODOS* tem acesso! 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarID/{id}")]
        [Authorize]

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

        /// <summary>
        /// Rota para CADASTRO DE PRODUTO, apenas o *GERENTE* tem acesso!
        /// </summary>
        /// <param name="produto">a aplicação espera: Nome, Descricao, Preco e o IdCategoria </param>
        /// <returns></returns>
        [HttpPost("CadastrarProduto")]
        [Authorize(Roles = "Gerente")]

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

        /// <summary>
        /// Rota para DELETAR UM PRODUTO, apenas o *GERENTE* tem acesso!
        /// </summary>
        /// <param name="id">A aplicação espera um id do produto a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("DeletarProduto/{id}")]
        [Authorize(Roles = "Gerente")]

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

        /// <summary>
        /// Rota para ALTERAR O ESTOQUE DE UM PRODUTO, apenas o *GERENTE E FUNCIONARIO* tem acesso! 
        /// </summary>
        /// <param name="id">Id do produto a ser alterado</param>
        /// <param name="novaQuantidade">A nova quantidade do produto</param>
        /// <returns></returns>
        [HttpPut("AlterarEstoque/{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
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
