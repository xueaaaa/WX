using WX.Services;
using WX.Services.Preferences.Interfaces;
using WX.Views.Modals;

namespace WX.Views.Controls;

public partial class ControlButtonsPanel : ContentView
{
	private readonly IPreferencesService _preferencesService;
	private INavigation _navigation;

	public ControlButtonsPanel()
	{
		InitializeComponent();

		_preferencesService = ServiceHelper.GetService<IPreferencesService>();
	}

	private void CheckNavigation()
	{
		if (_navigation == null)
			_navigation = Application.Current!.MainPage.Navigation;
	}

	private async void SelectLocationButton_Clicked(object sender, EventArgs e) 
	{
		CheckNavigation();
		await _navigation.PushModalAsync(new SelectLocationModal(_preferencesService, _navigation));
	}
}