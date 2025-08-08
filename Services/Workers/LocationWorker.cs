using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using WX.Services.API.Interfaces;
using WX.Services.API.LocationAPI.FieldNames;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;
using WX.Services.Workers.Interfaces;
using Location = WX.Models.Location.Location;

namespace WX.Services.Workers
{
    public class LocationWorker : ObservableObject, IInitializibleWorker
    {
		private IPreferencesService _preferencesService;

		private IAPIService<Location> _sender;
		public IAPIService<Location> Sender
		{
			get => _sender;
		}


		private ObservableCollection<Location> _allLocations;
		public ObservableCollection<Location> AllLocations
		{
			get => _allLocations;
			set 
			{ 
				SetProperty(ref _allLocations, value);
				SaveAllLocations(value);
			}
		}

		private Location? _selectedLocation;
		public Location? SelectedLocation
		{
			get => _selectedLocation;
			set 
			{ 
				SetProperty(ref _selectedLocation, value);
				SaveCurrentLocation(value);
			}
		}


		public LocationWorker(IAPIService<Location> sender, IPreferencesService preferencesService)
		{
			_sender = sender;
			_preferencesService = preferencesService;
		}

        public async Task Initialize()
        {
			SelectedLocation = LoadCurrentLocation();
			AllLocations = new(LoadAllLocations() ?? []);

			AllLocations.CollectionChanged += (o, e) =>
			{
				SaveAllLocations(AllLocations);
			};
        }

		public async Task<IEnumerable<Location>> LoadLocations(string name)
		{
			_sender.RegisterParameter(LocationAPIFieldNames.NAME, name);

			var resp = await _sender.FetchData();
			_sender.SetDefaultParameters();

			return resp;
		}

		public async Task<Location?> GetUserLocation()
		{
			try
			{
				var data = await Geolocation.Default.GetLocationAsync();
				var location = new Location
				{
					Latitude = (float)data!.Latitude,
					Longitude = (float)data!.Longitude,
					Elevation = (float)data!.Altitude,
				};

				return location;
			}
			catch (Exception ex) 
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}

		public IEnumerable<Location>? LoadAllLocations()
		{
			var data = _preferencesService.Get(PreferencesNames.ALL_LOCATIONS, "[]");
			var locations = JsonSerializer.Deserialize<IEnumerable<Location>>(data);

			return locations;
		}

		public Location? LoadCurrentLocation()
		{
			var data = _preferencesService.Get(PreferencesNames.CURRENT_LOCATION, "{}");
			var location = JsonSerializer.Deserialize<Location>(data);

			return location;
		}

		public void SaveAllLocations(IEnumerable<Location> data)
		{
            var json = JsonSerializer.Serialize(data);
			_preferencesService.Set(PreferencesNames.ALL_LOCATIONS, json);
		}

		public void SaveCurrentLocation(Location data) 
		{
			var json = JsonSerializer.Serialize(data);
			_preferencesService.Set(PreferencesNames.CURRENT_LOCATION, json);
		}
    }
}
