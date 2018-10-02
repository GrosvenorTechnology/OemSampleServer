using System;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationOsdpReader : ApplicationHardwareEntity<OsdpReaderOperationalMode>, IApplicationReader
    {
        public string OsdpDeviceKey { get; set; }
        public string TokenFormatType { get; set; }
        public TimeSpan? EnterPinPeriod { get; set; }
        public int? DigitsForPin { get; set; } 
        public string[] ChangeModePermissions { get; set; }
        public TimeSpan? ValidReadLedPeriod { get; set; } 
        public TimeSpan? ValidReadBeeperPeriod { get; set; } 
        public TimeSpan? InvalidReadBeeperPeriod { get; set; } 
        public string InvalidReadBeeperMode { get; set; } 
        public string BeepOnValidRead { get; set; } 
        public string IdleLedMode { get; set; } 
        public string IdleLedOnColour { get; set; } 
        public string IdleLedOffColour { get; set; } 

        public ApplicationOsdpReader()
        {
            Type = "Osdp.Reader";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? OsdpReaderOperationalMode.TokenOnly;
            TokenFormatType = TokenFormatType ?? "RDSATEONPRO";
            EnterPinPeriod = EnterPinPeriod ?? TimeSpan.FromSeconds(20);
            DigitsForPin = DigitsForPin ?? 4;
            ValidReadLedPeriod = ValidReadLedPeriod ?? TimeSpan.FromSeconds(3);
            ValidReadBeeperPeriod = ValidReadBeeperPeriod ?? TimeSpan.FromMilliseconds(200);
            InvalidReadBeeperPeriod = InvalidReadBeeperPeriod ?? TimeSpan.FromSeconds(3);
            InvalidReadBeeperMode = InvalidReadBeeperMode ?? "urgentPulse";
            BeepOnValidRead = BeepOnValidRead ?? "impairedSight";
            IdleLedMode = IdleLedMode ?? "nonUrgentPulse";
            IdleLedOnColour = IdleLedOnColour ?? "amber";
            IdleLedOffColour = IdleLedOffColour ?? "off";
        }
    }
}