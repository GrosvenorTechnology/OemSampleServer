using System.Collections.Generic;

namespace SampleServer.Domain.Protocol
{
    public class EntityReconcileMessage
    {
        public class EntityReconcile
        {
            public string Type { get; set; }
            public List<string> Keys { get; set; }
        }

        public EntityReconcile Reconcile { get; set; }
    }
}