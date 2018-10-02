using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationSiReader : ApplicationHardwareEntity<SmartIntegoReaderOperationalMode>, IApplicationReader
    {
        public ApplicationSiReader()
        {
            Type = "SmartIntego.Reader";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? SmartIntegoReaderOperationalMode.TokenOnly;
        }
    }
}