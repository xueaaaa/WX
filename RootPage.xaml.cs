using WX.Services.API.WeatherAPI.FieldNames;
using WX.Services.Workers;
using WX.Views.Pages;
using Locale = WX.Resources.Locales.Locale;

namespace WX;

public partial class RootPage : TabbedPage
{
    private readonly IServiceProvider _serviceProvider;
    private bool _initialized;

	public RootPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();

        _serviceProvider = serviceProvider;

        var hourlyPage = _serviceProvider.GetRequiredService<HourlyWeatherPage>();
        hourlyPage.Title = Locale.HourlyTabName;
        var dailyPage = _serviceProvider.GetRequiredService<DailyWeatherPage>();
        dailyPage.Title = Locale.DailyTabName;

        Children.Add(hourlyPage);
        Children.Add(dailyPage);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!_initialized)
        {
            var locationWorker = _serviceProvider.GetRequiredService<LocationWorker>();
            var weatherWorker = _serviceProvider.GetRequiredService<WeatherBackgroudWorker>();

            await locationWorker.Initialize();
            weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LATITUDE, locationWorker.SelectedLocation!.Latitude.ToString().Replace(',', '.'));
            weatherWorker.Sender.RegisterParameter(WeatherAPIFieldNames.LONGITUDE, locationWorker.SelectedLocation!.Longitude.ToString().Replace(',', '.'));
            await weatherWorker.Initialize();

            _initialized = true;
        }
    }
}