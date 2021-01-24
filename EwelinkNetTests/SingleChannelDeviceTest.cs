using Xunit;
using System.Dynamic;
using EwelinkNet.Classes;
using System.Linq;
using EwelinkNet.Helpers.Extensions;
using Xunit.Abstractions;

namespace EwelinkNet.Tests
{
    public class SingleChannelDeviceTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;
        private readonly string deviceName;


        public SingleChannelDeviceTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.singleChannelDeviceId;
            deviceName = testData.singleChannelDeviceName;
        }


        [Fact]
        public async void GetState()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            var state = device.GetState();

            output.WriteLine(state);
        }

        [Fact]
        public async void TurnOnDevice()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            device.TurnOn();
        }

        [Fact]
        public async void TurnOffDevice()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            device.TurnOff();
        }

        [Fact]
        public async void ToggleDevice()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            device.Toggle();
        }

        [Fact]
        public async void SetPulse()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            device.SetPulse("on", 5000);
        }

        [Fact]
        public async void SetStartup()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            device.SetStartup("on");
        }

    }
}
