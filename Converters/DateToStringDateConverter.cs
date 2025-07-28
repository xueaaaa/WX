using System.Globalization;

namespace WX.Converters
{
    public class DateToStringDateConverter : PreferencesServiceConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not DateTime) return string.Empty;

            var val = (DateTime)value;
            return val.ToString("M", 
                new CultureInfo(_preferencesService.GetLanguage()));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
