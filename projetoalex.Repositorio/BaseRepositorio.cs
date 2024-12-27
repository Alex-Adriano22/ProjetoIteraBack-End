public abstract class BaseRepositorio
{
    protected readonly ProjetoalexContexto _contexto;
    
    protected BaseRepositorio(ProjetoalexContexto  contexto)
    {
        _contexto = contexto;
    }
}