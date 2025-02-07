using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Projetoalex.Dominio
{
    public class Ollama
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Prompt { get; set; }
        public string Resposta { get; set; }

    }


}