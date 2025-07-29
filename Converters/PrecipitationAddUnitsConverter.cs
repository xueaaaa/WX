using System.Globalization;
using WX.Services.Preferences.FieldNames;

namespace WX.Converters
{
    public class PrecipitationAddUnitsConverter : PreferencesServiceConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not float) return string.Empty;

            return $"{value} {_preferencesService.Get(PreferencesNames.PRECIPITATION_UNIT, Units.Millimeters.ToStrValue())}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
