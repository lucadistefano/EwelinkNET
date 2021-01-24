namespace EwelinkNet.Classes
{
    public class PowerSwitchDevice : SwitchDevice
    {
        public string GetCurrent() => @params.@current;

        public string GetPower() => @params.@power;

        public string GetVoltage() => @params.@voltage;
    }
}
