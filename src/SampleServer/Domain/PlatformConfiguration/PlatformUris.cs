namespace SampleServer.Domain.PlatformConfiguration
{
    public sealed class PlatformUris
    {
        public PlatformPolledUri Firmware { get; set; }
        public PlatformPolledUri[] Heartbeat { get; set; } 
        public string[] HardwareReport { get; set; }
        public PlatformPolledUri BootConfig { get; set; }
        public PlatformPolledUri PlatformConfig { get; set; }
        public PlatformPolledUri ApplicationConfig { get; set; }
        public QueueConfig StateQueue { get; set; }
        public QueueConfig CommandQueue { get; set; }
        public QueueConfig ChangeQueue { get; set; }
        public PlatformRoutingTarget[] EventSubmission { get; set; } 
        public PlatformRoutingTarget[] StateSubmission { get; set; } 
        public PlatformRoutingTarget[] CommandResponseSubmission { get; set; } 
    }
}