namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationSiGatewayNode : ApplicationEntity
    {
        public string IpAddress { get; set; }
        public uint? Bus { get; set; }
        public string EncryptionKey { get; set; }
        public ApplicationSiGatewayNode()
        {
            Type = "SmartIntego.GatewayNode";
        }

        public override void SetDefaults()
        {
        }
    }
}