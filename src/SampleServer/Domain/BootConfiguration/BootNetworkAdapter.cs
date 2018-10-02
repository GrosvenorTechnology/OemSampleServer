namespace SampleServer.Domain.BootConfiguration
{
    public sealed class BootNetworkAdapter
    {
        public string Address { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
    }
}