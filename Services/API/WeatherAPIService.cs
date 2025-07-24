using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using WX.Models.Weather;
using WX.Models.Weather.FieldNames;
using WX.Services.API.Interfaces;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;

namespace WX.Services.API
{
    public class WeatherAPIService : IAPIService<WeatherData>
    {
        private readonly IPreferencesService _preferencesService;

        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }

        public WeatherAPIService(IOptions<WeatherAPIOptions> options)
        {
            BaseURL = options.Value.BaseURL;
            CombinedURL = options.Value.BaseURL;
            _preferencesService = options.Value.PreferencesService;

            SetDefaultParameters();
        }

        public void SetDefaultParameters()
        {
            UnregisterParameters();

            RegisterParameter("forecast_days", "14");
            RegisterParameter("past_days", "2");
            RegisterParameter("temperature_unit", _preferencesService.Get(PreferencesNames.TEMPERATURE_UNIT, Units.Celsius.ToStrValue()));
            RegisterParameter("wind_speed_unit", _preferencesService.Get(PreferencesNames.WIND_SPEED_UNIT, Units.MetersHour.ToStrValue()));
            RegisterParameter("precipitation_unit", _preferencesService.Get(PreferencesNames.PRECIPITATION_UNIT, Units.Millimeters.ToStrValue()));
            RegisterParameter("timezone", "auto");

            var hourlyString = string.Join(",", WeatherAPIHourlyFieldNames.All);
            var dailyString = string.Join(",", WeatherAPIDailyFieldNames.All);
            RegisterParameter("hourly", hourlyString);
            RegisterParameter("daily", dailyString);
        }

        public async Task<IEnumerable<WeatherData>> FetchData()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(CombinedURL);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(data);
            var hourlyElement = doc.RootElement.GetProperty(WeatherAPIWeatherDataFieldNames.HOURLY);
            var dailyElement = doc.RootElement.GetProperty(WeatherAPIWeatherDataFieldNames.DAILY);

            var wData = new WeatherData();
            wData.Hourly = MapProperties<HourlyWeather>(hourlyElement);
            wData.Daily = MapProperties<DailyWeather>(dailyElement);

            return [wData];
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

        private ObservableCollection<T> MapProperties<T>(JsonElement element) where T : class, new()
        {
            var res = new ObservableCollection<T>();

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p => p.GetCustomAttribute<JsonPropertyNameAttribute>() != null)
                                 .ToList();

            var dataArrays = new Dictionary<string, JsonElement>();
            foreach (var property in element.EnumerateObject())
                dataArrays[property.Name] = property.Value;

            if (!dataArrays.TryGetValue(WeatherAPIHourlyFieldNames.TIME, out var timeArray)) 
                return res;
            int count = timeArray.GetArrayLength();

            for (int i = 0; i < count; i++)
            {
                var item = new T();

                foreach (var prop in props)
                {
                    var attr = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
                    var jsonField = attr.Name;

                    if (!dataArrays.TryGetValue(jsonField, out var jsonArray)) continue;
                    if (jsonArray.ValueKind != JsonValueKind.Array || i >= jsonArray.GetArrayLength()) continue;

                    var valueElement = jsonArray[i];

                    object? value = prop.PropertyType switch
                    {
                        Type t when t == typeof(float) => valueElement.GetSingle(),
                        Type t when t == typeof(int) => valueElement.GetInt32(),
                        Type t when t == typeof(bool) => valueElement.GetInt32() == 1,
                        Type t when t == typeof(DateTime) => DateTime.Parse(valueElement.GetString()!),
                        Type t when t == typeof(DateOnly) => DateOnly.Parse(valueElement.GetString()!),
                        Type t when t == typeof(TimeOnly) => TimeOnly.Parse(valueElement.GetString()!),
                        Type t when t.IsEnum => Enum.ToObject(t, valueElement.GetInt32()),
                        _ => null
                    };

                    if (value != null)
                        prop.SetValue(item, value);
                }

                res.Add(item);
            }

            return res;
        }
    }
}
