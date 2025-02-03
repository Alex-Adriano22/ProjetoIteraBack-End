
using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using projetoalex.Repositorio.Migrations;
using Projetoalex.Dominio.Entidades;

namespace DataAccess.Repositorio;

public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositorio
{
    public ProdutoRepositorio(ProjetoalexContexto contexto) : base(contexto)
    {

    }

    public async Task Atualizar(Produtos produtos)

    {
        _contexto.produtos.Update(produtos);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<Produtos>> Listar(bool ativo)
    {
        return await _contexto.produtos.Where(u => u.Ativo == ativo).ToListAsync();
    }
    public async Task<Produtos> Obter(int produtoId, bool ativo)
    {
        return await _contexto.produtos
                    .Where(p => p.Id == produtoId && p.Ativo == ativo)
                    .FirstOrDefaultAsync();
    }

    public async Task<int> Salvar(Produtos produtos)
    {
        _contexto.produtos.Add(produtos);
        await _contexto.SaveChangesAsync();

        return produtos.Id;
    }
    public async Task<Produtos> AtualizarProdutoAsyncPro(int produtoId, string nome, string descricao, decimal preco )
    {
       
        var parametros = new { ProdutoId = produtoId, Nome = nome, Descricao = descricao, Preco = preco };

        
        await _contexto.Database.GetDbConnection().ExecuteAsync(
            "Atualizarproduto", 
            parametros, 
            commandType: System.Data.CommandType.StoredProcedure 
        );

       
        return await _contexto.produtos
            .FirstOrDefaultAsync(p => p.Id == produtoId); 
    }






}