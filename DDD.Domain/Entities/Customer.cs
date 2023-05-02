using MongoDB.Bson;
using DDD.Domain.Interfaces.Entities;

namespace DDD.Domain.Entities
{
    public class Customer : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        public Customer(string name, string email, string address)
        {
            Id = ObjectId.GenerateNewId();
            this.Name = name;
            this.Email = email;
            this.Address = address;
        }
        public Customer(string id, string name, string email, string address)
        {
            this.Id = new ObjectId(id);
            this.Name = name;
            this.Email = email;
            this.Address = address;
        }
    }
}
