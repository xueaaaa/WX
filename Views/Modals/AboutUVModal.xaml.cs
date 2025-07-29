using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class AboutUVModal : ContentPage
{
	public AboutUVModal(INavigation navigation)
	{
		InitializeComponent();

		BindingContext = new AboutUVModalViewModel(navigation);
	}
}