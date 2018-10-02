using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SampleServer.Domain.Protocol
{
    public class UserEntity : Entity
    {
        public class UserIdentifier
        {
            public string Type { get; set; }
            public string Id { get; set; }
            public string Description { get; set; }
            public string Data { get; set; }
        }

        public class UserVerifier
        {
            public string Type { get; set; }
            public string Id { get; set; }
            public string Description { get; set; }
            public string Data { get; set; }
            public bool Duress { get; set; }
        }

        public interface IUserPermission
        {
            string Type { get; set; }
        }

        public abstract class UserPermission<T> : IUserPermission
        {
            public string Type { get; set; }
            public T Data { get; set; }
        }

        public class AlwaysPermission : UserPermission<string>
        {
            public AlwaysPermission()
            {
                Type = "always";
            }
        }

        public class TimeTableSpan
        {
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShortDow
        {
            Su, Mo, Tu, We, Th, Fr, Sa
        }

        public class TimeSet
        {
            public ShortDow[] Days { get; set; }
            public TimeTableSpan[] Periods { get; set; }
        }

        public class CompactInlineTimePermission : UserPermission<TimeSet[]>
        {
            public CompactInlineTimePermission()
            {
                Type = "compactInlineTime";
            }
        }

        public List<string> Attributes { get; } = new List<string>();
        public List<UserIdentifier> Identifiers { get; } = new List<UserIdentifier>();
        public List<UserVerifier> Verifiers { get; } = new List<UserVerifier>();
        public Dictionary<string, List<IUserPermission>> Permissions { get; } = new Dictionary<string, List<IUserPermission>>();
    }
}