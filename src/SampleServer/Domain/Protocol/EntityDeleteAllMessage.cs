namespace SampleServer.Domain.Protocol
{
    public class EntityDeleteAllMessage
    {
        public class EntityRawType
        {
            public string Type { get; set; }
        }
        
        public EntityRawType DeleteAll { get; set; }

        public EntityDeleteAllMessage(string type)
        {
            DeleteAll = new EntityRawType {Type = type};
        }
    }
}