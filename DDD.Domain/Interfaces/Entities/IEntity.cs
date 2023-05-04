namespace DDD.Domain.Interfaces.Entities
{
    public interface IEntity<TKey>
    {
        TKey id { get; set; }
    }  
}
