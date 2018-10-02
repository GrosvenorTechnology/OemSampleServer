using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public abstract class ApplicationCommandModeEntity<T> : ApplicationEntity
        where T : struct 
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public T? OperationalMode { get; set; }
    }
}