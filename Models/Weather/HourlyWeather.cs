using CommunityToolkit.Mvvm.ComponentModel;

namespace WX.Models.Weather
{
    [ObservableObject]
    public partial class HourlyWeather
    {
        [ObservableProperty]
        private DateTime _time;
        [ObservableProperty]
        private float _temperature2m;
        [ObservableProperty]
        private float _relativeHumidity2m;
        [ObservableProperty]
        private float _apparentTemperature;
        [ObservableProperty]
        private float _precipitationProbability;
        [ObservableProperty]
        private float _precipitation;
        [ObservableProperty]
        private float _snowDepth;
        [ObservableProperty]
        private WeatherInterpretationCode _weatherCode;
        [ObservableProperty]
        private float _surfacePressure;
        [ObservableProperty]
        private float _cloudCoverTotal;
        [ObservableProperty]
        private float _visibility;
        [ObservableProperty]
        private float _windSpeed10m;
        [ObservableProperty]
        private float _windGusts10m;
        [ObservableProperty]
        private float _UVIndex;
        [ObservableProperty]
        private bool _isDayOrNight;
        [ObservableProperty]
        private float _sunriseDuration;
    }
}
