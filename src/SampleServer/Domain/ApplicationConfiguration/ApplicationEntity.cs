namespace SampleServer.Domain.ApplicationConfiguration
{
    public abstract class ApplicationEntity
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Type { get; protected set; }

        public abstract void SetDefaults();

        public virtual void ClearDefaults()
        { }
    }
}