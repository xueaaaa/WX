using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WX.Models.Weather;
using WX.Views.Modals;

namespace WX.ViewModels.Modals
{
    public partial class HourlyWeatherDetailsViewModel : ObservableObject
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private HourlyWeather _weather;

        public HourlyWeatherDetailsViewModel(HourlyWeather weather, INavigation navigation)
        {
            Weather = weather;

            _navigation = navigation;
        }

        [RelayCommand]
        private async Task MoreAboutUV() =>
            await _navigation.PushModalAsync(new AboutUVModal(_navigation));

        [RelayCommand]
        private async Task CloseDetails() =>
            await _navigation.PopModalAsync();
    }
}
