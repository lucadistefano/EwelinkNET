namespace EwelinkNet.Classes
{
    public class ThermostatDevice : SwitchDevice
    {

        public string GetTemperature() => @params.currentTemperature;

        public string GetHumidity() => @params.currentHumidity;

    }
}
