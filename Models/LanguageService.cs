using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP2_DetectionLangue.Models
{
    public class LanguageService
    {
        private readonly ApiClient _apiClient;

        public LanguageService()
        {
            _apiClient = new ApiClient("https://ws.detectlanguage.com/v3/");
        }

        public async Task<LanguageCandidate[]> DetectLanguageAsync(string text, string token)
        {
            _apiClient.SetHttpRequestHeader("Authorization", $"Bearer {token}");

            var requestJson = JsonSerializer.Serialize(new { q = text });
            var responseJson = await _apiClient.RequetePostAsync("detect", requestJson);

            return JsonSerializer.Deserialize<LanguageCandidate[]>(responseJson);
        }
    }

    public class LanguageCandidate
    {
        public string language { get; set; }
        public float score { get; set; }
    }
}
