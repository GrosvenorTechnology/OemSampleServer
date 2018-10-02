using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationInput : ApplicationHardwareEntity<InputOperationalMode>
    {
        public bool? NormallyOpen { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public InputType? InputType { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public InputOperationType? InputOperationType { get; set; } 
        public TimeSpan? PirInhibit { get; set; } 
        public TimeSpan? PirFault { get; set; }

        public string[] ChangeModePermissions { get; set; }

        public ApplicationInput()
        {
            Type = "Hardware.Input";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? InputOperationalMode.Enabled;
            NormallyOpen = NormallyOpen ?? true;
            InputType = InputType ?? Enums.InputType.Unsupervised;
            InputOperationType = InputOperationType ?? Enums.InputOperationType.Normal;
            PirInhibit = PirInhibit ?? TimeSpan.FromSeconds(30);
            PirFault = PirFault ?? TimeSpan.FromSeconds(60);
        }

        public override void ClearDefaults()
        {
            Type = Type == "Hardware.Input" ? null : Type;
            OperationalMode = OperationalMode == InputOperationalMode.Enabled ? null : OperationalMode;
            NormallyOpen = NormallyOpen == true ? null : NormallyOpen;
            InputType = InputType == Enums.InputType.Unsupervised ? null : InputType;
            InputOperationType = InputOperationType == Enums.InputOperationType.Normal ? null : InputOperationType;
            PirInhibit = PirInhibit == TimeSpan.FromSeconds(30) ? null : PirInhibit;
            PirFault = PirFault == TimeSpan.FromSeconds(60) ? null : PirFault;
        }
    }
}