using WX.Services.Preferences.Interfaces;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;
using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class SelectLocationModal : ContentPage
{
	private bool _isInitialized = false;

	public SelectLocationModal(IPreferencesService preferencesService, INavigation navigation, LocationWorker locationWorker)
	{
		InitializeComponent();

		BindingContext = new SelectLocationModalViewModel(preferencesService, navigation, locationWorker);
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!_isInitialized)
        {
            await (BindingContext as IInitializableViewModel)!.Initialize();
            _isInitialized = true;
        }
    }
}