namespace SampleServer.Domain.ApplicationConfiguration
{
    public abstract class ApplicationHardwareEntity<T> : ApplicationCommandModeEntity<T>
        where T : struct 
    {
        public string Address { get; set; }
    }
}