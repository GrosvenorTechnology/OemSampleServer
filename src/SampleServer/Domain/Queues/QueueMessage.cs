using System;
using Newtonsoft.Json;
using SampleServer.Utils;

namespace SampleServer.Domain.Queues
{
    public class QueueMessage
    {
        public Guid MessageId { get; set; }

        [JsonConverter(typeof(RawStringConverter))]
        public string Body { get; set; }
    }
}
