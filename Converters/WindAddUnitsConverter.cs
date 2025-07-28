using System.Globalization;
using WX.Services.Preferences.FieldNames;
using Locale = WX.Resources.Locales.Locale;

namespace WX.Converters
{
    public class WindAddUnitsConverter : PreferencesServiceConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            switch (_preferencesService.Get(PreferencesNames.WIND_SPEED_UNIT, Units.MetersSecond.ToStrValue()))
            {
                case "ms":
                    return $"{value} {Locale.ms}";
                case "kmh":
                    return $"{value} {Locale.kmh}";
                case "mph":
                    return $"{value} {Locale.mph}";
                case "kn":
                    return $"{value} {Locale.kn}";
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
