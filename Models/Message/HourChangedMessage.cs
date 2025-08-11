using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WX.Models.Message
{
    public class HourChangedMessage : ValueChangedMessage<DateTime>
    {
        public HourChangedMessage(DateTime value) : base(value) { }
    }
}
