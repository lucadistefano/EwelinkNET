using System;

namespace EwelinkNet.Classes.Events
{
    public class EventWebsocketMessage : EventArgs
    {

        public object Message { get; set; }
    }
}
