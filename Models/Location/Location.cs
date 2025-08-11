using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;
using WX.Models.Location.FieldNames;

namespace WX.Models.Location
{
    [ObservableObject]
    public partial class Location
    {
        [ObservableProperty]
        [property: JsonPropertyName(LocationAPIFieldNames.NAME)]
        private string _name;
        [ObservableProperty]
        [property: JsonPropertyName(LocationAPIFieldNames.LATITUDE)]
        private float _latitude;
        [ObservableProperty]
        [property: JsonPropertyName(LocationAPIFieldNames.LONGITUDE)]
        private float _longitude;
        [ObservableProperty]
        [property: JsonPropertyName(LocationAPIFieldNames.ELEVATION)]
        private float _elevation;
        [ObservableProperty]
        [property: JsonPropertyName(LocationAPIFieldNames.COUNTRY)]
        private string _country;
        [ObservableProperty]
        [property: JsonPropertyName(LocationAPIFieldNames.COUNTRY_CODE)]
        private string _countryCode;

        public override bool Equals(object? obj)
        {
            if (obj is not Location)
                return false;

            var val = obj as Location;

            if (Name != val.Name || Latitude != val.Latitude || Longitude != val.Longitude || Elevation != val.Elevation || Country != val.Country || CountryCode != val.CountryCode)
                return false;

            return true;
        }
    }
}
