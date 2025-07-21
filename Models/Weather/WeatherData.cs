using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using WX.Models.Weather.FieldNames;

namespace WX.Models.Weather
{
    [ObservableObject]
    public partial class WeatherData
    {
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIWeatherDataFieldNames.HOURLY)]
        private ObservableCollection<HourlyWeather> _hourly;
        [ObservableProperty]
        [property: JsonPropertyName(WeatherAPIWeatherDataFieldNames.DAILY)]
        private ObservableCollection<DailyWeather> _daily;
    }
}
