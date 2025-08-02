using WX.ViewModels.Modals;

namespace WX.Views.Modals;

public partial class SelectLocationModal : ContentPage
{
	public SelectLocationModal(SelectLocationModalViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}