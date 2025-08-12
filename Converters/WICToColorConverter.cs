using System.Globalization;
using WX.Models.Weather;

namespace WX.Converters
{
    public class WICToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not WeatherInterpretationCode)
                return Application.Current!.Resources[$"{nameof(WeatherInterpretationCode.ClearSky)}Color"];

            var val = (WeatherInterpretationCode)value;

            return Application.Current!.Resources[$"{Enum.GetName(typeof(WeatherInterpretationCode), val)}Color"];
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
