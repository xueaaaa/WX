using WX.Services.Preferences.Interfaces;
using WX.ViewModels.Pages;

namespace WX.Views.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(IPreferencesService preferencesService, INavigation navigation)
	{
		InitializeComponent();

        BindingContext = new SettingsPageViewModel(preferencesService, navigation);
	}
}