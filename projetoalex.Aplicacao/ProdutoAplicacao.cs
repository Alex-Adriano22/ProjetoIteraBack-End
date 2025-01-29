using Projetoalex.Dominio.Entidades;

namespace projetoalex.Aplicacao;
public class ProdutoAplicacao : IProdutosAplicacao
{
    readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoAplicacao(IProdutoRepositorio produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }

    public async Task<int> Criar(Produtos produtos)
    {
        if (produtos == null)
            throw new Exception("produtos não pode ser nulo.");



        return await _produtoRepositorio.Salvar(produtos);
    }

    public async Task Atualizar(Produtos produtos)
    {
        var produtoDominio = await _produtoRepositorio.Obter(produtos.Id, true);
        if (produtos == null)
            throw new Exception("Usuario não econtrado.");

        produtoDominio.Nome = produtos.Nome;
        produtoDominio.Preco = produtos.Preco;
        produtoDominio.Descricao = produtos.Descricao;


        await _produtoRepositorio.Atualizar(produtoDominio);

    }


    public async Task<Produtos> Obter(int produtoId, bool ativo)
    {
        var produtoDominio = await _produtoRepositorio.Obter(produtoId, ativo);

        if (produtoDominio == null)
            throw new Exception("Usuário não encontrado.");

        return produtoDominio;
    }


    public async Task Deletar(int produto)
    {
        var produtoDominio = await _produtoRepositorio.Obter(produto, true);

        if (produtoDominio == null)
            throw new Exception("Usuário não encontrado.");

        produtoDominio.Deletar();

        await _produtoRepositorio.Atualizar(produtoDominio);
    }

    public async Task Restaurar(int produtoId)
    {
        var produtosDominio = await _produtoRepositorio.Obter(produtoId, false);

        if (produtosDominio == null)
            throw new Exception("Usuário não encontrado.");

        produtosDominio.Restaurar();

        await _produtoRepositorio.Atualizar(produtosDominio);
    }

    public async Task<IEnumerable<Produtos>> Listar(bool ativo)
    {
        return await _produtoRepositorio.Listar(ativo);
    }




    #region Util


    #endregion
}