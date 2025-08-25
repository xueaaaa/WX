using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Globalization;
using Locale = WX.Resources.Locales.Locale;
using WX.Services.Preferences.Interfaces;

namespace WX.ViewModels.Pages
{
    public partial class SettingsPageViewModel : ObservableObject
    {
        private readonly IPreferencesService _preferencesService;
        private readonly INavigation _navigation;

        [ObservableProperty]
        private ObservableCollection<string> _avaliableLocales;

        private string _selectedLocale;
        public string SelectedLocale
        {
            get => _selectedLocale;
            set 
            { 
                SetProperty(ref _selectedLocale, value);
                _preferencesService.SetLanguage(GetCultureByNativeName(SelectedLocale));
            }
        }

        public SettingsPageViewModel(IPreferencesService preferencesService, INavigation navigation)
        {
            _preferencesService = preferencesService;
            _navigation = navigation;

            AvaliableLocales = GetAvaliableLocales();
            SelectedLocale = _preferencesService.GetLanguage().NativeName;
        }

        private ObservableCollection<string> GetAvaliableLocales()
        {
            var list = new ObservableCollection<string>();

            foreach (var locale in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                var resource = Locale.ResourceManager.GetResourceSet(locale, true, false);

                if (resource != null && locale != CultureInfo.InvariantCulture)
                    list.Add(locale.TextInfo.ToTitleCase(locale.NativeName.ToLower()));
            }

            return list;
        }

        private CultureInfo GetCultureByNativeName(string nativeName)
        {
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
                if (culture.NativeName.ToLower() == nativeName.ToLower())
                    return culture;

            return CultureInfo.InvariantCulture;
        }

        [RelayCommand]
        private async void Close() =>
            await _navigation.PopModalAsync();
    }
}
