using System.Globalization;
using WX.Services.Preferences.FieldNames;

namespace WX.Converters
{
    public class TemperatureAddUnitConverter : PreferencesServiceConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            switch (_preferencesService.Get(PreferencesNames.TEMPERATURE_UNIT, Units.Celsius.ToStrValue()))
            {
                case "celsius":
                    return $"{value} °C";
                case "fahrenheit":
                    return $"{value} °F";
                default:
                    return string.Empty;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
