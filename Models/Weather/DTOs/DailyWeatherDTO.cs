using System.Text.Json.Serialization;
using WX.Models.Weather.FieldNames;

namespace WX.Models.Weather.DTOs
{
    public class DailyWeatherDTO
    {
        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TIME)]
        public List<DateTime> Time { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.WEATHER_CODE)]
        public List<WeatherInterpretationCode?> WeatherCode { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TEMPERATURE_2M_MAX)]
        public List<float?> MaximumTemperature2m { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.TEMPERATURE_2M_MIN)]
        public List<float?> MinimumTemperature2m { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.APPARENT_TEMPERATURE_MAX)]
        public List<float?> MaximumApparentTemperature2m { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.APPARENT_TEMPERATURE_MIN)]
        public List<float?> MinimumApparentTemperature2m { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.SUNRISE)]
        public List<string?> Sunrise { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.SUNSET)]
        public List<string?> Sunset { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.DAYLIGHT_DURATION)]
        public List<float?> DaylightDuration { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.SUNSHINE_DURATION)]
        public List<float?> SunshineDuration { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.UV_INDEX_MAX)]
        public List<decimal?> UVIndex { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.PRECIPITATION_SUM)]
        public List<float?> PrecipitationSum { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.PRECIPITATION_HOURS)]
        public List<float?> PrecipitationHours { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.PRECIPITATION_PROBABILITY_MAX)]
        public List<float?> PrecipitationProbabilityMax { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.WIND_SPEED_10M_MAX)]
        public List<float?> MaximumWindSpeed { get; set; }

        [property: JsonPropertyName(WeatherAPIDailyFieldNames.WIND_GUSTS_10M_MAX)]
        public List<float?> MaximumWindGusts { get; set; }
    }
}
