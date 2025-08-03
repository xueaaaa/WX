using System.Text.Json;
using WX.Services.API.Interfaces;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;
using WX.Services.Workers.Interfaces;
using Location = WX.Models.Location.Location;

namespace WX.Services.Workers
{
    public class LocationWorker : IInitializibleWorker
    {
		private IPreferencesService _preferencesService;

		private IAPIService<Location> _sender;
		public IAPIService<Location> Sender
		{
			get => _sender;
		}

		public LocationWorker(IAPIService<Location> sender, IPreferencesService preferencesService)
		{
			_sender = sender;
			_preferencesService = preferencesService;
		}

        public async Task Initialize()
        {
            
        }

		public IEnumerable<Location>? LoadSavedLocations()
		{
			var data = _preferencesService.Get(PreferencesNames.ALL_LOCATIONS, string.Empty);
			var locations = JsonSerializer.Deserialize<IEnumerable<Location>>(data);

			return locations;
		}

		public Location? LoadCurrentLocation()
		{
			var data = _preferencesService.Get(PreferencesNames.CURRENT_LOCATION, string.Empty);
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
