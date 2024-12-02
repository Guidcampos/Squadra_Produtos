using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_ProjetoProdutosSquadra.Domains;

public partial class Categoria
{
    public int IdCategoria { get; set; }
    [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
    public string Tipo { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
