using WX.ViewModels;
using WX.Views.Pages;
using Locale = WX.Resources.Locales.Locale;

namespace WX;

public partial class RootPage : TabbedPage
{
	public RootPage(IServiceProvider serviceProvider, RootPageViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;

        var hourlyPage = serviceProvider.GetRequiredService<HourlyWeatherPage>();
        hourlyPage.Title = Locale.HourlyTabName;
        var dailyPage = serviceProvider.GetRequiredService<DailyWeatherPage>();
        dailyPage.Title = Locale.DailyTabName;

        Children.Add(hourlyPage);
        Children.Add(dailyPage);
    }
}