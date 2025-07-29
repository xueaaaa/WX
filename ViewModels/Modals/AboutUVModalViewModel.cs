using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WX.ViewModels.Modals
{
    public partial class AboutUVModalViewModel : ObservableObject
    {
        private readonly INavigation _navigation;

        public AboutUVModalViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        [RelayCommand]
        private async Task GoToSource() =>
            await Browser.Default.OpenAsync("https://www.epa.gov/sunsafety/uv-index-scale-0");

        [RelayCommand]
        private async Task Close() =>
            await _navigation.PopModalAsync();
    }
}
