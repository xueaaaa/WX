using System.Text.Json.Serialization;
using WX.Models.Weather.FieldNames;

namespace WX.Models.Weather.DTOs
{
    public class HourlyWeatherDTO
    {
        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.TIME)]
        public List<DateTime?> Time { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.TEMPERATURE_2M)]
        public List<float?> Temperature2m { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.RELATIVE_HUMIDITY_2M)]
        public List<float?> RelativeHumidity2m { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.APPARENT_TEMPERATURE)]
        public List<float?> ApparentTemperature { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.PRECIPITATION_PROBABILITY)]
        public List<float?> PrecipitationProbability { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.PRECIPITATION)]
        public List<float?> Precipitation { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.SNOW_DEPTH)]
        public List<float?> SnowDepth { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.WEATHER_CODE)]
        public List<WeatherInterpretationCode?> WeatherCode { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.SURFACE_PRESSURE)]
        public List<float?> SurfacePressure { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.CLOUD_COVER)]
        public List<float?> CloudCoverTotal { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.VISIBILITY)]
        public List<float?> Visibility { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.WIND_SPEED_10M)]
        public List<float?> WindSpeed10m { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.WIND_GUSTS_10M)]
        public List<float?> WindGusts10m { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.UV_INDEX)]
        public List<float?> UVIndex { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.IS_DAY)]
        public List<int?> IsDay { get; set; }

        [property: JsonPropertyName(WeatherAPIHourlyFieldNames.SUNSHINE_DURATION)]
        public List<float?> SunshineDuration { get; set; }
    }
}
