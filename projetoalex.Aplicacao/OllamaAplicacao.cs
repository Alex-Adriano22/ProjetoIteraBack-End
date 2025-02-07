using Projetoalex.Dominio.Entidades;
using projetoalex.Aplicacao;
using projetoalex.Repositorio;
using Projetoalex.Dominio;

namespace projetoalex.Aplicacao;
public class OllamaAplicacao : IOllamaAplicacao
{   
     readonly  IOllamaRepositorio _ollamaRepositorio;
    public OllamaAplicacao(IOllamaRepositorio  ollamaRepositorio)
    {
        _ollamaRepositorio = ollamaRepositorio;
    }
    public async Task<int> SalvarHistoricoAsync(Ollama ollama)
    {
         return await _ollamaRepositorio.Salvar(ollama);

    }
}
