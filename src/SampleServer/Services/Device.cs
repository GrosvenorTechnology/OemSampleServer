using System;
using System.Collections.Generic;
using System.Linq;
using SampleServer.Domain.Protocol;
using SampleServer.Domain.Queues;
using SampleServer.Persistence;

namespace SampleServer.Services
{
    public class Device : IDevice
    {
        public ServerQueue<StateRequest> StateRequestQueue { get; } 
        public ServerQueue<Command> CommandRequestQueue { get; }
        public ServerQueue<object> ChangesQueue { get; }
        public string BootConfiguration { get; } 
        public string PlatformConfiguration { get; }
        public string ApplicationConfiguration { get; }

        public Device(string serialNumber, IQueueDataService dataService)
        {
            StateRequestQueue = new ServerQueue<StateRequest>(serialNumber, QueueTypes.State, dataService);
            CommandRequestQueue = new ServerQueue<Command>(serialNumber, QueueTypes.Command, dataService);
            ChangesQueue = new ServerQueue<object>(serialNumber, QueueTypes.Change, dataService);
        }

        public void SendCommand(string commandName, string targetId,  Dictionary<string, string> parameters)
        {

            var cmd = new Command()
            {
                MessageId = Guid.NewGuid(),
                CorrelationId = Guid.NewGuid(),
                PreviousMessageId = null,
                TimeStamp = DateTimeOffset.Now,
                Ttl = TimeSpan.FromMinutes(5),
                Entity = targetId,
                CommandName = commandName,
                RequestingEntity = "System.Server:SampleServer",
                PermissionedEntity = ""
            };

            foreach (var item in parameters ?? Enumerable.Empty<KeyValuePair<string,string>>())
            {
                cmd.Parameters.Add(item.Key, item.Value);
            }
               

            CommandRequestQueue.Enqueue(cmd);
        }


        public void RequestState(string stateName, string targetId)
        {
            var req = new StateRequest
            {
                MessageId = Guid.NewGuid(),
                CorrelationId = Guid.NewGuid(),
                Entity = targetId,
                StateName = stateName
            };

            StateRequestQueue.Enqueue(req);
        }

        public void DeleteAllOfType(string entityType)
        {
            ChangesQueue.Enqueue(new EntityDeleteAllMessage(entityType));
        }

        public void ReconcileEntitiesOfType(string entityType, IEnumerable<string> ids)
        {
            ChangesQueue.Enqueue(new EntityReconcileMessage
            {
                Reconcile = new EntityReconcileMessage.EntityReconcile
                {
                    Type = entityType,
                    Keys = new List<string>(ids)
                }
            });
        }

        public void DeleteEntity(string entityType, string entityId)
        {
            ChangesQueue.Enqueue(new EntityDeleteMessage(entityType, entityId));
        }


        public void SendEntityUpdate(UserEntity user)
        {
            //Use can use the same mechanism to send any entity type the system knows about, i.e. TimeTables
            ChangesQueue.Enqueue(new EntityWrapper<UserEntity>(user));
        }
    }
}