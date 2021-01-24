using EwelinkNet.Helpers.Extensions;
using System.Dynamic;

namespace EwelinkNet.Classes
{
    public class RfBridgeDevice : Device
    {
        public void TransmitChannel(int channel)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, $"rfCh{channel}", 0);
            data.cmd = "transmit";

            UpdateDevice(data);
        }
    }
}
