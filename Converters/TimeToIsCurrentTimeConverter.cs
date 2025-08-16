using System.Globalization;

namespace WX.Converters
{
    public class TimeToIsCurrentTimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            DateTime val = DateTime.MinValue;
            if (value is DateTime t)
                val = t;
            if (value is DateOnly t1)
                val = t1.ToDateTime(TimeOnly.MinValue);

            return val.Date == DateTime.Now.Date && val.Hour == DateTime.Now.Hour;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
