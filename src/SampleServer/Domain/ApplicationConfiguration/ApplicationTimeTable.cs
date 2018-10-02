using System;
using System.Collections.Generic;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationTimeTable : ApplicationEntity
    {
        public class TimeTableSpan
        {
            public TimeSpan? Start { get; set; }
            public TimeSpan? End { get; set; }
        }

        public enum ShortDow
        {
            Su, Mo, Tu, We, Th, Fr, Sa
        }

        public class TimeSet
        {
            public ShortDow[] Days { get; set; }
            public TimeTableSpan[] Periods { get; set; }
        }

        public Dictionary<string, List<TimeTableSpan>> Transitions { get; set; }
        public TimeSet[] Sets { get; set; }

        public ApplicationTimeTable()
        {
            Type = "Common.TimeTable";
        }

        public override void SetDefaults()
        {
        }
    }
}