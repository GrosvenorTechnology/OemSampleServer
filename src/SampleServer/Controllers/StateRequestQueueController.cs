using System.Web.Http;
using NLog;
using SampleServer.Domain.Protocol;
using SampleServer.Domain.Queues;
using SampleServer.Services;

namespace SampleServer.Controllers
{
    [RoutePrefix("grosvenor-oem/device/{serialNumber}/states")]
    [Authorize]
    public class StateRequestQueueController : QueueControllerBase<StateRequest>
    {
        public StateRequestQueueController (IDeviceManager deviceManager, ILogger log) : base(deviceManager, log)
        {
        }

        protected override ServerQueue<StateRequest> GetQueue(string serialNumber)
        {
            return DeviceManager.GetController(serialNumber)?.StateRequestQueue;
        }
    }
}
