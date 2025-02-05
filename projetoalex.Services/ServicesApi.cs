using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace projetoalex.Services
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;

        public OllamaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OllamaResponse> GenerateTextAsync(string model, string prompt)
        {
            var url = "http://localhost:8000/api/generate";  // URL da sua API FastAPI

            var requestData = new 
            {
                model = model,
                prompt = prompt
            };

            var jsonData = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OllamaResponse>(responseData);
                return result;  // Retorna o objeto OllamaResponse
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
        }
    }

 
}
