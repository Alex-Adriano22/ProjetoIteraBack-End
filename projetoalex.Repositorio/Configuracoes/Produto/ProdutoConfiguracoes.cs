using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projetoalex.Dominio.Entidades;

namespace projetoalex.Repositorio.Configuracoes;

// aqui crio a tabela com o banco de dados 

public class ProdutoConfiguracoes : IEntityTypeConfiguration<Produtos>
{ 

    public void Configure(EntityTypeBuilder<Produtos> builder)
    {
        builder.ToTable("Produtos").HasKey(u => u.Id);

        builder.Property(nameof(Produtos.Id)).HasColumnName("ProdutoId");
        builder.Property(nameof(Produtos.Nome)).HasColumnName("Nome").IsRequired(true);
        builder.Property(nameof(Produtos.Preco)).HasColumnName("Preco").IsRequired(true);
        builder.Property(nameof(Produtos.Ativo)).HasColumnName("Ativo").IsRequired(true);
        builder.Property(nameof(Produtos.Descricao)).HasColumnName("Descricao").IsRequired(true);
      
    }
}


