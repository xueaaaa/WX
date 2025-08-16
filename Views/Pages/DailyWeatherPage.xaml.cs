using WX.ViewModels.Interfaces;
using WX.ViewModels.Pages;

namespace WX.Views.Pages;

public partial class DailyWeatherPage : ContentPage
{
	private bool _initialized = false;

	public DailyWeatherPage(DailyWeatherPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!_initialized)
        {
            await(BindingContext as IInitializableViewModel)!.Initialize();
            _initialized = true;
        }
    }
}