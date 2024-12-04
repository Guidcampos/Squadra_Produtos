using api_ProjetoProdutosSquadra.Contexts;
using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_ProjetoProdutosSquadra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly produtosContext _produtosContext;

        public UsuarioRepository(produtosContext ctx)
        {
            _produtosContext = ctx;
        }
        public Usuario BuscarEmaileSenha(string email, string senha)
        {
            var usuario = _produtosContext.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
      
        }
        public string GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, usuario!.Email), //Nome do Usuario
                new Claim(ClaimTypes.Role, usuario!.IdTipoUsuarioNavigation!.Titulo) // Papel do usuario
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("93f8207bc2281eebd070f337f907984bfb4ef2d3f1b08689e2e7e16030c8c5e9"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: "api-autenticacao",
                audience: "api-cadastro",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public List<Usuario> ListarTodos()
        {
            return _produtosContext.Usuarios.Include(x => x.IdTipoUsuarioNavigation).ToList();
        }
    }
}
