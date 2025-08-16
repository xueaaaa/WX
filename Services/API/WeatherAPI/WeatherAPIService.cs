using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using System.Text.Json;
using WX.Models.Weather;
using WX.Models.Weather.DTOs;
using WX.Models.Weather.FieldNames;
using WX.Services.API.Interfaces;
using WX.Services.API.WeatherAPI.FieldNames;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;

namespace WX.Services.API.WeatherAPI
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

            RegisterParameter(WeatherAPIFieldNames.FORECAST_DAYS, "14");
            RegisterParameter(WeatherAPIFieldNames.PAST_DAYS, "2");
            RegisterParameter(WeatherAPIFieldNames.TEMPERATURE_UNIT, _preferencesService.Get(PreferencesNames.TEMPERATURE_UNIT, Units.Celsius.ToStrValue()));
            RegisterParameter(WeatherAPIFieldNames.WIND_SPEED_UNIT, _preferencesService.Get(PreferencesNames.WIND_SPEED_UNIT, Units.MetersSecond.ToStrValue()));
            RegisterParameter(WeatherAPIFieldNames.PRECIPITATION_UNIT, _preferencesService.Get(PreferencesNames.PRECIPITATION_UNIT, Units.Millimeters.ToStrValue()));
            RegisterParameter(WeatherAPIFieldNames.TIMEZONE, "auto");

            var hourlyString = string.Join(",", WeatherAPIHourlyFieldNames.All);
            var dailyString = string.Join(",", WeatherAPIDailyFieldNames.All);
            RegisterParameter(WeatherAPIFieldNames.HOURLY, hourlyString);
            RegisterParameter(WeatherAPIFieldNames.DAILY, dailyString);
        }

        public async Task<IEnumerable<WeatherData>> FetchData()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(CombinedURL);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(data);
            var hourlyDTO = doc.RootElement.GetProperty(WeatherAPIWeatherDataFieldNames.HOURLY).Deserialize<HourlyWeatherDTO>();
            var dailyDTO = doc.RootElement.GetProperty(WeatherAPIWeatherDataFieldNames.DAILY).Deserialize<DailyWeatherDTO>();

            var wData = new WeatherData();
            var hourly = new ObservableCollection<HourlyWeather>();
            for (int i = 0; i < hourlyDTO!.Time.Count; i++)
            {
                var entity = new HourlyWeather()
                {
                    Time = hourlyDTO.Time[i],
                    Temperature2m = hourlyDTO.Temperature2m[i],
                    RelativeHumidity2m = hourlyDTO.RelativeHumidity2m[i],
                    ApparentTemperature = hourlyDTO.ApparentTemperature[i],
                    PrecipitationProbability = hourlyDTO.PrecipitationProbability[i],
                    Precipitation = hourlyDTO.Precipitation[i],
                    SnowDepth = hourlyDTO.SnowDepth[i],
                    WeatherCode = hourlyDTO.WeatherCode[i],
                    SurfacePressure = hourlyDTO.SurfacePressure[i],
                    CloudCoverTotal = hourlyDTO.CloudCoverTotal[i],
                    Visibility = hourlyDTO.Visibility[i],
                    WindSpeed10m = hourlyDTO.WindSpeed10m[i],
                    WindGusts10m = hourlyDTO.WindGusts10m[i],
                    UVIndex = (int)Math.Round(hourlyDTO.UVIndex[i]!.Value),
                    IsDay = Convert.ToBoolean(hourlyDTO.IsDay[i]),
                    SunshineDuration = hourlyDTO.SunshineDuration[i]
                };

                hourly.Add(entity);
            }

            var daily = new ObservableCollection<DailyWeather>();
            for (int i = 0; i < dailyDTO!.Time.Count; i++)
            {
                var entity = new DailyWeather()
                {
                    Time = DateOnly.FromDateTime(dailyDTO.Time[i]),
                    WeatherCode = dailyDTO.WeatherCode[i],
                    MaximumTemperature2m = dailyDTO.MaximumTemperature2m[i],
                    MinimumTemperature2m = dailyDTO.MinimumTemperature2m[i],
                    MeanTemperature2m = dailyDTO.MeanTemperature2m[i],
                    MaximumApparentTemperature2m = dailyDTO.MaximumApparentTemperature2m[i],
                    MinimumApparentTemperature2m = dailyDTO.MinimumApparentTemperature2m[i],
                    MeanApparentTemperature2m = dailyDTO.MeanApparentTemperature2m[i],
                    Sunrise = TimeOnly.Parse(dailyDTO.Sunrise[i]),
                    Sunset = TimeOnly.Parse(dailyDTO.Sunset[i]),
                    DaylightDuration = dailyDTO.DaylightDuration[i],
                    SunshineDuration = dailyDTO.SunshineDuration[i],
                    UVIndex = (int)Math.Round(dailyDTO.UVIndex[i]!.Value),
                    PrecipitationSum = dailyDTO.PrecipitationSum[i],
                    PrecipitationHours = dailyDTO.PrecipitationHours[i],
                    PrecipitationProbabilityMax = dailyDTO.PrecipitationProbabilityMax[i],
                    MaximumWindSpeed = dailyDTO.MaximumWindSpeed[i],
                    MaximumWindGusts = dailyDTO.MaximumWindGusts[i]
                };

                daily.Add(entity);
            }

            wData.Hourly = hourly;
            wData.Daily = daily;

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
    }
}
