using System;

namespace SampleServer.Domain.BootConfiguration
{
    public sealed class Boot
    {
        public string DefaultUri { get; set; }
        public string SharedKey { get; set; }
        public string PlatformConfig { get; set; }
        public ServiceBaseUri[] Services { get; set; } = new ServiceBaseUri[0];
        public BootCustomHeader[] CustomHeaders { get; set; } = new BootCustomHeader[0];
        public BootNetwork Network { get; set; }
        public string[] Features { get; set; } = Array.Empty<string>();
    }
}