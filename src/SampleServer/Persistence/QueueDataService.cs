using System;
using System.Collections.Generic;
using System.Linq;
using SampleServer.Domain.Queues;
using SampleServer.Persistence.QueueContext;

namespace SampleServer.Persistence
{
    public interface IQueueDataService
    {
        void Enqueue(string deviceId, int queueType, string body, DateTime timestamp);
        void RemoveMessages(IEnumerable<Guid> guidList);
        bool Any(string deviceId, int queueType);
        ICollection<QueueMessage> PeekMessages(string deviceId, int queueType, int count);
    }

    public class QueueDataService : IQueueDataService
    {
        private readonly Func<IQueueContext> _contextFactory;

        public QueueDataService(Func<IQueueContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Enqueue(string deviceId, int queueType, string body, DateTime timestamp)
        {
            using (var context = _contextFactory())
            {
                var entry = new QueueEntry(deviceId, queueType, body, timestamp);
                context.DeviceQueue.Add(entry);
                context.SaveChanges();
            }
        }

        public void RemoveMessages(IEnumerable<Guid> guidList)
        {
            using (var context = _contextFactory())
            {
                foreach (var id in guidList)
                {
                    var item = context.DeviceQueue.FirstOrDefault(x => x.MessageId == id);
                    if (item != null)
                    {
                        context.DeviceQueue.Remove(item);
                    }
                }

                context.SaveChanges();
            }
        }

        public bool Any(string deviceId, int queueType)
        {
            using (var context = _contextFactory())
            {
                return context.DeviceQueue.Any(x => x.DeviceId == deviceId && x.QueueType == queueType);
            }
        }

        public ICollection<QueueMessage> PeekMessages(string deviceId, int queueType, int count)
        {
            using (var context = _contextFactory())
            {
                return context.DeviceQueue
                    .Where(x => x.DeviceId == deviceId && x.QueueType == queueType)
                    .OrderBy(x => x.TimeStamp)
                    .Take(count)
                    .Select(x => new QueueMessage {MessageId = x.MessageId, Body = x.Body})
                    .ToList();
            }
        }
    }
}