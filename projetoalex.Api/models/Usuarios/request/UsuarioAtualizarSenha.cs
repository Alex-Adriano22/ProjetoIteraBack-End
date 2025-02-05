namespace projetoalex.Api.models.request;

public class UsuarioAtualizarSenha
{
    public int Id { get; set; }
    public string Senha { get; set; }
    public string SenhaAntiga { get; set; }
}