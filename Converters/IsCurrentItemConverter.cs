using System.Globalization;

namespace WX.Converters
{
    public class IsCurrentItemConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return false;

            var item = values[0];
            var currentItem = values[1];

            return Equals(item, currentItem);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
