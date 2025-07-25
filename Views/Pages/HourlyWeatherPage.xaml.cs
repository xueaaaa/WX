using WX.ViewModels.Interfaces;
using WX.ViewModels.Pages;

namespace WX.Views.Pages;

public partial class HourlyWeatherPage : ContentPage
{
	public HourlyWeatherPage(HourlyWeatherPageViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await (BindingContext as IInitializableViewModel)!.Initialize();
    }
}