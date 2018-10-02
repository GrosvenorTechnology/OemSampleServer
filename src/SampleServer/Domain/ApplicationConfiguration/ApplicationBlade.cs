using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationBlade : ApplicationHardwareEntity<BladeOperationalMode>
    {
        public ushort? V12CurrentLimit { get; set; } 
        public ushort? V12CurrentMinimum { get; set; } 
        public ushort? V12CurrentMaximum { get; set; } 
        public ushort? LockVoltageMinimum { get; set; } 
        public ushort? LockVoltageMaximum { get; set; } 
        public string LockPowerSource { get; set; } 
        public string OsdpMKey { get; set; }
        public bool? OsdpTerminate { get; set; } 
        public string OsdpBaudRate { get; set; } 

        public ApplicationBlade()
        {
            Type = "Hardware.Blade";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? BladeOperationalMode.Normal;
            V12CurrentLimit = V12CurrentLimit ?? 2000;
            V12CurrentMinimum = V12CurrentMinimum ?? 2;
            V12CurrentMaximum = V12CurrentMaximum ?? 1900;
            LockVoltageMinimum = LockVoltageMinimum ?? 11000;
            LockVoltageMaximum = LockVoltageMaximum ?? 14000;
            LockPowerSource = LockPowerSource ?? "auto";
            OsdpTerminate = OsdpTerminate ?? false;
            OsdpBaudRate = OsdpBaudRate ?? "baudDisabled";
        }
    }
}