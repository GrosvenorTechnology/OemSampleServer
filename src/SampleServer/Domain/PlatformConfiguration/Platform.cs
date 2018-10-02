namespace SampleServer.Domain.PlatformConfiguration
{
    public sealed class Platform
    {
        public string ApplicationVersion { get; set; }
        public string FirmwareVersion { get; set; }
        public int ProtocolLevel { get; set; } = 1;
        public ServiceBaseUri[] Services { get; set; } 
        public PlatformUris Uris { get; set; }
        public int? DefaultPollFrequency { get; set; } 
        public int? DefaultQueueBatchSize { get; set; } 
    }
}