using System.Globalization;

namespace WX.Converters
{
    public class TimeToIsCurrentTimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not DateTime) return false;

            var val = (DateTime)value;
            TimeSpan diff = (DateTime.Now - val).Duration();

            return diff <= TimeSpan.FromDays(1) && val.Hour == DateTime.Now.Hour;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
