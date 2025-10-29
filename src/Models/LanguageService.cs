using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageDetector.Models
{
    public class LanguageService
    {
        private readonly ApiClient _apiClient;
        private Dictionary<string, string> _languageMap;
        public string GetLanguageName(string code)
        {
            if (_languageMap == null) return code; // si la liste n'est pas encore chargée
            return _languageMap.ContainsKey(code) ? _languageMap[code] : code;
        }


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

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<TokenStatus>(jsonResponse, options);
        }

        public async Task LoadSupportedLanguagesAsync(string token)
        {
            _apiClient.SetHttpRequestHeader("Authorization", $"Bearer {token}");
            var jsonResponse = await _apiClient.RequeteGetAsync("/languages");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // L’API retourne directement un tableau de langues [{code, name}, ...]
            var languages = JsonSerializer.Deserialize<List<LanguageInfo>>(jsonResponse, options);

            _languageMap = new Dictionary<string, string>();
            if (languages != null)
            {
                foreach (var lang in languages)
                {
                    _languageMap[lang.Code] = lang.Name.ToUpper();
                }
            }
        }
               
    }
}
