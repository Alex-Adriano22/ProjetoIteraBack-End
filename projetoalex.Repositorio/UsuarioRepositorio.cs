
using Microsoft.EntityFrameworkCore;
using Projetoalex.Dominio.Entidades;

namespace DataAccess.Repositorio;

public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
{
    public UsuarioRepositorio(ProjetoalexContexto contexto) : base (contexto)
    {
        
    }

   public async Task Atualizar(Usuario usuario)
{
    try
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Erro ao atualizar: {ex.InnerException?.Message ?? ex.Message}");
        throw; // Re-lança a exceção para depuração adicional
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro inesperado: {ex.Message}");
        throw;
    }
}


    public async Task<IEnumerable<Usuario>> Listar(bool ativo)
    {
        return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
    }

    public async Task<Usuario> ObtePorEmail(string email)
    {
        return await _contexto.Usuarios
                    .Where(u => u.Email == email)
                    .Where(u => u.Ativo)
                    .FirstOrDefaultAsync();
    }

    public async Task<Usuario> Obter(int usuarioId, bool ativo)
    {
        return await _contexto.Usuarios
                    .Where(u => u.Id == usuarioId)
                    .Where(u => u.Ativo == ativo)
                    .FirstOrDefaultAsync();
    }

    public  async Task<int> Salvar(Usuario usuarios)
    {
        _contexto.Usuarios.Add(usuarios);
        await _contexto.SaveChangesAsync();

        return usuarios.Id;
    }
}