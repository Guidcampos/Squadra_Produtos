using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using api_ProjetoProdutosSquadra.Repositories;
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


        [HttpGet("ListarTodas")]
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

        [HttpPost("Cadastrar")]
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

        [HttpDelete("Deletar")]
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
