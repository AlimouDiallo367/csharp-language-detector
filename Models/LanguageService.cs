using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

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

            var jsonRequest = JsonSerializer.Serialize(new { q = text });
            var jsonResponse = await _apiClient.RequetePostAsync("/detect", jsonRequest);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<LanguageCandidate[]>(jsonResponse, options)
                   ?? Array.Empty<LanguageCandidate>();
        }

        public async Task<TokenStatus?> GetTokenStatusAsync(string token)
        {
            _apiClient.SetHttpRequestHeader("Authorization", $"Bearer {token}");
            
            var jsonResponse = await _apiClient.RequeteGetAsync("/account/status");
            //MessageBox.Show(jsonResponse);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<TokenStatus>(jsonResponse, options);
        }
    }

}
