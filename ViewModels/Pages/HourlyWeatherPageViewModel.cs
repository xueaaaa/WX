using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using WX.Models.Weather;
using WX.Services.API.WeatherAPI.FieldNames;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;
using WX.Views.Modals;

namespace WX.ViewModels.Pages
{
    public partial class HourlyWeatherPageViewModel : ObservableObject, IInitializableViewModel, IRecipient<object>
    {
        private readonly WeatherBackgroudWorker _worker;
        private readonly IPreferencesService _preferencesService;
        private INavigation _navigation;
        private WeakReferenceMessenger _messenger;

        [ObservableProperty]
        private ObservableCollection<HourlyWeather> _data;
        [ObservableProperty]
        private HourlyWeather _currentHourlyWeather;

        public HourlyWeatherPageViewModel(WeatherBackgroudWorker worker, IPreferencesService preferencesService)
        {
            _worker = worker;
            _preferencesService = preferencesService;
        }

        public async Task Initialize()
        {
            _navigation = Application.Current!.MainPage.Navigation;
            _messenger = WeakReferenceMessenger.Default;
            Data = new();

            _worker.Sender.RegisterParameter(WeatherAPIFieldNames.LATITUDE, _preferencesService.Get(PreferencesNames.CURRENT_LATITUDE, "14.14"));
            _worker.Sender.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, _preferencesService.Get(PreferencesNames.CURRENT_LONGITUDE, "55.55"));
            _worker.Initialize();

            _messenger.Register(this);
        }

        public void Receive(object message)
        {
            Data.Clear();
            Data = _worker.Data.Hourly;
            CurrentHourlyWeather = Data.Where(x =>
                    (DateTime.Now - x.Time!.Value).Duration() <= TimeSpan.FromDays(1) && DateTime.Now.Hour == x.Time.Value.Hour).First();
        }

        [RelayCommand]
        private async Task OpenDetails() =>
            await _navigation.PushModalAsync(new HourlyWeatherDetails(CurrentHourlyWeather, _navigation));
    }
}
