using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using SampleServer.Domain.Queues;
using SampleServer.Services;

namespace SampleServer.Controllers
{
    public abstract class QueueControllerBase<T> : ApiController where T : class, new()
    {
        protected readonly IDeviceManager DeviceManager;
        protected readonly ILogger Logger;

        protected QueueControllerBase(IDeviceManager deviceManager, ILogger logger)
        {
            DeviceManager = deviceManager;
            Logger = logger;
        }

        [Route("messages/head")]
        //[Authorize]
        [HttpDelete]
        public HttpResponseMessage GetMessages(string serialNumber, int count = 1)
        {
            if (count < 1)
            {
                return Request.CreateResponse(400);
            }

            var data = GetQueue(serialNumber)?.DestructiveRead(count);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Logger.Trace($"Returning {data.Count} items from {GetType().Name} :: {serialNumber}");
            return Request.CreateResponse(data);
        }

        [Route("messages/head")]
        //[Authorize]
        [HttpPost]
        public HttpResponseMessage PeekStateMessages(string serialNumber, [FromBody]List<Guid> guidList, int count = 1)
        {
            if (count < 1)
            {
                return Request.CreateResponse(400);
            }

            var data = GetQueue(serialNumber)?.DestructiveRead(count);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Logger.Trace($"Returning {data.Count} items from {GetType().Name} :: {serialNumber}");
            return Request.CreateResponse(data);
        }

        protected abstract ServerQueue<T> GetQueue(string serialNumber);
    }
}
