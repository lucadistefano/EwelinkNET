using Xunit;
using System.Dynamic;
using EwelinkNet.Classes;
using System.Linq;
using EwelinkNet.Helpers.Extensions;
using Xunit.Abstractions;

namespace EwelinkNet.Tests
{
    public class PowerSwitchDeviceTest
    {
        private readonly ITestOutputHelper output;

        private readonly string Email;
        private readonly string Password;
        private readonly string Region;
        private readonly string deviceId;

        public PowerSwitchDeviceTest(ITestOutputHelper output)
        {
            this.output = output;
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            Email = testData.email;
            Password = testData.password;
            Region = testData.region;
            deviceId = testData.multiChannelDeviceId;
        }

        [Fact]
        public async void GetState()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as PowerSwitchDevice;
            var state = device.GetState();

            output.WriteLine(state);
        }

        [Fact]
        public async void GetPower()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as PowerSwitchDevice;
            var power = device.GetPower();

            output.WriteLine(power);
        }


        [Fact]
        public async void GetCurrent()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as PowerSwitchDevice;
            var current = device.GetCurrent();

            output.WriteLine(current);
        }


        [Fact]
        public async void GetVoltager()
        {
            var ewelink = new Ewelink(Email, Password, Region);
            var credentials = await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var device = ewelink.Devices.First(x => x.deviceid == deviceId) as PowerSwitchDevice;
            var voltage = device.GetVoltage();

            output.WriteLine(voltage);
        }
    }
}
