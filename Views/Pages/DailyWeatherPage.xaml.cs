using WX.ViewModels.Pages;

namespace WX.Views.Pages;

public partial class DailyWeatherPage : ContentPage
{
	public DailyWeatherPage(DailyWeatherPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}