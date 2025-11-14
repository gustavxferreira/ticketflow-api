using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using TicketFlowApi.Configuration;
using TicketFlowApi.Services.Interfaces;

namespace TicketFlowApi.Services
{
    public class GeminiAIService : IAIService
    {
        private readonly GeminiSettings _settings;
        private readonly HttpClient _httpClient;

        public GeminiAIService(IOptions<GeminiSettings> options)
        {
            _settings = options.Value;
            _httpClient = new HttpClient();
        }

        public async Task<string> Prompt(string prompt)
        {
            string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/{_settings.ModelId}:generateContent?key={_settings.ApiKey}";

            var payload = new
            {
                contents = new[]
                {
                    new {
                        role = "user",
                        parts = new[] {
                            new { text = prompt }
                        }
                    }
                },
                system_instruction = new
                {
                    parts = new[] {
                        new { text = """
                            Você é um assistente de um sistema interno de chamados técnicos.
                            Suas respostas devem ser:
                            - Objetivas e curtas (até 300 palavras)
                            - Escritas em **Markdown** válido e seguro
                            - Sem incluir nenhum conteúdo executável (como scripts, HTML perigoso ou código que possa causar danos)
                            - Sem links externos, apenas texto descritivo
                            - Evite caracteres de escape (como \\n, \\t, \\r).
                            - A resposta deve ser texto simples e formatado apenas com Markdown.
                            - Se precisar incluir código, use blocos Markdown com três crases (```) e linguagem especificada.
                            - Se precisar incluir imagens, use URLs diretas para imagens hospedadas em serviços seguros.
                            - Se precisar incluir vídeos, use URLs diretas para vídeos hospedados em serviços seguros.                            
                            Evite linguagem ofensiva, dados sensíveis, ou instruções que envolvam segurança do sistema.
                        
                            Gere a resposta final apenas em Markdown, sem tags HTML.
                            """ }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            string resultJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Erro Gemini: {response.StatusCode} - {resultJson}");

            var parsed = JsonConvert.DeserializeObject<GeminiResponse>(resultJson);
            var text = parsed?.Candidates?.FirstOrDefault()
                ?.Content?.Parts?.FirstOrDefault()?.Text;

            return text ?? "[Sem resposta do modelo]";
        }
    }

    public class GeminiResponse
    {
        public List<Candidate>? Candidates { get; set; }
    }

    public class Candidate
    {
        public Content? Content { get; set; }
    }

    public class Content
    {
        public List<Part>? Parts { get; set; }
    }

    public class Part
    {
        public string? Text { get; set; }
    }
}
