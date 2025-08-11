using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WX.Models.Message
{
    public class LocationChangedMessage : ValueChangedMessage<Location.Location>
    {
        public LocationChangedMessage(Location.Location value) : base(value) { }
    }
}
