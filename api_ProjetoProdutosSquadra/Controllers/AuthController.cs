using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using api_ProjetoProdutosSquadra.Interfaces;
using api_ProjetoProdutosSquadra.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_ProjetoProdutosSquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("ListarUsuarios")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public IActionResult ListarTodos()
        {
            try
            {
               return Ok( _usuarioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Logar(UsuarioLogin usuario)
        {
            try
            {
              Usuario usuarioBuscado =  _usuarioRepository.BuscarEmaileSenha(usuario.Email, usuario.Senha);
                
                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos!");
                }

                var token = _usuarioRepository.GerarToken(usuarioBuscado);
                return Ok(new { Token = token });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
       
    }
}
