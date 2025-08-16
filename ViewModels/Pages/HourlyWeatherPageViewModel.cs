using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using WX.Converters;
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
        private readonly WICToColorConverter _wicToColorConverter;
        private INavigation _navigation;
        private WeakReferenceMessenger _messenger;

        private readonly LocationWorker _locationWorker;
        public LocationWorker LocationWorker
        {
            get => _locationWorker;
        }

        [ObservableProperty]
        private ObservableCollection<HourlyWeather> _data;
        private HourlyWeather _currentHourlyWeather;
        public HourlyWeather CurrentHourlyWeather
        {
            get => _currentHourlyWeather;
            set 
            { 
                SetProperty(ref _currentHourlyWeather, value);
                base.OnPropertyChanged(nameof(WeatherIconColor));
            }
        }

        public object? WeatherIconColor
        {
            get
            {
                if (CurrentHourlyWeather != null)
                    return _wicToColorConverter.Convert(CurrentHourlyWeather.WeatherCode, null, null, null);
                return Color.FromArgb("#ffffff");
            }
        }

        public HourlyWeatherPageViewModel(LocationWorker locationWorker, WeatherBackgroudWorker worker)
        {
            _locationWorker = locationWorker;
            _weatherWorker = worker;
            _wicToColorConverter = new();
        }

        public async Task Initialize()
        {
            _navigation = Application.Current.MainPage.Navigation;
            _messenger = WeakReferenceMessenger.Default;
            Data = new();

            _messenger.RegisterAll(this);
        }

        public void Receive(HourChangedMessage message) =>
            LoadData(message.Value);

        public async void Receive(LocationChangedMessage message)
        {
            _weatherWorker.Sender.SetDefaultParameters();
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LATITUDE, message.Value.Latitude.ToString().Replace(',', '.'));
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, message.Value.Longitude.ToString().Replace(',', '.'));
        } 

        [RelayCommand]
        private void MoveForward()
        {
            var currIndex = Data.IndexOf(CurrentHourlyWeather);
            if (currIndex + 1 <= Data.Count - 1)
                CurrentHourlyWeather = Data[currIndex + 1];
        }

        [RelayCommand]
        private void MoveBackward() 
        {
            var currIndex = Data.IndexOf(CurrentHourlyWeather);   
            if (currIndex - 1 >= 0)
                CurrentHourlyWeather = Data[currIndex - 1];
        }

        [RelayCommand]
        private async Task OpenDetails() =>
            await _navigation.PushModalAsync(new HourlyWeatherDetails(CurrentHourlyWeather, _navigation));

        private void LoadData(DateTime now)
        {
            Data.Clear();
            Data = new(_weatherWorker.Data.Hourly.Where(x => DateOnly.FromDateTime(x.Time.Value.Date) == DateOnly.FromDateTime(DateTime.Now)));
            CurrentHourlyWeather = Data.FirstOrDefault(x =>
                    now.Date == x.Time.Value.Date && now.Hour == x.Time.Value.Hour)!;
        }
    }
}
