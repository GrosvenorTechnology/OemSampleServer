using System;
using System.Collections.Generic;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationAction : ApplicationCommandModeEntity<ActionOperationalMode>
    {
        public class CommandDefinition
        {
            public string Command { get; set; }
            public Dictionary<string, object> Arguments { get; set; } = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }

        public class EventToCommand : CommandDefinition
        {
            public string Event { get; set; }
        }

        public string SourceType { get; set; }
        public string[] SourceIds { get; set; }
        public string TargetType { get; set; }
        public string[] TargetIds { get; set; }

        public string PermissionsFrom { get; set; } 
        public string ReferenceFrom { get; set; } 

        public EventToCommand[] Map { get; set; }
        public CommandDefinition RestoreCommand { get; set; }

        public ApplicationAction()
        {
            Type = "Common.Action";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? ActionOperationalMode.Enabled;
            PermissionsFrom = PermissionsFrom ?? "none";
            ReferenceFrom = ReferenceFrom ?? "source";
        }
    }
}