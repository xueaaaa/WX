using WX.Services.API.Interfaces;
using System.Text.Json;
using WX.Services.Preferences.Interfaces;
using Location = WX.Models.Location.Location;
using Microsoft.Extensions.Options;
using WX.Services.API.LocationAPI.FieldNames;

namespace WX.Services.API.LocationAPI
{
    public class LocationAPIService : IAPIService<Location>
    {
        private IPreferencesService _preferencesService;

        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }

        public LocationAPIService(IOptions<LocationAPIOptions> options)
        {
            BaseURL = options.Value.BaseURL;
            CombinedURL = options.Value.BaseURL;
            _preferencesService = options.Value.PreferencesService;

            SetDefaultParameters();
        }

        public void SetDefaultParameters()
        {
            UnregisterParameters();

            RegisterParameter(LocationAPIFieldNames.COUNT, "10");
            RegisterParameter(LocationAPIFieldNames.FORMAT, "json");
            RegisterParameter(LocationAPIFieldNames.LANGUAGE, _preferencesService.GetLanguage().TwoLetterISOLanguageName);
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
