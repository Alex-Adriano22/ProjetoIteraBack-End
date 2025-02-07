using Microsoft.AspNetCore.Mvc;
using projetoalex.Aplicacao;
using projetoalex.Services;
using Projetoalex.Dominio;

namespace projeto360.Api
{
    [ApiController]
    [Route("api/[controller]")]

    public class OllamaController : ControllerBase
    {

        private readonly OllamaService _ollamaService;
        private readonly IOllamaAplicacao _ollamaAplicacao;

        public OllamaController(OllamaService ollamaService, IOllamaAplicacao ollamaAplicacao)
        {
            _ollamaService = ollamaService;
            _ollamaAplicacao = ollamaAplicacao;
        }


        [HttpPost("gerador")]
        public async Task<IActionResult> GeradorTexto([FromBody] OllamaRequest request)
        {
            try
            {
                var model = "phi3";
                // Obtendo a resposta da API
                var resultado = await _ollamaService.GenerateTextAsync(model, request.prompt);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Geradortexto")]
        public async Task<IActionResult> Geradortexto([FromBody] OllamaRequest request)
        {
            try
            {
                var model = "phi3";
                // Obtendo a resposta da API
                var resultado = await _ollamaService.GenerateTextAsync(model, request.prompt);

                var ollama = new Ollama()
                {
                    Prompt = request.prompt,
                    Model = model,
                    Resposta = resultado.Response
                    
                };

                 await _ollamaAplicacao.SalvarHistoricoAsync(ollama);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

