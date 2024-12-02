using System;
using System.Collections.Generic;

namespace api_ProjetoProdutosSquadra.Domains;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public int? IdTipoUsuario { get; set; }

    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
}
