using CommunityToolkit.Mvvm.ComponentModel;
using WX.Models.Weather;
using WX.Services.API.Interfaces;

namespace WX.ViewModels.Pages
{
    public partial class HourlyWeatherPageViewModel : ObservableObject
    {
        private readonly IAPIService<WeatherData> _weatherService;

        public HourlyWeatherPageViewModel(IAPIService<WeatherData> weatherService)
        {
            _weatherService = weatherService;
        }
    }
}
