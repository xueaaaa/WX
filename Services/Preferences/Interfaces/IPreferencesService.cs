using System.Globalization;

namespace WX.Services.Preferences.Interfaces
{
    public interface IPreferencesService
    {
        public void Set(string key, string value);
        public string Get(string key, string defaultValue);
        public void SetLanguage(CultureInfo lang);
        public CultureInfo GetLanguage();
        public string GetDefaultLanguage();
    }
}
