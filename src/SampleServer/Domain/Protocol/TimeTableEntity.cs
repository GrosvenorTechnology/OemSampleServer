using System;
using System.Collections.Generic;

namespace SampleServer.Domain.Protocol
{
    public class TimeTableEntity : Entity
    {
        public class TimeTableSpan
        {
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
        }

        public Dictionary<string, List<TimeTableSpan>> Transitions { get; set; }
    }
}