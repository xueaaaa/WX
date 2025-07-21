using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WX.Models.Weather
{
    [ObservableObject]
    public partial class WeatherData
    {
        [ObservableProperty]
        private ObservableCollection<HourlyWeather> _hourly;
        [ObservableProperty]
        private ObservableCollection<DailyWeather> _daily;
    }
}
