using Projetoalex.Dominio.Entidades;

// contrato que nao pode ser quebrado metodos basicos
public interface IUsuarioRepositorio
{
    Task<int> Salvar(Usuario usuarios);
    Task Atualizar (Usuario usuarios);
    Task<Usuario> Obter(int usuarioId, bool ativo);
    Task<Usuario> ObtePorEmail(string email);
    Task<IEnumerable<Usuario>> Listar(bool ativo);
}