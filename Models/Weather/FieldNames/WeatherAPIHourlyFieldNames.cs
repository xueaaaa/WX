namespace WX.Models.Weather.FieldNames
{
    public static class WeatherAPIHourlyFieldNames
    {
        public const string TIME = "time";
        public const string TEMPERATURE_2M = "temperature_2m";
        public const string WIND_SPEED_10M = "wind_speed_10m";
        public const string UV_INDEX = "uv_index";
        public const string WEATHER_CODE = "weather_code";
        public const string RELATIVE_HUMIDITY_2M = "relative_humidity_2m";
        public const string APPARENT_TEMPERATURE = "apparent_temperature";
        public const string PRECIPITATION_PROBABILITY = "precipitation_probability";
        public const string PRECIPITATION = "precipitation";
        public const string SNOW_DEPTH = "snow_depth";
        public const string CLOUD_COVER = "cloud_cover";
        public const string SURFACE_PRESSURE = "surface_pressure";
        public const string VISIBILITY = "visibility";
        public const string WIND_GUSTS_10M = "wind_gusts_10m";
        public const string SUNSHINE_DURATION = "sunshine_duration";
        public const string IS_DAY = "is_day";

        public static readonly string[] All = new[]
        {
            TEMPERATURE_2M,
            WIND_SPEED_10M,
            UV_INDEX,
            WEATHER_CODE,
            RELATIVE_HUMIDITY_2M,
            APPARENT_TEMPERATURE,
            PRECIPITATION_PROBABILITY,
            PRECIPITATION,
            SNOW_DEPTH,
            CLOUD_COVER,
            SURFACE_PRESSURE,
            VISIBILITY,
            WIND_GUSTS_10M,
            SUNSHINE_DURATION,
            IS_DAY
        };
    }
}
