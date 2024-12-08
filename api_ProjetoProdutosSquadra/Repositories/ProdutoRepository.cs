using api_ProjetoProdutosSquadra.Contexts;
using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_ProjetoProdutosSquadra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly produtosContext _produtosContext;

        public ProdutoRepository( produtosContext ctx)
        {
            _produtosContext = ctx;
        }

        public void AtualizarEstoqueProduto(int id, int quantidadeEstoque)
        {
           var produtoAlterado = _produtosContext.Produtos.FirstOrDefault(x => x.IdProduto == id);
            if (quantidadeEstoque < 0) 
            {
                throw new Exception("Qauntidade do estoque invalida !");
            }
            if (produtoAlterado != null)
            {
                produtoAlterado.QuantidadeEstoque = quantidadeEstoque;
                produtoAlterado.Status = quantidadeEstoque == 0 ? "Indisponivel" : "Em estoque";
                _produtosContext.SaveChanges();

            }
            else
            {
                throw new Exception("Produto não encontrado!");           
            }

        }

        public Produto BuscarID(int id)
        {
            var produtoBuscado = _produtosContext.Produtos
                .Select(x => new Produto
                {
                    Nome = x.Nome,
                    Descricao = x.Descricao,
                    Preco = x.Preco,
                    QuantidadeEstoque = x.QuantidadeEstoque,
                    IdProduto = x.IdProduto,
                    Status = x.Status,
                   
                    IdCategoria = x.IdCategoria,
                    IdCategoriaNavigation = new Categoria
                    {
                        IdCategoria = x.IdCategoriaNavigation!.IdCategoria,
                        Tipo = x.IdCategoriaNavigation.Tipo
                    }

                }).FirstOrDefault(a => a.IdProduto == id);

            if (produtoBuscado != null) 
            {
                return produtoBuscado;
            }

             throw new Exception("Produto não encontrado!");
        }

        public void Cadastrar(Produto produto)
        {
            if (produto.Preco <= 0)
            {
                throw new Exception("O Preço deve ser maior que 0");
            }
            var categoria = _produtosContext.Categoria.FirstOrDefault(a => a.IdCategoria == produto.IdCategoria);
            var produtoBuscado = _produtosContext.Produtos.FirstOrDefault(a => a.Nome == produto.Nome);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            if (produtoBuscado != null)
            {
                throw new Exception("Produto já existe");
            }
            produto.Status = produto.QuantidadeEstoque == 0 ? "Indisponivel" : "Em estoque";
            _produtosContext.Produtos.Add(produto);
            _produtosContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            var produtoBuscado = _produtosContext.Produtos.FirstOrDefault(x => x.IdProduto == id);
            if(produtoBuscado != null)
            {
                _produtosContext.Produtos.Remove(produtoBuscado);
                _produtosContext.SaveChanges();
            }
            else
            {
                throw new Exception("Produto não encontrado!");
            }

        }

        public List<Produto> Listar()
        {
            return _produtosContext.Produtos.Select(x => new Produto
            {
                Nome = x.Nome,
                Descricao = x.Descricao,
                Preco = x.Preco,
                QuantidadeEstoque = x.QuantidadeEstoque,
                IdProduto = x.IdProduto,
                Status = x.Status,

                IdCategoria = x.IdCategoria,
                IdCategoriaNavigation = new Categoria
                {
                    IdCategoria = x.IdCategoriaNavigation!.IdCategoria,
                    Tipo = x.IdCategoriaNavigation.Tipo
                }

            }).ToList();
        }

        public List<Produto> ListarEmEstoque()
        {
            return _produtosContext.Produtos.Where(x => x.Status == "Em estoque").Select(x => new Produto
            {
                Nome = x.Nome,
                Descricao = x.Descricao,
                Preco = x.Preco,
                QuantidadeEstoque = x.QuantidadeEstoque,
                IdProduto = x.IdProduto,
                Status = x.Status,

                IdCategoria = x.IdCategoria,
                IdCategoriaNavigation = new Categoria
                {
                    IdCategoria = x.IdCategoriaNavigation!.IdCategoria,
                    Tipo = x.IdCategoriaNavigation.Tipo
                }

            }).ToList();
        }
    }
}
