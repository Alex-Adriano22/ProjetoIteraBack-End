using Microsoft.EntityFrameworkCore;
using projetoalex.Repositorio;
using Projetoalex.Dominio;
using Projetoalex.Dominio.Entidades;

using System.Threading.Tasks;

namespace Projetoalex.Repositorio
{
    public class OllamaRepositorio : IOllamaRepositorio
    {
        private readonly ProjetoalexContexto _contexto;


        public OllamaRepositorio(ProjetoalexContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Salvar(Ollama ollama)
        {
            await _contexto.Ollamas.AddAsync(ollama);
            await _contexto.SaveChangesAsync();

            return ollama.Id;
        }

        public async Task SalvarHistoricoAsync(string model, string prompt, string resposta)
        {
            var historico = new Ollama
            {
                Model = model,   // Qual modelo foi usado (ex: "phi3")
                Prompt = prompt, // Qual foi a pergunta do usuário
                Resposta = resposta // O que a IA respondeu
            };

            await _contexto.Ollamas.AddAsync(historico);
            await _contexto.SaveChangesAsync();
        }
    }
}
