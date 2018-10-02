namespace SampleServer.Domain.Protocol
{
    public class EntityWrapper<T>
    {
        public T Entity { get; set; }

        public EntityWrapper(T entity)
        {
            Entity = entity;
        }
    }
}