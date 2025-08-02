using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WX.Services.Preferences.Interfaces;
using WX.ViewModels.Interfaces;

namespace WX.ViewModels.Modals
{
    public partial class SelectLocationModalViewModel : ObservableObject, IInitializableViewModel
    {
        private IPreferencesService _preferencesService;
        private INavigation _navigation;

        public SelectLocationModalViewModel(IPreferencesService preferencesService, INavigation navigation)
        {
            _preferencesService = preferencesService;
            _navigation = navigation;
        }

        public async Task Initialize()
        {
            
        }

        [RelayCommand]
        private async Task Close() =>
            await _navigation.PopModalAsync();
    }
}
