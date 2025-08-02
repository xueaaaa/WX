using WX.Services.Preferences.Interfaces;
using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class SelectLocationModal : ContentPage
{
	public SelectLocationModal(IPreferencesService preferencesService, INavigation navigation)
	{
		InitializeComponent();

		BindingContext = new SelectLocationModalViewModel(preferencesService, navigation);
	}
}