using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationOutput : ApplicationHardwareEntity<OutputOperationalMode>
    {
        public TimeSpan? PulseLength { get; set; } 

        [JsonConverter(typeof(StringEnumConverter))]
        public OutputMode? DefaultOutputMode { get; set; } 

        [JsonConverter(typeof(StringEnumConverter))]
        public DriveType? OutputStateType { get; set; } 

        public string[] CommandPermissions { get; set; }

        public string[] ChangeModePermissions { get; set; }


        public ApplicationOutput()
        {
            Type = "Hardware.Output";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? OutputOperationalMode.Normal;
            PulseLength = PulseLength ?? TimeSpan.FromSeconds(1);
            DefaultOutputMode = DefaultOutputMode ?? OutputMode.Constant;
            OutputStateType = OutputStateType ?? DriveType.ActiveHigh;
        }

        public override void ClearDefaults()
        {
            Type = Type == "Hardware.Output" ? null : Type;
            OperationalMode = OperationalMode == OutputOperationalMode.Normal ? null : OperationalMode;
            PulseLength = PulseLength == TimeSpan.FromSeconds(1) ? null : PulseLength;
            DefaultOutputMode = DefaultOutputMode == OutputMode.Constant ? null : DefaultOutputMode;
            OutputStateType = OutputStateType == DriveType.ActiveHigh ? null : OutputStateType;
        }
    }
}