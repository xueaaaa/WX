using System.Globalization;

namespace WX.Converters
{
    public class UVIndexToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not int) return "#FFFFFF";

            var val = (int)value;
            switch (val)
            {
                case 0 or 1 or 2:
                    return Application.Current!.Resources["UVIndexLowColor"];
                case 3 or 4 or 5:
                    return Application.Current!.Resources["UVIndexModerateColor"];
                case 6 or 7:
                    return Application.Current!.Resources["UVIndexHighColor"];
                case 8 or 9 or 10:
                    return Application.Current!.Resources["UVIndexVeryHighColor"];
                case >= 11:
                    return Application.Current!.Resources["UVIndexExtremeColor"];
                default:
                    return "#FFFFFF";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
