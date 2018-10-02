using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationHardwarePortal : ApplicationHardwareEntity<PortalOperationalMode>, IApplicationPortal
    {
        public class PortalDirection
        {
            public string[] Readers { get; set; }
            public string[] AccessPermissions { get; set; }
            public string[] EscortedPermissions { get; set; }
            public string[] EscortPermissions { get; set; }
            public string[] Areas { get; set; }
        }

        public bool? RequestExitEnabled { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PortalLockType? LockType { get; set; } 
        public bool? UseAuxOutputForLock { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PortalRelockMode? RelockMode { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public PortalLockDetectionType? LockDetectionType { get; set; } 

        [JsonConverter(typeof(StringEnumConverter))]
        public InputTypeSimple? SensorType { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public InputType? SwitchType { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public InputTypeSimple? BreakGlass { get; set; } 

        public TimeSpan? NormalUnlockPeriod { get; set; }
        public TimeSpan? ExtendedUnlockPeriod { get; set; } 
        public TimeSpan? NormalMinimumOpenPeriod { get; set; } 
        public TimeSpan? ExtendedMinimumOpenPeriod { get; set; } 
        public TimeSpan? NormalOpenTooLongPeriod { get; set; } 
        public TimeSpan? ExtendedOpenTooLongPeriod { get; set; }
        public OutputModeDisableable? ForcedSounderMode { get; set; } 
        public TimeSpan? ForcedSounderPeriod { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public OutputModeDisableable? OpenTooLongSounderMode { get; set; } 
        public TimeSpan? OpenTooLongSounderPeriod { get; set; } 

        public int? LockCurrentLimit { get; set; } 
        public int? LockWarningCurrentMinimum { get; set; } 
        public int? LockWarningCurrentMaximum { get; set; }

        public PortalDirection Entry { get; set; }
        public PortalDirection Exit { get; set; }

        public string[] VerifyInAreas { get; set; }
        public string[] VerifyOutOfAreas { get; set; }

        public string PortalInterlock { get; set; }

        public ModeChangingEntity UnlockOnTimeTable { get; set; }
        public ModeChangingEntity UnlockOnSystemMode { get; set; }
        public ModeChangingEntity NormalOnSystemMode { get; set; }

        public string[] SingleUnlockPermissions { get; set; }
        public string[] ChangeModePermissions { get; set; }

        public ApplicationHardwarePortal()
        {
            Type = "AccessControl.Portal";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? PortalOperationalMode.Normal;
            RequestExitEnabled = RequestExitEnabled ?? false;
            LockType = LockType ?? PortalLockType.EnergiseToLock;
            UseAuxOutputForLock = UseAuxOutputForLock ?? false;
            RelockMode = RelockMode ?? PortalRelockMode.OnPortalOpen;
            LockDetectionType = LockDetectionType ?? PortalLockDetectionType.Disable;
            SensorType = SensorType ?? InputTypeSimple.Disabled;
            SwitchType = SwitchType ?? InputType.Unsupervised;
            BreakGlass = BreakGlass ?? InputTypeSimple.Disabled;
            NormalUnlockPeriod = NormalUnlockPeriod ?? TimeSpan.FromSeconds(5);
            ExtendedUnlockPeriod = ExtendedUnlockPeriod ?? TimeSpan.FromSeconds(10);
            NormalMinimumOpenPeriod = NormalMinimumOpenPeriod ?? TimeSpan.FromSeconds(2);
            ExtendedMinimumOpenPeriod = ExtendedMinimumOpenPeriod ?? TimeSpan.FromSeconds(4);
            NormalOpenTooLongPeriod = NormalOpenTooLongPeriod ?? TimeSpan.FromSeconds(30);
            ExtendedOpenTooLongPeriod = ExtendedOpenTooLongPeriod ?? TimeSpan.FromSeconds(60);
            ForcedSounderMode = ForcedSounderMode ?? OutputModeDisableable.UrgentPulse;
            ForcedSounderPeriod = ForcedSounderPeriod ?? TimeSpan.FromSeconds(20);
            OpenTooLongSounderMode = OpenTooLongSounderMode ?? OutputModeDisableable.NonUrgentPulse;
            OpenTooLongSounderPeriod = OpenTooLongSounderPeriod ?? TimeSpan.FromSeconds(10);
            LockCurrentLimit = LockCurrentLimit ?? 4000;
            LockWarningCurrentMinimum = LockWarningCurrentMinimum ?? 20;
            LockWarningCurrentMaximum = LockWarningCurrentMaximum ?? 3000;
        }

        public override void ClearDefaults()
        {
            Type = Type == "AccessControl.Portal" ? null : Type;
            OperationalMode = OperationalMode == PortalOperationalMode.Normal ? null : OperationalMode;
            RequestExitEnabled = RequestExitEnabled == false ? null : RequestExitEnabled;
            LockType = LockType == PortalLockType.EnergiseToLock ? null : LockType;
            UseAuxOutputForLock = UseAuxOutputForLock == false ? null : UseAuxOutputForLock;
            RelockMode = RelockMode == PortalRelockMode.OnPortalOpen ? null : RelockMode;
            LockDetectionType = LockDetectionType == PortalLockDetectionType.Disable ? null : LockDetectionType;
            SensorType = SensorType == InputTypeSimple.Disabled ? null : SensorType;
            SwitchType = SwitchType == InputType.Unsupervised ? null : SwitchType;
            BreakGlass = BreakGlass == InputTypeSimple.Disabled ? null : BreakGlass;
            NormalUnlockPeriod = NormalUnlockPeriod == TimeSpan.FromSeconds(5) ? null : NormalUnlockPeriod;
            ExtendedUnlockPeriod = ExtendedUnlockPeriod == TimeSpan.FromSeconds(10) ? null : ExtendedUnlockPeriod;
            NormalMinimumOpenPeriod = NormalMinimumOpenPeriod == TimeSpan.FromSeconds(2) ? null : NormalMinimumOpenPeriod;
            ExtendedMinimumOpenPeriod = ExtendedMinimumOpenPeriod == TimeSpan.FromSeconds(4) ? null : ExtendedMinimumOpenPeriod;
            NormalOpenTooLongPeriod = NormalOpenTooLongPeriod == TimeSpan.FromSeconds(30) ? null : NormalOpenTooLongPeriod;
            ExtendedOpenTooLongPeriod = ExtendedOpenTooLongPeriod == TimeSpan.FromSeconds(60) ? null : ExtendedOpenTooLongPeriod;
            ForcedSounderMode = ForcedSounderMode == OutputModeDisableable.UrgentPulse ? null : ForcedSounderMode;
            ForcedSounderPeriod = ForcedSounderPeriod == TimeSpan.FromSeconds(20) ? null : ForcedSounderPeriod;
            OpenTooLongSounderMode = OpenTooLongSounderMode == OutputModeDisableable.NonUrgentPulse ? null : OpenTooLongSounderMode;
            OpenTooLongSounderPeriod = OpenTooLongSounderPeriod == TimeSpan.FromSeconds(10) ? null : OpenTooLongSounderPeriod;
            LockCurrentLimit = LockCurrentLimit == 4000 ? null : LockCurrentLimit;
            LockWarningCurrentMinimum = LockWarningCurrentMinimum == 20 ? null : LockWarningCurrentMinimum;
            LockWarningCurrentMaximum = LockWarningCurrentMaximum == 3000 ? null : LockWarningCurrentMaximum;
        }
    }
}