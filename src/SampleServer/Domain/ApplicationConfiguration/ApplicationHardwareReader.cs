using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationHardwareReader : ApplicationHardwareEntity<ReaderOperationalMode>, IApplicationReader
    {
        public string TokenFormatType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DriveType? ValidLedType { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public DriveType? BeeperType { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public InputTypeDisableable? ReaderTamperType { get; set; } 
        public TimeSpan? EnterPinPeriod { get; set; } 
        public int? DigitsForPin { get; set; } 
        public TimeSpan? ValidReadLedPeriod { get; set; }
        public TimeSpan? ValidReadBeeperPeriod { get; set; } 
        public TimeSpan? InvalidReadBeeperPeriod { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public OutputMode? InvalidReadBeeperMode { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public ReaderBeepOnValidMode? BeepOnValidRead { get; set; } 
        public string[] ChangeModePermissions { get; set; }

        public ApplicationHardwareReader()
        {
            Type = "Hardware.Reader";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? ReaderOperationalMode.TokenOnly;
            TokenFormatType = TokenFormatType ?? "RDSATEONPRO";
            ValidLedType = ValidLedType ?? DriveType.ActiveHigh;
            BeeperType = BeeperType ?? DriveType.ActiveHigh;
            ReaderTamperType = ReaderTamperType ?? InputTypeDisableable.Unsupervised;
            EnterPinPeriod = EnterPinPeriod ?? TimeSpan.FromSeconds(20);
            DigitsForPin = DigitsForPin ?? 4;
            ValidReadLedPeriod = ValidReadLedPeriod ?? TimeSpan.FromSeconds(3);
            ValidReadBeeperPeriod = ValidReadBeeperPeriod ?? TimeSpan.FromMilliseconds(200);
            InvalidReadBeeperPeriod = InvalidReadBeeperPeriod ?? TimeSpan.FromSeconds(3);
            InvalidReadBeeperMode = InvalidReadBeeperMode ?? OutputMode.UrgentPulse;
            BeepOnValidRead = BeepOnValidRead ?? ReaderBeepOnValidMode.ImpairedSight;
        }

        public override void ClearDefaults()
        {
            Type = Type == "Hardware.Reader" ? null : Type;
            OperationalMode = OperationalMode == ReaderOperationalMode.TokenOnly ? null : OperationalMode;
            TokenFormatType = TokenFormatType == "RDSATEONPRO" ? null : TokenFormatType;
            ValidLedType = ValidLedType == DriveType.ActiveHigh ? null : ValidLedType;
            BeeperType = BeeperType == DriveType.ActiveHigh ? null : BeeperType;
            ReaderTamperType = ReaderTamperType == InputTypeDisableable.Unsupervised ? null : ReaderTamperType;
            EnterPinPeriod = EnterPinPeriod == TimeSpan.FromSeconds(20) ? null : EnterPinPeriod;
            DigitsForPin = DigitsForPin == 4 ? null : DigitsForPin;
            ValidReadLedPeriod = ValidReadLedPeriod == TimeSpan.FromSeconds(3) ? null : ValidReadLedPeriod;
            ValidReadBeeperPeriod = ValidReadBeeperPeriod == TimeSpan.FromMilliseconds(200) ? null : ValidReadBeeperPeriod;
            InvalidReadBeeperPeriod = InvalidReadBeeperPeriod == TimeSpan.FromSeconds(3) ? null : InvalidReadBeeperPeriod;
            InvalidReadBeeperMode = InvalidReadBeeperMode == OutputMode.UrgentPulse ? null : InvalidReadBeeperMode;
            BeepOnValidRead = BeepOnValidRead == ReaderBeepOnValidMode.ImpairedSight ? null : BeepOnValidRead;
        }
    }
}