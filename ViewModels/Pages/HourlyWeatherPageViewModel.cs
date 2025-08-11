using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using WX.Models.Message;
using WX.Models.Weather;
using WX.Services.API.WeatherAPI.FieldNames;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;
using WX.Views.Modals;

namespace WX.ViewModels.Pages
{
    public partial class HourlyWeatherPageViewModel : ObservableObject, IInitializableViewModel, IRecipient<HourChangedMessage>, IRecipient<LocationChangedMessage>
    {
        private readonly WeatherBackgroudWorker _weatherWorker;
        private INavigation _navigation;
        private WeakReferenceMessenger _messenger;

        private readonly LocationWorker _locationWorker;
        public LocationWorker LocationWorker
        {
            get => _locationWorker;
        }

        [ObservableProperty]
        private ObservableCollection<HourlyWeather> _data;
        [ObservableProperty]
        private HourlyWeather _currentHourlyWeather;

        public HourlyWeatherPageViewModel(LocationWorker locationWorker, WeatherBackgroudWorker worker)
        {
            _locationWorker = locationWorker;
            _weatherWorker = worker;
        }

        public async Task Initialize()
        {
            _navigation = Application.Current!.MainPage.Navigation;
            _messenger = WeakReferenceMessenger.Default;
            Data = new();

            await _locationWorker.Initialize();
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LATITUDE, _locationWorker.SelectedLocation!.Latitude.ToString().Replace(',', '.'));
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, _locationWorker.SelectedLocation!.Longitude.ToString().Replace(',', '.'));
            await _weatherWorker.Initialize();

            _messenger.RegisterAll(this);
        }

        public void Receive(HourChangedMessage message)
        {
            Data.Clear();
            Data = _weatherWorker.Data.Hourly;
            SelectCurrentHour(message.Value);
        }

        public async void Receive(LocationChangedMessage message)
        {
            _weatherWorker.Sender.SetDefaultParameters();
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LATITUDE, message.Value.Latitude.ToString().Replace(',', '.'));
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, message.Value.Longitude.ToString().Replace(',', '.'));
        }

        [RelayCommand]
        private async Task OpenDetails() =>
            await _navigation.PushModalAsync(new HourlyWeatherDetails(CurrentHourlyWeather, _navigation));

        private void SelectCurrentHour(DateTime now)
        {
            CurrentHourlyWeather = Data.FirstOrDefault(x =>
                    now.Date == x.Time.Value.Date && now.Hour == x.Time.Value.Hour)!;
        }
    }
}
