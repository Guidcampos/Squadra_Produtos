using api_ProjetoProdutosSquadra.Contexts;
using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_ProjetoProdutosSquadra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly produtosContext _produtosContext;

        public CategoriaRepository(produtosContext ctx)
        {
            _produtosContext = ctx;
        }
        public void CadastrarCategoria(Categoria categoria)
        {
            var buscarCategoria = _produtosContext.Categoria.FirstOrDefault(x => x.Tipo == categoria.Tipo);
            if (buscarCategoria == null)
            {
                _produtosContext.Categoria.Add(categoria);
                _produtosContext.SaveChanges();
            }
            else
            {
                throw new Exception("Categoria já existe!");
            }

        }

        public void DeletarCategoria(int id)
        {
            var categoriaBuscada = _produtosContext.Categoria.FirstOrDefault(x => x.IdCategoria == id);
            if (categoriaBuscada != null)
            {
                _produtosContext.Remove(categoriaBuscada);
                _produtosContext.SaveChanges();
            }
            else
            {
                throw new Exception("Categoria não encontrada!");
            }

        }

        public List<Categoria> Listar()
        {
            var categorias = _produtosContext.Categoria
                 .Select(c => new Categoria
                 {
                     IdCategoria = c.IdCategoria,
                     Tipo = c.Tipo,
                     Produtos = c.Produtos.Select(p => new Produto
                     {
                         IdProduto = p.IdProduto,
                         Nome = p.Nome,
                         Preco = p.Preco,
                         Descricao = p.Descricao,
                         QuantidadeEstoque = p.QuantidadeEstoque,
                         Status = p.Status
                     }).ToList()


                 }).ToList();

            return categorias;
        }
    }
}
