using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WX.Services.Preferences.Interfaces;
using WX.Services.Workers;
using WX.ViewModels.Interfaces;
using Location = WX.Models.Location.Location;

namespace WX.ViewModels.Modals
{
    public partial class SelectLocationModalViewModel : ObservableObject, IInitializableViewModel
    {
        private readonly IPreferencesService _preferencesService;
        private readonly INavigation _navigation;

        private readonly LocationWorker _locationWorker;
        public LocationWorker LocationWorker
        {
            get => _locationWorker;
        }

        [ObservableProperty]
        private ObservableCollection<Location> _searchedLocations;
        [ObservableProperty]
        private Location _selectedSearchedLocation;

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
        private async Task SetFromUserLocation()
        {
            var loc = await _locationWorker.GetUserLocation();

            if (loc != null)
            {
                _locationWorker.SelectedLocation = loc;

                if (!_locationWorker.AllLocations.Contains(loc))
                    _locationWorker.AllLocations.Add(loc);
            }
        }

        [RelayCommand]
        private async Task SearchLocation(object parameter)
        {
            var key = parameter as string;

            var data = await _locationWorker.LoadLocations(key);
            SearchedLocations = new(data);
        }

        [RelayCommand]
        private void AddSearchedLocation()
        {
            if (SelectedSearchedLocation != null)
            {
                _locationWorker.AllLocations.Add(SelectedSearchedLocation);
                SearchedLocations.Clear();
                SelectedSearchedLocation = null;
            }
        }

        [RelayCommand]
        private async Task Close() =>
            await _navigation.PopModalAsync();
    }
}
