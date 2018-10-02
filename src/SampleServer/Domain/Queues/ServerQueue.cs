using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SampleServer.Persistence;

namespace SampleServer.Domain.Queues
{
    public class ServerQueue<T> where T : class, new()
    {
        private readonly string _deviceId;
        private readonly int _queueType;
        private readonly IQueueDataService _dataService;
        // ReSharper disable once StaticMemberInGenericType
        private static readonly JsonSerializerSettings Settings;
        private bool _newChanges;

        static ServerQueue()
        {
            Settings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public ServerQueue(string deviceId, QueueTypes queueType, IQueueDataService context)
        {
            _deviceId = deviceId;
            _queueType = (int)queueType;
            _dataService = context;
        }

        public void Enqueue(T item)
        {
            _dataService.Enqueue(_deviceId, _queueType, JsonConvert.SerializeObject(item, Settings), DateTime.UtcNow);
        }

        public ICollection<QueueMessage> Peek(int count, IEnumerable<Guid> guidList)
        {
            var result = _dataService.PeekMessages(_deviceId, _queueType, count);
            _dataService.RemoveMessages(guidList);
            return result;
        }

        public ICollection<QueueMessage> DestructiveRead(int count)
        {
            var result = _dataService.PeekMessages(_deviceId, _queueType, count);
            if (result.Any())
            {
                _dataService.RemoveMessages(result.Select(x=>x.MessageId));
            }
            return result;
        }

        public bool PendingMessages()
        {
            return _dataService.Any(_deviceId, _queueType);
        }
    }
}
