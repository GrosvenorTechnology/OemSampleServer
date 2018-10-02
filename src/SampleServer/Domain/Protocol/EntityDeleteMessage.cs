namespace SampleServer.Domain.Protocol
{
    public class EntityDeleteMessage
    {
        public class EntityRawKey
        {
            public string Type { get; set; }
            public string Id { get; set; }
        }
        
        public EntityRawKey Delete { get; set; }

        public EntityDeleteMessage(string type, string id)
        {
            Delete = new EntityRawKey {Id = id, Type = type};
        }
    }
}