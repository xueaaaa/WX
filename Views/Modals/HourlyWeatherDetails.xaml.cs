using WX.Models.Weather;
using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class HourlyWeatherDetails : ContentPage
{
	public HourlyWeatherDetails(HourlyWeather weather, INavigation navigation)
	{
		InitializeComponent();

		BindingContext = new HourlyWeatherDetailsViewModel(weather, navigation);
	}
}