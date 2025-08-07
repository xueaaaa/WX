using System.Diagnostics;
using System.Globalization;

namespace WX.Converters
{
    public class CountryCodeToFlagURLConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string) return string.Empty;

            return $"https://flagcdn.com/80x60/{value.ToString().ToLower()}.png";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
