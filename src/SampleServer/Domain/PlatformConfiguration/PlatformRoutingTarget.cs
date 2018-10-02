namespace SampleServer.Domain.PlatformConfiguration
{
    public sealed class PlatformRoutingTarget : PlatformPolledUri
    {
        public string Id { get; set; }
        public string[] Filters { get; set; } 
    }
}