namespace WX.Services.Preferences.FieldNames
{
    public enum Units
    {
        Celsius,
        Fahrenheit,
        KilometersHour,
        MilesHour,
        MetersSecond,
        Knots,
        Millimeters,
        Inches
    }

    public static class UnitsExtensions
    {
        public static string ToStrValue(this Units unit)
        {
            switch (unit)
            {
                case Units.Celsius:
                    return "celsius";
                case Units.Fahrenheit:
                    return "fahrenheit";
                case Units.KilometersHour:
                    return "kmh";
                case Units.MilesHour:
                    return "mph";
                case Units.MetersSecond:
                    return "ms";
                case Units.Knots:
                    return "kn";
                case Units.Millimeters:
                    return "mm";
                case Units.Inches:
                    return "inch";
                default:
                    return string.Empty;
            }
        }
    }
}
