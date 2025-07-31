using WX.Services.Preferences.Interfaces;

namespace WX.Services.API.LocationAPI
{
    public class LocationAPIOptions
    {
        public string BaseURL { get; set; }
        public IPreferencesService PreferencesService { get; set; }
    }
}
