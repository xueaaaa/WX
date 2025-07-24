using WX.Services.Preferences.Interfaces;

namespace WX.Services.API
{
    public class WeatherAPIOptions
    {
        public string BaseURL { get; set; }
        public IPreferencesService PreferencesService { get; set; }
    }
}
