namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationTokenFormat : ApplicationEntity
    {
        public string Definition { get; set; }

        public ApplicationTokenFormat()
        {
            Type = "Hardware.TokenFormatType";
        }

        public override void SetDefaults()
        {
        }
    }
}