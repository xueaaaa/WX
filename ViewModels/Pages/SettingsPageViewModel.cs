using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WX.Services.Preferences.Interfaces;

namespace WX.ViewModels.Pages
{
    public partial class SettingsPageViewModel : ObservableObject
    {
        private readonly IPreferencesService _preferencesService;
        private readonly INavigation _navigation;

        public SettingsPageViewModel(IPreferencesService preferencesService, INavigation navigation)
        {
            _preferencesService = preferencesService;
            _navigation = navigation;
        }

        [RelayCommand]
        private async void Close() =>
            await _navigation.PopModalAsync();
    }
}
