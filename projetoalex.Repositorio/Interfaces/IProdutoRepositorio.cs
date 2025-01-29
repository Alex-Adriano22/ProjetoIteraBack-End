using Projetoalex.Dominio.Entidades;

// contrato que nao pode ser quebrado metodos basicos
public interface IProdutoRepositorio
{
    Task<int> Salvar(Produtos produtos);
    Task Atualizar (Produtos produtos);
    Task<Produtos> Obter(int produtosId, bool ativo);
    Task<IEnumerable<Produtos>> Listar(bool ativo);
}