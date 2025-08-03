using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WX.Services.Preferences.Interfaces;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;

namespace WX.ViewModels.Modals
{
    public partial class SelectLocationModalViewModel : ObservableObject, IInitializableViewModel
    {
        private readonly IPreferencesService _preferencesService;
        private readonly INavigation _navigation;
        private readonly LocationWorker _locationWorker;

        [ObservableProperty]
        private ObservableCollection<Location> _locations;
        [ObservableProperty]
        private Location _currentLocation;

        public SelectLocationModalViewModel(IPreferencesService preferencesService, INavigation navigation, LocationWorker locationWorker)
        {
            _preferencesService = preferencesService;
            _navigation = navigation;
            _locationWorker = locationWorker;
        }

        public async Task Initialize()
        {
            
        }

        [RelayCommand]
        private async Task Close() =>
            await _navigation.PopModalAsync();
    }
}
