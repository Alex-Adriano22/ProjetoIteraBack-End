
using Projetoalex.Dominio.Entidades;

namespace projetoalex.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        Task<int> Criar(Usuario usuario);
        Task AtualizarSenha(Usuario usuario, string novaSenha);
        Task Atualizar(Usuario usuario);
        Task Deletar(int usuarioId);
        Task Restaurar(int usuarioId);
        Task<IEnumerable<Usuario>> Listar(bool ativo);
        Task<Usuario> Obter(int usuarioId, bool ativo);
        Task<Usuario> ObterPorEmail(string email);
        Task<Usuario> ObterSenhaEmail(string email, string senha);
    }
}