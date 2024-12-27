using Projetoalex.Dominio.Entidades;

namespace projetoalex.Aplicacao;
public class UsuarioAplicacao : IUsuarioAplicacao
{
    readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task<int> Criar(Usuario usuario)
    {
        if (usuario == null)
            throw new Exception("Usuario não pode ser nulo.");

        if (string.IsNullOrEmpty(usuario.Senha))
            throw new Exception("Senha não pode ser nulo");

        ValidarInformacoesUsuario(usuario);

        return await _usuarioRepositorio.Salvar(usuario);
    }

    public async Task Atualizar(Usuario usuario)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuario.Id, true);
        if (usuario == null)
            throw new Exception("Usuario não econtrado.");

        usuarioDominio.Nome = usuario.Nome;
        usuarioDominio.Email = usuario.Email;
     


        ValidarInformacoesUsuario(usuario);

        await _usuarioRepositorio.Atualizar(usuarioDominio);

    }

    public async Task AtualizarSenha(Usuario usuario, string senhaAntiga)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuario.Id, true);

        if (usuario == null)
            throw new Exception("Usuario não econtrado.");

        if (usuarioDominio.Senha != senhaAntiga)
            throw new Exception("Senha antiga invalida.");

        usuarioDominio.Senha = usuario.Senha;

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task<Usuario> Obter(int usuarioId, bool ativo)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId, ativo);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado.");

        return usuarioDominio;
    }


    public async Task<Usuario> ObterPorEmail(string email)
    {
        var usuarioDominio = await _usuarioRepositorio.ObtePorEmail(email);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado.");

        return usuarioDominio;
    }

    public async Task Deletar(int usuarioId)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId, true);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado.");

        usuarioDominio.Deletar();

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task Restaurar(int usuarioId)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId, false);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado.");

        usuarioDominio.Restaurar();

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task<IEnumerable<Usuario>> Listar(bool ativo)
    {
        return await _usuarioRepositorio.Listar(ativo);
    }

    public async Task<Usuario> ObterSenhaEmail(string email, string senha)
    {
        var usuarioDominio = await _usuarioRepositorio.ObtePorEmail(email);

        if (usuarioDominio == null)
            throw new Exception("cadastro não encontrado.");


        if (usuarioDominio.Senha != senha)
            throw new Exception("Senha incorreta");

        return usuarioDominio;
    }

    #region Util
    private static void ValidarInformacoesUsuario(Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new Exception("Nome não pode ser nulo.");

        if (string.IsNullOrEmpty(usuario.Email))
            throw new Exception("E-mail não pode ser nulo.");
    }


    #endregion
}