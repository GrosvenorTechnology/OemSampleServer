using System.Web.Http;
using NLog;
using SampleServer.Domain.Queues;
using SampleServer.Services;
using Command = SampleServer.Domain.Protocol.Command;

namespace SampleServer.Controllers
{
    [RoutePrefix("grosvenor-oem/device/{serialNumber}/commands")]
    //[Authorize]
    public class CommandQueueController : QueueControllerBase<Command>
    {
        public CommandQueueController (IDeviceManager deviceManager, ILogger log) : base(deviceManager, log)
        {
        }

        protected override ServerQueue<Command> GetQueue(string serialNumber)
        {
            return DeviceManager.GetController(serialNumber)?.CommandRequestQueue;
        }
    }
}
