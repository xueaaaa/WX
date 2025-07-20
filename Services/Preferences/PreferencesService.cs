using System.Globalization;
using WX.Services.Preferences.Interfaces;

namespace WX.Services.Preferences
{
    public class PreferencesService : IPreferencesService
    {
        public void Get(string key, string defaultValue) =>
            Microsoft.Maui.Storage.Preferences.Get(key, defaultValue);

        public void Set(string key, string value) =>
            Microsoft.Maui.Storage.Preferences.Set(key, value);

        public string GetDefaultLanguage() =>
            Microsoft.Maui.Storage.Preferences.Get("default_language", "en");

        public string GetLanguage() =>
            Microsoft.Maui.Storage.Preferences.Get("language", GetDefaultLanguage());

        public void SetLanguage(CultureInfo lang) =>
            Microsoft.Maui.Storage.Preferences.Set("language", lang.TwoLetterISOLanguageName);
    }
}
