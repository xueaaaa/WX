using CommunityToolkit.Mvvm.ComponentModel;

namespace WX.Models.Location
{
    [ObservableObject]
    public partial class Location
    {
        [ObservableProperty]
        private string _latitude;
        [ObservableProperty]
        private string _longitude;
        [ObservableProperty]
        private string _elevation;
        [ObservableProperty]
        private string _country;
    }
}
