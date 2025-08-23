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
        private DateTime _minDate;
        [ObservableProperty]
        private DateTime _maxDate;

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
                if(SelectedTime != TimeSpan.Zero)
                    OnDateTimeChanged();
            }
        }

        [ObservableProperty]
        private ObservableCollection<TimeSpan> _times;

        private TimeSpan _selectedTime;
        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set 
            { 
                SetProperty(ref _selectedTime, value);
                if(SelectedDate != DateTime.MinValue)
                    OnDateTimeChanged();
            }
        }

        [ObservableProperty]
        private ObservableCollection<HourlyWeather> _weatherForecast;
        [ObservableProperty]
        private HourlyWeather _currentHourlyWeather;

        public HourlyWeatherPageViewModel(LocationWorker locationWorker, WeatherBackgroudWorker worker)
        {
            _locationWorker = locationWorker;
            _weatherWorker = worker;
            Times = new();
        }

        public async Task Initialize()
        {
            _navigation = Application.Current.MainPage.Navigation;
            _messenger = WeakReferenceMessenger.Default;
            for (int i = 0; i < 24; i++)
                Times.Add(TimeSpan.FromHours(i));

            _messenger.RegisterAll(this);
        }

        public void Receive(HourChangedMessage message)
        {
            MaxDate = _weatherWorker.Data.Daily.MaxBy(x => x.Time)!.Time.ToDateTime(TimeOnly.MinValue);
            SelectedDate = message.Value.Date;
            MinDate = _weatherWorker.Data.Daily.MinBy(x => x.Time)!.Time.ToDateTime(TimeOnly.MinValue);

            SelectedTime = Times.Where(x => x.Hours == message.Value.Hour).First();
        }

        public async void Receive(LocationChangedMessage message)
        {
            _weatherWorker.Sender.SetDefaultParameters();
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LATITUDE, message.Value.Latitude.ToString().Replace(',', '.'));
            _weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, message.Value.Longitude.ToString().Replace(',', '.'));
        }

        [RelayCommand]
        private async Task MoreAboutUV() =>
            await _navigation.PushModalAsync(new AboutUVModal(_navigation));

        [RelayCommand]
        private async Task OpenDetails() =>
            await _navigation.PushModalAsync(new HourlyWeatherDetails(CurrentHourlyWeather, _navigation));

        private void OnDateTimeChanged()
        {
            var combinedDate = new DateTime(DateOnly.FromDateTime(SelectedDate), TimeOnly.FromTimeSpan(SelectedTime));
            CurrentHourlyWeather = _weatherWorker.Data.Hourly.Where(x => x.Time == combinedDate).First();
            WeatherForecast = new(_weatherWorker.Data.Hourly.Where(x => x.Time > combinedDate).Take(3));
        }
    }
}
