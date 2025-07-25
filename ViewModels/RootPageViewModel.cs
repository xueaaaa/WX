using CommunityToolkit.Mvvm.ComponentModel;
using WX.Services.API.Interfaces;
using Location = WX.Models.Location.Location;

namespace WX.ViewModels
{
    public partial class RootPageViewModel : ObservableObject
    {
        private readonly IAPIService<Location> _locationService;

        public RootPageViewModel(IAPIService<Location> locationService) 
        {
            _locationService = locationService;
        }
    }
}
