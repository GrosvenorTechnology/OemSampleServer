using System.Collections.Generic;
using SampleServer.Domain.Protocol;
using SampleServer.Domain.Queues;

namespace SampleServer.Services
{
    public interface IDevice
    {
        ServerQueue<StateRequest> StateRequestQueue { get; }
        ServerQueue<Command> CommandRequestQueue { get; }
        ServerQueue<object> ChangesQueue { get; }

        string BootConfiguration { get; }
        string PlatformConfiguration { get; }
        string ApplicationConfiguration { get; }
        string SharedKey { get; } 
        void SendCommand(string commandName, string targetId,  Dictionary<string, string> parameters);
        void RequestState(string stateName, string targetId);
        void DeleteAllOfType(string entityType);
        void ReconcileEntitiesOfType(string entityType, IEnumerable<string> ids);
        void DeleteEntity(string entityType, string entityId);
        void SendEntityUpdate(UserEntity user);
    }
}