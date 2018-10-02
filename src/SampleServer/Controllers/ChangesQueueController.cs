using System.Web.Http;
using NLog;
using SampleServer.Domain.Queues;
using SampleServer.Services;

namespace SampleServer.Controllers
{
    [RoutePrefix("grosvenor-oem/device/{serialNumber}/changes")]
    public class ChangesQueueController : QueueControllerBase<object>
    {
        public ChangesQueueController(IDeviceManager deviceManager, ILogger log) : base(deviceManager, log)
        {
        }

        protected override ServerQueue<object> GetQueue(string serialNumber)
        {
            return DeviceManager.GetController(serialNumber)?.ChangesQueue;
        }
    }
}
