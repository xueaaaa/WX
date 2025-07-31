using WX.Services.Preferences.Interfaces;

namespace WX.Services.API.WeatherAPI
{
    public class WeatherAPIOptions
    {
        public string BaseURL { get; set; }
        public IPreferencesService PreferencesService { get; set; }
    }
}
