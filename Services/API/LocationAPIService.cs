using WX.Services.API.Interfaces;
using System.Text.Json;
using WX.Services.Preferences.Interfaces;
using Location = WX.Models.Location.Location;
using System.Diagnostics;

namespace WX.Services.API
{
    public class LocationAPIService : IAPIService<Location>
    {
        private IPreferencesService _preferencesService;

        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }

        public LocationAPIService(string baseURL, IPreferencesService preferencesService)
        {
            BaseURL = baseURL;
            CombinedURL = baseURL;
            _preferencesService = preferencesService;

            SetDefaultParameters();
        }

        public void SetDefaultParameters()
        {
            UnregisterParameters();
            RegisterParameter("count", "10");
            RegisterParameter("format", "json");
            RegisterParameter("language", _preferencesService.GetLanguage());
        }

        public async Task<IEnumerable<Location>> FetchData()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(CombinedURL);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(data);
            var resultsElement = doc.RootElement.GetProperty("results");

            var result = JsonSerializer.Deserialize<IEnumerable<Location>>(resultsElement.GetRawText());

            return result;
        }

        public void RegisterParameter(string parameterName, string parameterValue)
        {
            if (CombinedURL == BaseURL)
                CombinedURL += $"{parameterName}={parameterValue}";
            else
                CombinedURL += $"&{parameterName}={parameterValue}";
        }

        public void UnregisterParameters() =>
            CombinedURL = BaseURL;
    }
}
