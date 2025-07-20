using WX.Services.API.Interfaces;

namespace WX.Services.API
{
    public class LocationAPISender : IAPISender
    {
        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }
        
        public LocationAPISender(string baseURL)
        {
            BaseURL = baseURL;
            CombinedURL = baseURL;
        }

        public async Task<string> Send()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(CombinedURL);
            string content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public void RegisterParameter(string parameterName, string parameterValue)
        {
            if (CombinedURL[-1] == BaseURL[-1])
                CombinedURL += $"{parameterName}={parameterValue}";
            else
                CombinedURL += $"&{parameterName}={parameterValue}";
        }

        public void UnregisterParameters() =>
            CombinedURL = BaseURL;
    }
}
