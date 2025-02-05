using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Projetoalex.Dominio
{
    public class Ollama
    {
        // [JsonIgnore]
        public string Model { get; set; }
        public string Prompt { get; set; }

        // public bool Stream { get; set; }

        // public Ollama()
        // {
        //     Model = "phi3";
        // }

        // public Ollama()
        // {
        //     Stream = false;
        // }
    }


}