using System.Collections.Generic;

namespace SampleServer.Domain.Protocol
{
    public class HeartbeatResponse
    {
        public HeartbeatResponse(IEnumerable<string> activities)
        {
            Activity = new List<string>(activities);
        }

        public List<string> Activity { get; }
    }

   

}
