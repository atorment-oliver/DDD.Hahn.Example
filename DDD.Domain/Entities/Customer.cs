using MongoDB.Bson;
using DDD.Domain.Interfaces.Entities;

namespace DDD.Domain.Entities
{
    public class Customer : IEntity<ObjectId>
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public Customer(string name, string email, string address)
        {
            id = ObjectId.GenerateNewId();
            this.name = name;
            this.email = email;
            this.address = address;
        }
        public Customer(string id, string name, string email, string address)
        {
            this.id = new ObjectId(id);
            this.name = name;
            this.email = email;
            this.address = address;
        }
    }
}
