using api_ProjetoProdutosSquadra.Domains;

namespace api_ProjetoProdutosSquadra.Interface
{
    public interface ICategoriaRepository
    {
        void CadastrarCategoria(Categoria categoria);
        void DeletarCategoria(int id);
        List<Categoria> Listar();
    }
}
