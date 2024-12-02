using api_ProjetoProdutosSquadra.Domains;

namespace api_ProjetoProdutosSquadra.Interface
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        void Deletar(int id);
        Produto BuscarID (int id);
        void AtualizarEstoqueProduto(int id, int quantidadeEstoque);
        List<Produto> Listar();
        List<Produto> ListarEmEstoque();
    }
}
