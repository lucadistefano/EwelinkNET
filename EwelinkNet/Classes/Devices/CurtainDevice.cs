using EwelinkNet.Helpers.Extensions;
using System.Dynamic;

namespace EwelinkNet.Classes
{
    public class CurtainDevice : SwitchDevice
    {
        public void SetClose(int percent)
        {
            dynamic data = new ExpandoObject();
            ExpandoHelpers.AddProperty(data, "setClose", percent);

            UpdateDevice(data);
        }

    }
}
