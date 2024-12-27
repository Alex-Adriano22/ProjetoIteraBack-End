

using Microsoft.EntityFrameworkCore;
using projetoalex.Repositorio.Configuracoes;
using Projetoalex.Dominio.Entidades;

public class ProjetoalexContexto : DbContext
{
    private readonly DbContextOptions _options;

    public DbSet<Usuario> Usuarios { get; set; }


    public ProjetoalexContexto() { }

    public ProjetoalexContexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
           optionsBuilder.UseSqlServer("Server=DESKTOP-58UEHOH\\SQLEXPRESS02;Database=Alex.Santos;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuariosConfiguracoes());
    }
}