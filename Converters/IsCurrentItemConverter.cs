using System.Globalization;

namespace WX.Converters
{
    public class IsCurrentItemConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter is not CarouselView)
                return false;

            var carousel = parameter as CarouselView;

            return Equals(carousel!.CurrentItem, value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
