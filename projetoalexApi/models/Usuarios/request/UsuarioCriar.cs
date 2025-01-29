using Projetoalex.Dominio.Entidades;

namespace projetoalex.Api.models.request;

public class UsuarioCriar
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuarioEnum Tipo { get; set; }
}