using Microsoft.AspNetCore.Mvc;
using projetoalex.Services;
using Projetoalex.Dominio;

namespace projeto360.Api
{
    [ApiController]
    [Route("api/[controller]")]

    public class OllamaController : ControllerBase
    {

        private readonly OllamaService _ollamaService;

        public OllamaController(OllamaService ollamaService)
        {
            _ollamaService = ollamaService;
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


    }
}

