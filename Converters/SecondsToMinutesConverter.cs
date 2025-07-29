using System.Globalization;
using Locale = WX.Resources.Locales.Locale;

namespace WX.Converters
{
    public class SecondsToMinutesConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not float) return string.Empty;

            return $"{(float)value / 60} {Locale.min}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
