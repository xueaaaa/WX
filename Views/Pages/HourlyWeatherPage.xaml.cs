using WX.ViewModels.Interfaces;
using WX.ViewModels.Pages;

namespace WX.Views.Pages;

public partial class HourlyWeatherPage : ContentPage
{
	private bool _initialized = false;

	public HourlyWeatherPage(HourlyWeatherPageViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		if (!_initialized)
		{
			await (BindingContext as IInitializableViewModel)!.Initialize();
			_initialized = true;
		}
    }
}