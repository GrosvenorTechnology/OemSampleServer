namespace SampleServer.Domain.Protocol
{
    public abstract class Entity 
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
    }
}