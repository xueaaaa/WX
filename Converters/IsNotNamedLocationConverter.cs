using System.Globalization;
using Location = WX.Models.Location.Location;

namespace WX.Converters
{
    public class IsNotNamedLocationConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Location)
                return false;

            var val = value as Location;

            if (val.Name != null)
                return false;

            return true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
