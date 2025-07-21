using CommunityToolkit.Mvvm.ComponentModel;

namespace WX.Models.Weather
{
    [ObservableObject]
    public partial class DailyWeather
    {
        [ObservableProperty]
        private WeatherInterpretationCode _weatherCode;
        [ObservableProperty]
        private float _maximumTemperature2m;
        [ObservableProperty]
        private float _minimumTemperature2m;
        [ObservableProperty]
        private float _maximumApparentTemperature2m;
        [ObservableProperty]
        private float _minimumApparentTemperature2m;
        [ObservableProperty]
        private TimeSpan _sunrise;
        [ObservableProperty]
        private TimeSpan _sunset;
        [ObservableProperty]
        private float _daylightDuration;
        [ObservableProperty]
        private float _sunshineDuration;
        [ObservableProperty]
        private float _UVIndex;
        [ObservableProperty]
        private float _precipitationSum;
        [ObservableProperty]
        private float _precipitationHours;
        [ObservableProperty]
        private float _precipitationProbabilityMax;
        [ObservableProperty]
        private float _maximumWindSpeed;
        [ObservableProperty]
        private float _maximumWindGusts;
    }
}
