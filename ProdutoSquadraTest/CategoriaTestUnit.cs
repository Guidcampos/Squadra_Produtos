using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interface;
using Moq;


namespace ProdutoSquadraTest
{
    public class CategoriaTestUnit
    {

        [Fact]
        public void DeveAdicionarCategoriaNaLista()
        {
            // Arrange
            var categoriaList = new List<Categoria>();
            var categoria = new Categoria { Tipo = "Teste" };

            var mockRepository = new Mock<ICategoriaRepository>();
            mockRepository.Setup(x => x.CadastrarCategoria(categoria)).Callback<Categoria>(x => categoriaList.Add(x));

            // Act
            mockRepository.Object.CadastrarCategoria(categoria);

            // Assert
            var categoriaCadastrada = categoriaList.FirstOrDefault(p => p.Tipo == categoria.Tipo);

            Assert.NotNull(categoriaCadastrada);
            Assert.Equal(categoria.Tipo, categoriaCadastrada.Tipo);
            Assert.Contains(categoriaList, categoria => categoria.Tipo == "Teste");
        }

        [Fact]
        public void DeveRetornarQueoCategoriaFoiDeletado()
        {

            List<Categoria> categoriaList = new List<Categoria>
            {
             new Categoria { Tipo = "Teste", IdCategoria = 1 },
             new Categoria { Tipo = "Teste12", IdCategoria = 2 },
             new Categoria { Tipo = "Teste123", IdCategoria = 3 }

            };

            Categoria categoria = new Categoria { Tipo = "Teste", IdCategoria = 1 };

            int idbuscado = 1;


            var mockRepository = new Mock<ICategoriaRepository>();

            mockRepository.Setup(x => x.DeletarCategoria(idbuscado)).Callback<int>(x => categoriaList.Remove(categoriaList.FirstOrDefault(s => s.IdCategoria == idbuscado)));


            mockRepository.Object.DeletarCategoria(idbuscado);

            Assert.DoesNotContain(categoria, categoriaList);
            Assert.Equal(2, categoriaList.Count);

        }

        [Fact]
        public void DeveListarTodasCategorias()
        {
            //Arrange

            List<Categoria> categoriaList = new List<Categoria>
            {
             new Categoria { Tipo = "Teste", IdCategoria = 1 },
             new Categoria { Tipo = "Teste12", IdCategoria = 2 },
             new Categoria { Tipo = "Teste123", IdCategoria = 3 }

            };


            var mockRepository = new Mock<ICategoriaRepository>();

            mockRepository.Setup(x => x.Listar()).Returns(categoriaList);

            //Act
            //Executando o metodo Get e atribui a resposta em result 
            var result = mockRepository.Object.Listar();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(result, p => p.Tipo == "Teste");
            Assert.Contains(result, p => p.Tipo == "Teste12");
            Assert.Contains(result, p => p.Tipo == "Teste123");
        }
    }
}
