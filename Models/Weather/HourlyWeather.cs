using CommunityToolkit.Mvvm.ComponentModel;
using WX.Models.Weather.FieldNames;
using System.Text.Json.Serialization;
using WX.Converters;

namespace WX.Models.Weather
{
    [ObservableObject]
    public partial class HourlyWeather
    {
        private readonly WICToColorConverter _wicToColorConverter;

        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.TIME)]
        private DateTime? _time;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.TEMPERATURE_2M)]
        private float? _temperature2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.RELATIVE_HUMIDITY_2M)]
        private float? _relativeHumidity2m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.APPARENT_TEMPERATURE)]
        private float? _apparentTemperature;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.PRECIPITATION_PROBABILITY)]
        private float? _precipitationProbability;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.PRECIPITATION)]
        private float? _precipitation;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.SNOW_DEPTH)]
        private float? _snowDepth;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.WEATHER_CODE)]
        private WeatherInterpretationCode? _weatherCode;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.SURFACE_PRESSURE)]
        private float? _surfacePressure;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.CLOUD_COVER)]
        private float? _cloudCoverTotal;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.VISIBILITY)]
        private float? _visibility;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.WIND_SPEED_10M)]
        private float? _windSpeed10m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.WIND_GUSTS_10M)]
        private float? _windGusts10m;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.UV_INDEX)]
        private int? _UVIndex;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.IS_DAY)]
        private bool _isDay;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.SUNSHINE_DURATION)]
        private float? _sunshineDuration;

        public object? WeatherIconColor
        {
            get => _wicToColorConverter.Convert(WeatherCode, null, null, null);
        }

        public HourlyWeather()
        {
            _wicToColorConverter = new();
        }
    }
}
