using WX.Services.Preferences.Interfaces;
using WX.Services.Workers;
using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class SelectLocationModal : ContentPage
{
	public SelectLocationModal(IPreferencesService preferencesService, INavigation navigation, LocationWorker locationWorker)
	{
		InitializeComponent();

		BindingContext = new SelectLocationModalViewModel(preferencesService, navigation, locationWorker);
	}
}