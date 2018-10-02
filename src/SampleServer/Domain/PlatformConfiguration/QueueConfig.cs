namespace SampleServer.Domain.PlatformConfiguration
{
    public sealed class QueueConfig : PlatformPolledUri
    {
        public int? BatchSize { get; set; }
    }
}