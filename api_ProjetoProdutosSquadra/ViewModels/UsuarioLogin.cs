using System.ComponentModel.DataAnnotations;

namespace api_ProjetoProdutosSquadra.ViewModels
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string? Senha { get; set; }
    }
}
