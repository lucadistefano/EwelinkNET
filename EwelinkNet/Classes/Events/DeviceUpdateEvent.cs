using System;

namespace EwelinkNet.Classes.Events
{
    public class EvendDeviceUpdate : EventArgs
    {
        public Device Device { get; set; }
    }
}
