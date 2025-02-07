using Projetoalex.Dominio;

namespace projetoalex.Repositorio;

public interface IOllamaRepositorio
{
    Task SalvarHistoricoAsync(string model, string prompt, string response);
    Task<int> Salvar(Ollama ollama);
}