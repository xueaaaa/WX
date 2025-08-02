using MauiIcons.Material;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using WX.Models.Weather;
using WX.Services.API.Interfaces;
using WX.Services.API.LocationAPI;
using WX.Services.API.WeatherAPI;
using WX.Services.Preferences;
using WX.Services.Preferences.Interfaces;
using WX.Services.Workers;
using WX.ViewModels;
using WX.ViewModels.Modals;
using WX.ViewModels.Pages;
using WX.Views.Modals;
using WX.Views.Pages;
using Location = WX.Models.Location.Location;

namespace WX
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.UseMaterialMauiIcons();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IAPIService<Location>, LocationAPIService>();
            builder.Services.AddSingleton<IAPIService<WeatherData>, WeatherAPIService>();
            builder.Services.AddSingleton<IPreferencesService, PreferencesService>();

            builder.Services.AddSingleton<WeatherBackgroudWorker>();

            builder.Services.AddSingleton<App>();
            builder.Services.AddSingleton<RootPage>();

            var tempProvider = builder.Services.BuildServiceProvider();
            var prefService = tempProvider.GetRequiredService<IPreferencesService>();
            builder.Services.Configure<WeatherAPIOptions>(conf =>
            {
                conf.BaseURL = "https://api.open-meteo.com/v1/forecast?";
                conf.PreferencesService = prefService;
            });
            builder.Services.Configure<LocationAPIOptions>(conf =>
            {
                conf.BaseURL = "\"https://open-meteo.com/en/docs/geocoding-api?";
                conf.PreferencesService = prefService;
            });
            builder.Services.AddSingleton<HourlyWeatherPage>();
            builder.Services.AddSingleton<HourlyWeatherPageViewModel>();
            builder.Services.AddSingleton<DailyWeatherPage>();
            builder.Services.AddSingleton<DailyWeatherPageViewModel>();
            builder.Services.AddTransient<SelectLocationModal>();
            builder.Services.AddTransient<SelectLocationModalViewModel>();

            return builder.Build();
        }
    }
}
