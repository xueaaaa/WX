using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace WX.Models.Location
{
    [ObservableObject]
    public partial class Location
    {
        [ObservableProperty]
        [property: JsonPropertyName("name")]
        private string _name;
        [ObservableProperty]
        [property: JsonPropertyName("latitude")]
        private float _latitude;
        [ObservableProperty]
        [property: JsonPropertyName("longitude")]
        private float _longitude;
        [ObservableProperty]
        [property: JsonPropertyName("elevation")]
        private float _elevation;
        [ObservableProperty]
        [property: JsonPropertyName("country")]
        private string _country;
    }
}
