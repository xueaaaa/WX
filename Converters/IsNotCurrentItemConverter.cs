using System.Globalization;

namespace WX.Converters
{
    public class IsNotCurrentItemConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter is not CarouselView)
                return true;

            var carousel = parameter as CarouselView;

            return !Equals(carousel!.CurrentItem, value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
