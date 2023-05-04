using MongoDB.Bson;
using MongoDB.Driver;
using DDD.Domain.Interfaces.Entities;

namespace DDD.Infrastructure.Repositories
{
    public class Repository<T> where T : IEntity<ObjectId>
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;

        public Repository(IMongoClient mongoClient)
        {
            //_mongoClient = mongoClient;
            var connectionString = "mongodb://root:secret@192.168.1.188:27017?readPreference=primary&appname=MongoDB%20Compass&ssl=false";
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("mydb");
        }

        public void Create(T entity)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(entity);
        }

        public void Delete(string id)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.DeleteOne(c => c.id.ToString() == id);
        }

        public void Update(T entity)
        {
            var customers = _database.GetCollection<T>(typeof(T).Name);
            customers.ReplaceOne(Builders<T>.Filter.Eq(r => r.id, entity.id), entity, new UpdateOptions() { IsUpsert = true });
        }
    }
}
