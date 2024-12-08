using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using Moq;

namespace ProdutoSquadraTest
{
    public class ProdutoTestUnit
    {
        [Fact]
        public void DeveListarTodosProdutos()
        {
            //Arrange

            //lista de produtos
            List<Produto> productList = new List<Produto>
            {
                new Produto {  Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1" },
                new Produto {  Nome = "Produto 2", Preco = 10, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 2" },
                new Produto {  Nome = "Produto 3", Preco = 38, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 3" },


            };

            //Cria um objeto de simulaçăo do tipo ProductRepository
            var mockRepository = new Mock<IProdutoRepository>();
            //Configura o metodo Get para que retorne a lista mockada
            mockRepository.Setup(x => x.Listar()).Returns(productList);

            //Act
            //Executando o metodo Get e atribui a resposta em result 
            var result = mockRepository.Object.Listar();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(result, p => p.Nome == "Produto 1");
            Assert.Contains(result, p => p.Nome == "Produto 2");
            Assert.Contains(result, p => p.Nome == "Produto 3");
        }

        [Fact]
        public void DeveListarTodosProdutosEmEstoque()
        {
            //Arrange

            //lista de produtos
            List<Produto> productList = new List<Produto>
            {
                new Produto {  Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1", Status = "Em Estoque" },
                new Produto {  Nome = "Produto 2", Preco = 10, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 2", Status = "Em estoque" },
                new Produto {  Nome = "Produto 3", Preco = 38, QuantidadeEstoque = 0, IdCategoria = 1, Descricao = "Produto 3", Status = "Indisponivel" },

            };

            var produtosEmEstoque = productList.Where(p => p.Status.Equals("Em estoque", StringComparison.OrdinalIgnoreCase)).ToList();

            //Cria um objeto de simulaçăo do tipo ProductRepository
            var mockRepository = new Mock<IProdutoRepository>();
            //Configura o metodo Get para que retorne a lista mockada
            mockRepository.Setup(x => x.ListarEmEstoque()).Returns(produtosEmEstoque);

            //Act
            //Executando o metodo Get e atribui a resposta em result 
            var result = mockRepository.Object.ListarEmEstoque();

            //Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.Nome == "Produto 1");
            Assert.Contains(result, p => p.Nome == "Produto 2");
            Assert.DoesNotContain(result, p => p.Nome == "Produto 3");
        }

        [Fact]
        public void DeveAdicionarProdutoNaLista()
        {
            // Arrange
            var productList = new List<Produto>();
            var product = new Produto { Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1" };

            var mockRepository = new Mock<IProdutoRepository>();
            mockRepository.Setup(x => x.Cadastrar(product)).Callback<Produto>(x => productList.Add(x));

            // Act
            mockRepository.Object.Cadastrar(product);

            // Assert
            var produtoCadastrado = productList.FirstOrDefault(p => p.Nome == product.Nome);
            Assert.NotNull(produtoCadastrado);
            Assert.Equal(product.Nome, produtoCadastrado.Nome);
            Assert.Equal(product.Preco, produtoCadastrado.Preco);
            Assert.Contains(productList, produto => produto.Nome == "Produto 1");
        }


        [Fact]
        public void DeveRetornarQueoProdutoFoiDeletado()
        {

            //lista de produtos
            List<Produto> productList = new List<Produto>
            {
                new Produto {  Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1" },
                new Produto {  Nome = "Produto 2", Preco = 10, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 2" },
                new Produto {  Nome = "Produto 3", Preco = 38, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 3" },


            };

            Produto product = new Produto { Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1" };

            int idbuscado = 1;


            var mockRepository = new Mock<IProdutoRepository>();

            mockRepository.Setup(x => x.Deletar(idbuscado)).Callback<int>(x => productList.Remove(productList.FirstOrDefault(s => s.IdProduto == idbuscado)));


            mockRepository.Object.Deletar(idbuscado);

            Assert.DoesNotContain(product, productList);

        }

        [Fact]

        public void DeveRetornarUmProdutoPeloID()
        {
            //lista de produtos
            List<Produto> productList = new List<Produto>
            {
                new Produto {  Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1", IdProduto = 1 },
                new Produto {  Nome = "Produto 2", Preco = 10, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 2", IdProduto = 2 },
                new Produto {  Nome = "Produto 3", Preco = 38, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 3", IdProduto = 3 },


            };

            Produto product = new Produto { Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1", IdProduto = 1 };

            int idbuscado = 1;

            var mockRepository = new Mock<IProdutoRepository>();

            mockRepository.Setup(x => x.BuscarID(idbuscado)).Returns(productList.FirstOrDefault(a => a.IdProduto == idbuscado));
            var result = mockRepository.Object.BuscarID(idbuscado);

            Assert.Equal(idbuscado, result.IdProduto);

        }

        [Fact]

        public void DeveAtualizarOEstoqueDeProduto()
        {
            //lista de produtos
            List<Produto> productList = new List<Produto>
            {
                new Produto {  Nome = "Produto 1", Preco = 78, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 1", IdProduto = 1 },
                new Produto {  Nome = "Produto 2", Preco = 10, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 2", IdProduto = 2 },
                new Produto {  Nome = "Produto 3", Preco = 38, QuantidadeEstoque = 5, IdCategoria = 1, Descricao = "Produto 3", IdProduto = 3 },


            };


            var idbuscado = 1;
            var quantidadeEstoque = 20;


            var mockRepository = new Mock<IProdutoRepository>();

            mockRepository.Setup(x => x.AtualizarEstoqueProduto(idbuscado, quantidadeEstoque)).Callback<int, int>((id, q) =>
            {
                var item = productList.FirstOrDefault(x => x.IdProduto == id);

                if (item != null)
                {
                    item.QuantidadeEstoque = q;

                }
            });

            mockRepository.Object.AtualizarEstoqueProduto(idbuscado, quantidadeEstoque);
            var updatedProduct = productList.FirstOrDefault(x => x.IdProduto == idbuscado);

            Assert.Equal(20, updatedProduct.QuantidadeEstoque);

        }

    }
}

