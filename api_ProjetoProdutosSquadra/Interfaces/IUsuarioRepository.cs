using api_ProjetoProdutosSquadra.Domains;

namespace api_ProjetoProdutosSquadra.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        Usuario BuscarEmaileSenha(string email, string senha);
        string GerarToken(Usuario usuario);

    }
}
