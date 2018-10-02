using System;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationSiSystem : ApplicationEntity
    {
        public string[] PhysicalHardwareIds { get; set; }
        public string TokenFormatType { get; set; }
        public TimeSpan? WhitelistUpdatePeriod { get; set; } 
        public ApplicationSiGatewayNode[] Gateways { get; set; }

        public ApplicationSiSystem()
        {
            Type = "SmartIntego.System";
        }

        public override void SetDefaults()
        {
            WhitelistUpdatePeriod = WhitelistUpdatePeriod ?? TimeSpan.FromHours(1);
        }
    }
}