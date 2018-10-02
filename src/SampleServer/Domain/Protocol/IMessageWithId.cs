using System;

namespace SampleServer.Domain.Protocol
{
    public interface IMessageWithId
    {
        Guid MessageId { get; }
    }
}