using System;
using System.Dynamic;
using EwelinkNet.Classes;
using EwelinkNet.Helpers.Extensions;

namespace EwelinkNet.Poller
{
    class Program
    {
        public static async void CompleteCheck()
        {
            dynamic testData = System.IO.File.ReadAllText("test-data.json").FromJson<ExpandoObject>();

            var Email = testData.email;
            var Password = testData.password;
            var Region = testData.region;

            var deviceId = testData.multiChannelDeviceId;

            var ewelink = new Ewelink(Email, Password, Region);
            Console.WriteLine($"Logging in {Email}");

            var credentials = await ewelink.GetCredentials();
            Console.WriteLine("Got credentials");

            await ewelink.GetDevices();
            Console.WriteLine($"Got {ewelink.Devices.Length} devices");

            //ewelink.webSocket.OnMessage += (s, e) => messages += e.Message.AsJson();
            //ewelink.OpenWebSocket();

            foreach (var device in ewelink.Devices)
            {
                Console.WriteLine($"Device: {device.name} {device.deviceName} {device.deviceid} {device.deviceStatus} {device.deviceUrl}");

                if (device is MultiSwitchDevice)
                {
                    var md = (MultiSwitchDevice)device;
                    for (var channel = 0; channel < md.NumChannels; channel++)
                    {
                        var state = md.GetState(channel);
                        var name = md.GetChannelName(channel);
                        Console.WriteLine($" channel {channel} {name} = {state}");
                    }
                }
                else if (device is PowerSwitchDevice)
                {
                    var sd = (PowerSwitchDevice)device;
                    var state = sd.GetState();
                    var voltage = sd.GetVoltage();
                    var current = sd.GetCurrent();
                    var power = sd.GetPower();

                    Console.WriteLine($" state {state} power {power} current {current} voltage {voltage}");
                }
                else if (device is SwitchDevice)
                {
                    var sd = (SwitchDevice)device;
                    var state = sd.GetState();

                    Console.WriteLine($" state {state}");
                }
     
            }
            //var device = ewelink.Devices.First(x => x.deviceid == deviceId) as MultiSwitchDevice;


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            try
            {
                CompleteCheck();

                Console.WriteLine("End");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
