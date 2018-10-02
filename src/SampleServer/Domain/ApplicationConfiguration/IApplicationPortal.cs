using Newtonsoft.Json;
using SampleServer.Domain.Converters;

namespace SampleServer.Domain.ApplicationConfiguration
{
    [JsonConverter(typeof(PortalTypeConverter))]
    public interface IApplicationPortal
    {
    }
}