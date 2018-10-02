namespace SampleServer.Domain.BootConfiguration
{
    public sealed class BootNetwork
    {
        public BootNetworkAdapter Eth0 { get; set; }
        public string PrimaryDns { get; set; }
        public string SecondaryDns { get; set; }
        public string NtpServer { get; set; }
        public bool? SshEnabled { get; set; }
    }
}