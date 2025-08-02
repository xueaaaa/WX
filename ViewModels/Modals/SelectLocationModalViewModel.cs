using CommunityToolkit.Mvvm.ComponentModel;
using WX.Services.Preferences.Interfaces;
using WX.ViewModels.Interfaces;

namespace WX.ViewModels.Modals
{
    public partial class SelectLocationModalViewModel : ObservableObject, IInitializableViewModel
    {
        private IPreferencesService _preferencesService;

        public SelectLocationModalViewModel(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        public async Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
