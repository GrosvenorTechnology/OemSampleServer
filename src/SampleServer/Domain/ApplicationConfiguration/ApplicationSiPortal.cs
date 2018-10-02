using System;
using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationSiPortal : ApplicationHardwareEntity<SmartIntegoPortalOperationalMode>, IApplicationPortal
    {
        public class SiDirection
        {
            public string[] AccessPermissions { get; set; }
            public string[] Areas { get; set; }
            public string[] Readers { get; set; }
        }

        public string[] OfflineWhitelistTags { get; set; }
        public string[] LocalWhitelistTags { get; set; }
        public SiDirection Entry { get; set; }
        public SiDirection Exit { get; set; }
        public string[] VerifyInAreas { get; set; }
        public string[] VerifyOutOfAreas { get; set; }
        public ModeChangingEntity UnlockOnTimeTable { get; set; }
        public ModeChangingEntity UnlockOnSystemMode { get; set; }
        public ModeChangingEntity NormalOnSystemMode { get; set; }
        public string ShortWakeupTimeTable { get; set; }
        public string[] OfficeModePermissions { get; set; }
        public TimeSpan? OfficeModeDuration { get; set; }

        public ApplicationSiPortal()
        {
            Type = "SmartIntego.Portal";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? SmartIntegoPortalOperationalMode.Normal;
            OfficeModeDuration = OfficeModeDuration ?? TimeSpan.FromHours(4);
        }
    }
}