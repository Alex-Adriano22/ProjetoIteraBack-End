
using Projetoalex.Dominio.Entidades;

namespace projetoalex.Aplicacao
{
    public interface IProdutosAplicacao
    {
        Task<int> Criar(Produtos Produtos);
        Task Atualizar(Produtos Produtos);
        Task Deletar(int produtoId);
        Task Restaurar(int produtoId);
        Task<IEnumerable<Produtos>> Listar(bool ativo);
        Task<Produtos> Obter(int produtoId, bool ativo);

        Task AtualizarProdutoAsync(int produtoId, string nome, string descricao, decimal Preco);
    }
}