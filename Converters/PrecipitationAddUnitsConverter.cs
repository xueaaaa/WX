using System.Globalization;
using Locale = WX.Resources.Locales.Locale;
using WX.Services.Preferences.FieldNames;

namespace WX.Converters
{
    public class PrecipitationAddUnitsConverter : PreferencesServiceConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not float) return string.Empty;

            switch (_preferencesService.Get(PreferencesNames.PRECIPITATION_UNIT, Units.Millimeters.ToStrValue())
            {
                case "mm":
                    return $"{value} {Locale.mm}";
                case "inch":
                    return $"{value} {Locale.inch}";
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
