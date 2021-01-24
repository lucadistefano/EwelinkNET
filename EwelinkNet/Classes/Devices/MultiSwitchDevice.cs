using System.Collections.Generic;

namespace EwelinkNet.Classes
{
    public class MultiSwitchDevice : MultiChannelDevice
    {
        public void TurnOff(int? outlet = null)
        {
            if (outlet == null) SetAllChannels("off");
            else SetChannel((int)outlet, "off");
        }

        public void TurnOn(int? outlet = null)
        {
            if (outlet == null) SetAllChannels("on");
            else SetChannel((int)outlet, "on");
        }

        public void Toggle(int outlet)
        {
            if (GetState(outlet) == "on") TurnOff(outlet);
            else TurnOn(outlet);
        }

        //public void TurnOnLAN() => SetStateLAN("on");
        //public void TurnOffLAN() => SetStateLAN("off");

        public string GetChannelName(int outlet)
        {
            if (outlet >= NumChannels) return null;
            return (string)((IDictionary<string, object>)tags.ck_channel_name)[outlet.ToString()];
        }

        public string GetState(int outlet)
        {
            if (outlet >= NumChannels) return null;
            return @params.switches[outlet].@switch;
        }
    }
}
