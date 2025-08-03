using CommunityToolkit.Mvvm.Messaging;
using WX.Models.Weather;
using WX.Services.API.Interfaces;

namespace WX.Services.Workers
{
    public partial class WeatherBackgroudWorker
    {
        private DateTime _previousCheckTime;
        private Timer _timer;

        private WeakReferenceMessenger _messenger;
        private IAPIService<WeatherData> _sender;
        public IAPIService<WeatherData> Sender
        {
            get => _sender;
        }

        private WeatherData _data;
        public WeatherData Data
        {
            get => _data;
            private set => _data = value;
        }

        public WeatherBackgroudWorker(IAPIService<WeatherData> sender)
        {
            _messenger = WeakReferenceMessenger.Default;
            _sender = sender;
        }

        public Task Initialize()
        {
            TimerCallback executingMethod = new(UpdateDataTimerCallback);
            _timer = new(executingMethod);
            _timer.Change(0, 5000);

            return Task.CompletedTask;
        }

        public async Task UpdateData()
        {
            WeatherData data = (await _sender.FetchData()).First();
            Data = data;

            _messenger.Send <object>();
        }

        private async void UpdateDataTimerCallback(object? _)
        {
            if(_previousCheckTime.Hour != DateTime.Now.Hour)
                await UpdateData();

            _previousCheckTime = DateTime.Now;
        }
    }
}
