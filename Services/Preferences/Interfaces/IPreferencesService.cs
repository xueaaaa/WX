using System.Globalization;

namespace WX.Services.Preferences.Interfaces
{
    public interface IPreferencesService
    {
        public void Set(string key, string value);
        public void Get(string key, string defaultValue);
        public void SetLanguage(CultureInfo lang);
        public string GetLanguage();
        public string GetDefaultLanguage();
    }
}
