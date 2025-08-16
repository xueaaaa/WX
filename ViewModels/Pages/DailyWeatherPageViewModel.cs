using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WX.Converters;
using WX.Models.Message;
using WX.Models.Weather;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;

namespace WX.ViewModels.Pages
{
    public partial class DailyWeatherPageViewModel : ObservableObject, IInitializableViewModel, IRecipient<HourChangedMessage>
    {
        private readonly WeatherBackgroudWorker _weatherWorker;
        private readonly WICToColorConverter _wicToColorConverter;
        private WeakReferenceMessenger _messenger;
        private readonly LocationWorker _locationWorker;
        public LocationWorker LocationWorker
        {
            get => _locationWorker;
        }

        [ObservableProperty]
        private ObservableCollection<DailyWeather> _data;
        private DailyWeather _currentDailyWeather;
        public DailyWeather CurrentDailyWeather
        {
            get => _currentDailyWeather;
            set => SetProperty(ref _currentDailyWeather, value);
        }

        public object? WeatherIconColor
        {
            get
            {
                if (CurrentDailyWeather != null)
                    return _wicToColorConverter.Convert(CurrentDailyWeather.WeatherCode, null, null, null);
                return Color.FromArgb("#ffffff");
            }
        }

        public DailyWeatherPageViewModel(WeatherBackgroudWorker worker, LocationWorker locationWorker)
        {
            _weatherWorker = worker;
            _locationWorker = locationWorker;
            _wicToColorConverter = new();
        }

        public async Task Initialize()
        {
            _messenger = WeakReferenceMessenger.Default;
            Data = new();

            _messenger.RegisterAll(this);
            LoadData(DateTime.Now);
        }

        public void Receive(HourChangedMessage message) =>
            LoadData(message.Value);

        private void MoveTo(DailyWeather position)
        {
            var posIndex = Data.IndexOf(position);
            var currIndex = Data.IndexOf(CurrentDailyWeather);

            if (posIndex != -1 && currIndex != -1)
            {
                while (currIndex > posIndex)
                {
                    currIndex--;
                    CurrentDailyWeather = Data[currIndex];
                }
                while (currIndex < posIndex)
                {
                    currIndex++;
                    CurrentDailyWeather = Data[currIndex];
                }
            }
        }

        private void LoadData(DateTime now)
        {
            Data.Clear();
            Data = _weatherWorker.Data.Daily;
            SelectCurrentDaily(DateOnly.FromDateTime(now));
        }

        private void SelectCurrentDaily(DateOnly now)
        {
            var t = Data.FirstOrDefault(x => x.Time == now);
            MoveTo(t);
        }
    }
}
