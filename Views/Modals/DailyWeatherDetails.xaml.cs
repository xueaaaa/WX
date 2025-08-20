using WX.Models.Weather;
using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class DailyWeatherDetails : ContentPage
{
	public DailyWeatherDetails(DailyWeather weather, INavigation navigation)
	{
		InitializeComponent();

		BindingContext = new DailyWeatherDetailsViewModel(weather, navigation);
	}
}