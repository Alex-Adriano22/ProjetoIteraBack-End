using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projetoalex.Dominio.Entidades;

namespace projetoalex.Repositorio.Configuracoes;

// aqui crio a tabela com o banco de dados 

public class UsuariosConfiguracoes : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
       builder.ToTable("Usuarios").HasKey(u => u.Id);

       builder.Property(nameof(Usuario.Id)).HasColumnName("UsuarioId");
       builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").IsRequired(true);
       builder.Property(nameof(Usuario.Email)).HasColumnName("Email").IsRequired(true);
       builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").IsRequired(true);
       builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo").IsRequired(true);
    

       
    }
}

    
