using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WX.Models.Weather;
using WX.Services.API.FieldNames;
using WX.Services.API.Interfaces;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;
using WX.ViewModels.Interfaces;

namespace WX.ViewModels.Pages
{
    public partial class HourlyWeatherPageViewModel : ObservableObject, IInitializableViewModel
    {
        private readonly IAPIService<WeatherData> _weatherService;
        private readonly IPreferencesService _preferencesService;

        [ObservableProperty]
        private ObservableCollection<HourlyWeather> _data;
        [ObservableProperty]
        private HourlyWeather _currentHourlyWeather;

        public HourlyWeatherPageViewModel(IAPIService<WeatherData> weatherService, IPreferencesService preferencesService)
        {
            _weatherService = weatherService;
            _preferencesService = preferencesService;
        }

        public async Task Initialize()
        {
            _weatherService.RegisterParameter(WeatherAPIFieldNames.LATITUDE, _preferencesService.Get(PreferencesNames.CURRENT_LATITUDE, "14.14"));
            _weatherService.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, _preferencesService.Get(PreferencesNames.CURRENT_LONGITUDE, "55.55"));

            IEnumerable<WeatherData> data = await _weatherService.FetchData();
            if (data.Any())
                Data = [data.First().Hourly.First(), data.First().Hourly.Last(), data.First().Hourly[14]];
        }
    }
}
