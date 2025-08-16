namespace WX.Models.Weather.FieldNames
{
    public static class WeatherAPIDailyFieldNames
    {
        public const string TIME = "time";
        public const string WEATHER_CODE = "weather_code";
        public const string TEMPERATURE_2M_MAX = "temperature_2m_max";
        public const string TEMPERATURE_2M_MIN = "temperature_2m_min";
        public const string TEMPERATURE_2M_MEAN = "temperature_2m_mean";
        public const string APPARENT_TEMPERATURE_MAX = "apparent_temperature_max";
        public const string APPARENT_TEMPERATURE_MIN = "apparent_temperature_min";
        public const string APPARENT_TEMPERATURE_MEAN = "apparent_temperature_mean";
        public const string SUNRISE = "sunrise";
        public const string SUNSET = "sunset";
        public const string DAYLIGHT_DURATION = "daylight_duration";
        public const string SUNSHINE_DURATION = "sunshine_duration";
        public const string UV_INDEX_MAX = "uv_index_max";
        public const string PRECIPITATION_SUM = "precipitation_sum";
        public const string PRECIPITATION_HOURS = "precipitation_hours";
        public const string PRECIPITATION_PROBABILITY_MAX = "precipitation_probability_max";
        public const string WIND_SPEED_10M_MAX = "wind_speed_10m_max";
        public const string WIND_GUSTS_10M_MAX = "wind_gusts_10m_max";

        public static readonly string[] All = new[]
        {
            WEATHER_CODE,
            TEMPERATURE_2M_MAX,
            TEMPERATURE_2M_MIN,
            TEMPERATURE_2M_MEAN,
            APPARENT_TEMPERATURE_MAX,
            APPARENT_TEMPERATURE_MIN,
            APPARENT_TEMPERATURE_MEAN,
            SUNRISE,
            SUNSET,
            DAYLIGHT_DURATION,
            SUNSHINE_DURATION,
            UV_INDEX_MAX,
            PRECIPITATION_SUM,
            PRECIPITATION_HOURS,
            PRECIPITATION_PROBABILITY_MAX,
            WIND_SPEED_10M_MAX,
            WIND_GUSTS_10M_MAX
        };
    }
}
