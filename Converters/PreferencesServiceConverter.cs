using WX.Services;
using WX.Services.Preferences.Interfaces;

namespace WX.Converters
{
    public abstract class PreferencesServiceConverter
    {
        protected IPreferencesService _preferencesService;

        public PreferencesServiceConverter()
        {
            _preferencesService = ServiceHelper.GetService<IPreferencesService>();
        }
    }
}
