using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleServer.Services
{
    public class DeviceManager : IDeviceManager
    {
        private readonly Dictionary<string,IDevice> _devices = new Dictionary<string, IDevice>(StringComparer.OrdinalIgnoreCase);

        public IDevice GetController(string serialNumber)
        {
            return _devices[serialNumber];
        }

        public void AddController(string serialNumber, IDevice device)
        {
            _devices[serialNumber] = device;
        }
    }
}