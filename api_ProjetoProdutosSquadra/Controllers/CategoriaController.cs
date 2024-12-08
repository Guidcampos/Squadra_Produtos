using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using api_ProjetoProdutosSquadra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_ProjetoProdutosSquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        /// <summary>
        /// Rota para listar as CATEGORIAS de produtos da aplicação, *TODOS* tem acesso!
        /// </summary>
        /// <returns>Categorias</returns>
        [HttpGet("ListarTodas")]
        [Authorize]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_categoriaRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Rota para CADASTRO DE CATEGORIA, apenas o *GERENTE* tem acesso!
        /// </summary>
        /// <param name="categoria">A aplicação espera um TIPO de categoria somente!</param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Gerente")]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                _categoriaRepository.CadastrarCategoria(categoria);
                return StatusCode(201, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Rota para DELETAR CATEGORIA, apenas o *GERENTE* tem acesso! 
        /// </summary>
        /// <param name="id">id da categoria a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("Deletar")]
        [Authorize(Roles = "Gerente")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _categoriaRepository.DeletarCategoria(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
