using System.Globalization;
using WX.Models.Weather;
using WX.Models.Weather.FieldNames;

namespace WX.Converters
{
    public class WICToIconConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not WeatherInterpretationCode)
                return MaterialDesignIconNames.NOT_FOUND + ".svg";

            var val = (WeatherInterpretationCode)value;

            switch (val)
            {
                case WeatherInterpretationCode.ClearSky:
                    return MaterialDesignIconNames.CLEAR_SKY + ".svg";
                case WeatherInterpretationCode.MainlyClear:
                    return MaterialDesignIconNames.PARTLY_CLOUDY + ".svg";
                case WeatherInterpretationCode.PartlyCloudy:
                    return MaterialDesignIconNames.PARTLY_CLOUDY + ".svg";
                case WeatherInterpretationCode.Overcast:
                    return MaterialDesignIconNames.OVERCAST + ".svg";
                case WeatherInterpretationCode.Fog:
                    return MaterialDesignIconNames.FOG + ".svg";
                case WeatherInterpretationCode.DepositingRimeFog:
                    return MaterialDesignIconNames.DEPOSITING_RIME_FOG + ".svg";
                case WeatherInterpretationCode.LightDrizzle:
                    return MaterialDesignIconNames.DRIZZLE + ".svg";
                case WeatherInterpretationCode.ModerateDrizzle:
                    return MaterialDesignIconNames.DRIZZLE + ".svg";
                case WeatherInterpretationCode.DenseDrizzle:
                    return MaterialDesignIconNames.DRIZZLE + ".svg";
                case WeatherInterpretationCode.LightFreezingDrizzle:
                    return MaterialDesignIconNames.DRIZZLE + ".svg";
                case WeatherInterpretationCode.DenseFreezingDrizzle:
                    return MaterialDesignIconNames.DRIZZLE + ".svg";
                case WeatherInterpretationCode.SlightRain:
                    return MaterialDesignIconNames.RAIN + ".svg";
                case WeatherInterpretationCode.ModerateRain:
                    return MaterialDesignIconNames.RAIN + ".svg";
                case WeatherInterpretationCode.HeavyRain:
                    return MaterialDesignIconNames.RAIN + ".svg";
                case WeatherInterpretationCode.LightFreezingRain:
                    return MaterialDesignIconNames.RAIN + ".svg";
                case WeatherInterpretationCode.HeavyFreezingRain:
                    return MaterialDesignIconNames.RAIN + ".svg";
                case WeatherInterpretationCode.SlightSnowFall:
                    return MaterialDesignIconNames.SNOWFALL + ".svg";
                case WeatherInterpretationCode.ModerateSnowFall:
                    return MaterialDesignIconNames.SNOWFALL + ".svg";
                case WeatherInterpretationCode.HeavySnowFall:
                    return MaterialDesignIconNames.SNOWFALL + ".svg";
                case WeatherInterpretationCode.SnowGrains:
                    return MaterialDesignIconNames.SNOW_GRAINS + ".svg";
                case WeatherInterpretationCode.SlightRainShowers:
                    return MaterialDesignIconNames.RAIN_SHOWERS + ".svg";
                case WeatherInterpretationCode.ModerateRainShowers:
                    return MaterialDesignIconNames.RAIN_SHOWERS + ".svg";
                case WeatherInterpretationCode.ViolentRainShowers:
                    return MaterialDesignIconNames.RAIN_SHOWERS + ".svg";
                case WeatherInterpretationCode.SlightSnowShowers:
                    return MaterialDesignIconNames.SNOW_SHOWERS + ".svg";
                case WeatherInterpretationCode.HeavySnowShowers:
                    return MaterialDesignIconNames.SNOW_SHOWERS + ".svg";
                case WeatherInterpretationCode.Thunderstorm95:
                    return MaterialDesignIconNames.THUNDERSTORM + ".svg";
                case WeatherInterpretationCode.Thunderstorm96:
                    return MaterialDesignIconNames.THUNDERSTORM + ".svg";
                case WeatherInterpretationCode.Thunderstorm99:
                    return MaterialDesignIconNames.THUNDERSTORM + ".svg";
                default:
                    return MaterialDesignIconNames.NOT_FOUND + ".svg";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
