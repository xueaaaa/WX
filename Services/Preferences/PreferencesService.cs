using System.Globalization;
using WX.Services.Preferences.FieldNames;
using WX.Services.Preferences.Interfaces;

namespace WX.Services.Preferences
{
    public class PreferencesService : IPreferencesService
    {
        public PreferencesService()
        {
            var lang = GetLanguage();
            CultureInfo.CurrentCulture = lang;
            CultureInfo.CurrentUICulture = lang;
        }

        public string Get(string key, string defaultValue) =>
            Microsoft.Maui.Storage.Preferences.Get(key, defaultValue);

        public void Set(string key, string value) =>
            Microsoft.Maui.Storage.Preferences.Set(key, value);

        public string GetDefaultLanguage() =>
            Microsoft.Maui.Storage.Preferences.Get(PreferencesNames.DEFAULT_LANGUAGE, "en");

        public CultureInfo GetLanguage()
        {
            var iso = Microsoft.Maui.Storage.Preferences.Get(PreferencesNames.LANGUAGE, GetDefaultLanguage());
            return new CultureInfo(iso);
        }

        public void SetLanguage(CultureInfo lang)
        {
            Microsoft.Maui.Storage.Preferences.Set(PreferencesNames.LANGUAGE, lang.TwoLetterISOLanguageName);
            CultureInfo.CurrentCulture = lang;
            CultureInfo.CurrentUICulture = lang;
        }
    }
}
