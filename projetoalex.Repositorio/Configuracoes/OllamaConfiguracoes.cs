using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projetoalex.Dominio;
using Projetoalex.Dominio.Entidades;

namespace projetoalex.Repositorio.Configuracoes;

// aqui crio a tabela com o banco de dados 

public class OllamaConfiguracoes : IEntityTypeConfiguration<Ollama>
{
    public void Configure(EntityTypeBuilder<Ollama> builder)
    {
       builder.ToTable("Ollamas").HasKey(u => u.Id);

       builder.Property(nameof(Ollama.Id)).HasColumnName("Id");
       builder.Property(nameof(Ollama.Model)).HasColumnName("Model").IsRequired(true);
       builder.Property(nameof(Ollama.Prompt)).HasColumnName("Prompt").IsRequired(true);
       builder.Property(nameof(Ollama.Resposta)).HasColumnName("Resposta").IsRequired(true);
      
    }

 
}

    
