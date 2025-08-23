using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using WX.Converters;
using WX.Models.Message;
using WX.Models.Weather;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;
using WX.Views.Modals;

namespace WX.ViewModels.Pages
{
    public partial class DailyWeatherPageViewModel : ObservableObject, IInitializableViewModel, IRecipient<HourChangedMessage>
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
                if(value != DateTime.MinValue)
                    OnDateChanged();
            }
        }

        [ObservableProperty]
        private DailyWeather _currentDailyWeather;
        [ObservableProperty]
        private ObservableCollection<DailyWeather> _weatherForecast;

        public DailyWeatherPageViewModel(WeatherBackgroudWorker worker, LocationWorker locationWorker)
        {
            _weatherWorker = worker;
            _locationWorker = locationWorker;
            _wicToColorConverter = new();
        }

        public async Task Initialize()
        {
            _navigation = Application.Current.MainPage.Navigation;
            _messenger = WeakReferenceMessenger.Default;

            _messenger.RegisterAll(this);
            Receive(new(DateTime.Today));
        }

        public void Receive(HourChangedMessage message)
        {
            MaxDate = _weatherWorker.Data.Daily.MaxBy(x => x.Time)!.Time.ToDateTime(TimeOnly.MinValue);
            SelectedDate = message.Value.Date;
            MinDate = _weatherWorker.Data.Daily.MinBy(x => x.Time)!.Time.ToDateTime(TimeOnly.MinValue);
        }

        [RelayCommand]
        private async Task MoreAboutUV() =>
            await _navigation.PushModalAsync(new AboutUVModal(_navigation));

        [RelayCommand]
        private async Task OpenDetails() =>
            await _navigation.PushModalAsync(new DailyWeatherDetails(CurrentDailyWeather, _navigation));

        private void OnDateChanged()
        {
            var date = DateOnly.FromDateTime(SelectedDate);
            CurrentDailyWeather = _weatherWorker.Data.Daily.Where(x => x.Time == date).First();
            WeatherForecast = new(_weatherWorker.Data.Daily.Where(x => x.Time > date).Take(4));
        }
    }
}
