using Projetoalex.Dominio;

namespace projetoalex.Aplicacao;

public interface IOllamaAplicacao

{
    Task<int> SalvarHistoricoAsync(Ollama ollama);

}