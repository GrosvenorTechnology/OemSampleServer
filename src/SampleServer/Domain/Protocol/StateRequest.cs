using System;

namespace SampleServer.Domain.Protocol
{
    public class StateRequest : IMessageWithId
    {
        public Guid MessageId { get; set; }
        public Guid CorrelationId { get; set; }
        public string Entity { get; set; }
        public string StateName { get; set; }
    }
}
