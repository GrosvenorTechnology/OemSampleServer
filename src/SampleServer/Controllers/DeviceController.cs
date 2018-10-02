using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using SampleServer.Domain.Protocol;
using SampleServer.Services;
using SampleServer.Utils;

namespace SampleServer.Controllers
{
    [RoutePrefix("grosvenor-oem/device/{serialNumber}")]
    public class DeviceController : ApiController
    {
        private readonly IDeviceManager _deviceManager;
        private readonly ILogger _logger;

        public DeviceController(IDeviceManager deviceManager, ILogger logger)
        {
            _deviceManager = deviceManager;
            _logger = logger;
        }


        [Route("heartbeat")]
        [HttpPost]
        public HttpResponseMessage PostHeartbeat(string serialNumber, [FromBody] string value)
        {
            var activities = Array.Empty<string>();
            _logger.Trace($"Heartbeat {serialNumber} :: Activities [{string.Join(",", activities)}]");
            return Request.CreateResponse(HttpStatusCode.OK, new HeartbeatResponse(activities));
        }

        [Route("events")]
        [HttpPost]
        public HttpResponseMessage PostEvents(string serialNumber, [FromBody] Event evt)
        {
            _logger.Trace(evt.ToString());
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        
        [Route("states")]
        [HttpPost]
        public HttpResponseMessage PostStates(string serialNumber, [FromBody] StateNotification state)
        {
            _logger.Trace(state.ToString());
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }


        [Route("commands")]
        [HttpPost]
        public HttpResponseMessage PostCommands(string serialNumber, [FromBody] CommandResponse value)
        {
            _logger.Trace(value.ToString());
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }


        [Route("bootconfiguration")]
        [HttpGet]
        public Task<HttpResponseMessage> GetBootConfiguration(string serialNumber)
        {
            _logger.Trace($"Get Boot Configuration - {serialNumber} ");

            var bootConfiguration = _deviceManager.GetController(serialNumber)?.BootConfiguration;

            if (bootConfiguration == null)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Task.FromResult(GetConfigurationResponse(bootConfiguration, bootConfiguration.MD5Hash()));
        }


        [Route("platformconfiguration")]
        [HttpGet]
        public Task<HttpResponseMessage> GetPlatformConfiguration(string serialNumber)
        {
            _logger.Trace($"Get Platform Configuration - {serialNumber} ");

            var platformConfiguration = _deviceManager.GetController(serialNumber)?.PlatformConfiguration;

            if (platformConfiguration == null)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Task.FromResult(GetConfigurationResponse(platformConfiguration, platformConfiguration.MD5Hash()));
        }

        [Route("applicationconfiguration")]
        [HttpGet]
        public Task<HttpResponseMessage> GetApplicationConfiguration(string serialNumber)
        {
            _logger.Trace($"Get Application Configuration - {serialNumber} ");

            var appConfiguration = _deviceManager.GetController(serialNumber)?.ApplicationConfiguration;

            if (appConfiguration == null)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Task.FromResult(GetConfigurationResponse(appConfiguration, appConfiguration.MD5Hash()));
        }

        protected HttpResponseMessage GetConfigurationResponse(string data, string eTag)
        {
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            HttpResponseMessage response;
            // Retrieve the If-None-Match header from the request (if it exists)
            var nonMatchEtags = Request.Headers.IfNoneMatch;
            if (nonMatchEtags.Count > 0 && nonMatchEtags.First().Tag == $"\"{eTag}\"")
            {
                response = Request.CreateResponse(HttpStatusCode.NotModified);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(data, Encoding.UTF8, JsonMediaTypeFormatter.DefaultMediaType.MediaType);
            }

            response.Headers.ETag = new EntityTagHeaderValue($"\"{eTag}\"", false);
            return response;
        }
    }
}