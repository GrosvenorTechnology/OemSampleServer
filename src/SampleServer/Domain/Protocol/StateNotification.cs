using System;

namespace SampleServer.Domain.Protocol
{
    public enum StateNotificationType
    {
        StateChange,
        StateRequest,
        PeriodicUpdate,
        DeltaChangeUpdate
    }

    public class StateNotification
    {
        public override string ToString()
        {
            return $@"
        [LastChanged]  : {LastChanged:O}
        [Entity]       : {Entity}
        [StateName]    : {StateName}
        [StateType]    : {StateNotificationType}
        [StateValue]   : {StateValue}
        [Diagnostic]   : {DiagState}";
        }

        public Guid MessageId { get; set; }
        public Guid CorrelationId { get; set; }
        public Guid? PreviousMessageId { get; set; }
        public string Entity { get; set; }
        public string StateName { get; set; }
        public string StateValue { get; set; }
        public StateNotificationType StateNotificationType { get; set; }
        public bool DiagState { get; set; }
        public DateTimeOffset LastChanged { get; set; }
    }
}
