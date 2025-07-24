using WX.ViewModels.Pages;

namespace WX.Views.Pages;

public partial class HourlyWeatherPage : ContentPage
{
	public HourlyWeatherPage(HourlyWeatherPageViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
	}
}