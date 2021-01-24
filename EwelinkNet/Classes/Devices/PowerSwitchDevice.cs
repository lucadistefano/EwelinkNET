using System;
using System.Threading.Tasks;

namespace EwelinkNet.Classes
{
    public class PowerSwitchDevice : SingleChannelDevice
    {
        public PowerSwitchDevice()
        {
        }

        public void TurnOff() => SetState("off");
        public void TurnOn() => SetState("on");
        public void Toggle() => (GetState() == "on" ? (Action)TurnOff : (Action)TurnOn)();

        public async Task TurnOnLAN() => await SetStateLAN("on");
        public async Task TurnOffLAN() => await SetStateLAN("off");

        public string GetState() => @params.@switch;

        // power

        public string GetCurrent() => @params.@current;
        public string GetPower() => @params.@power;
        public string GetVoltage() => @params.@voltage;
    }
}
