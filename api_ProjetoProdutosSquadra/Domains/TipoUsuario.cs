using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_ProjetoProdutosSquadra.Domains;

public partial class TipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string Titulo { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
