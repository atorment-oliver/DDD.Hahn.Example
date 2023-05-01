using MongoDB.Bson;
using DDD.Domain.Interfaces.Entities;

namespace DDD.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity<ObjectId>
    {
        void Create(T entity);
        void Delete(string id);
        void Update(T entity);
    }
}
