using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_ProjetoProdutosSquadra.Domains;

public partial class Produto
{
    public int IdProduto { get; set; }

    public int IdCategoria { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; } = null!;
    [Required(ErrorMessage = "O campo Descricao é obrigatório.")]
    public string? Descricao { get; set; }

    public string? Status { get; set; } = null!;
    [Required(ErrorMessage = "O campo Preco é obrigatório.")]
    public decimal? Preco { get; set; }

    public int QuantidadeEstoque { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
