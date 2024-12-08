using api_ProjetoProdutosSquadra.Domains;
using api_ProjetoProdutosSquadra.Interfaces;
using Moq;


namespace ProdutoSquadraTest
{
    public class AuthTestUnit
    {
        [Fact]
        public void DeveListarTodosUsuarios()
        {
            //Arrange

            List<Usuario> usuarioList = new List<Usuario>
            {
                new Usuario {Email = "teste1@teste.com", Senha = "123"},
                new Usuario {Email = "teste2@teste.com", Senha = "123"},
                new Usuario {Email = "teste3@teste.com", Senha = "123"}

            };


            var mockRepository = new Mock<IUsuarioRepository>();

            mockRepository.Setup(x => x.ListarTodos()).Returns(usuarioList);

            //Act
            //Executando o metodo Get e atribui a resposta em result 
            var result = mockRepository.Object.ListarTodos();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(result, p => p.Email == "teste1@teste.com");
            Assert.Contains(result, p => p.Email == "teste2@teste.com");
            Assert.Contains(result, p => p.Email == "teste3@teste.com");
        }


        [Fact]
        public void DeveBuscarPeloEmailSenha()
        {
            //Arrange

            List<Usuario> usuarioList = new List<Usuario>
            {
                new Usuario {Email = "teste1@teste.com", Senha = "123"},
                new Usuario {Email = "teste2@teste.com", Senha = "123"},
                new Usuario {Email = "teste3@teste.com", Senha = "123"}

            };


            var mockRepository = new Mock<IUsuarioRepository>();
            var email = "teste1@teste.com";
            var senha = "123";

            mockRepository.Setup(x => x.BuscarEmaileSenha(email, senha)).Returns(usuarioList.FirstOrDefault(a => a.Email == email && a.Senha == senha));

            //Act
            //Executando o metodo Get e atribui a resposta em result 
            var result = mockRepository.Object.BuscarEmaileSenha(email, senha);

            //Assert

            Assert.Contains(email, result.Email);

        }


    }


}

