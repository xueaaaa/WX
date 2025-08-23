using WX.Models.Weather.FieldNames;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;
using WX.Converters;

namespace WX.Models.Weather
{
    [ObservableObject]
    public partial class DailyWeather
    {
        private readonly WICToColorConverter _wicToColorConverter;

        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TIME)]
        private DateOnly _time;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.WEATHER_CODE)]
        private WeatherInterpretationCode? _weatherCode;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TEMPERATURE_2M_MAX)]
        private float? _maximumTemperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TEMPERATURE_2M_MIN)]
        private float? _minimumTemperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TEMPERATURE_2M_MEAN)]
        private float? _meanTemperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.APPARENT_TEMPERATURE_MAX)]
        private float? _maximumApparentTemperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.APPARENT_TEMPERATURE_MIN)]
        private float? _minimumApparentTemperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.APPARENT_TEMPERATURE_MEAN)]
        private float? _meanApparentTemperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.SUNRISE)]
        private TimeOnly? _sunrise;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.SUNSET)]
        private TimeOnly? _sunset;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.DAYLIGHT_DURATION)]
        private TimeSpan? _daylightDuration;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.SUNSHINE_DURATION)]
        private float? _sunshineDuration;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.UV_INDEX_MAX)]
        private int? _UVIndex;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.PRECIPITATION_SUM)]
        private float? _precipitationSum;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.PRECIPITATION_HOURS)]
        private float? _precipitationHours;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.PRECIPITATION_PROBABILITY_MAX)]
        private float? _precipitationProbabilityMax;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.WIND_SPEED_10M_MAX)]
        private float? _maximumWindSpeed;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.WIND_GUSTS_10M_MAX)]
        private float? _maximumWindGusts;

        public object? WeatherIconColor
        {
            get => _wicToColorConverter.Convert(WeatherCode, null, null, null);
        }

        public DailyWeather()
        {
            _wicToColorConverter = new();
        }
    }
}
