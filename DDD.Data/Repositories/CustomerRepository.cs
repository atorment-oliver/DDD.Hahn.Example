using MongoDB.Driver;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using MongoDB.Bson;
using System;
using System.Reflection.Metadata;

namespace DDD.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMongoClient mongoClient)
           : base(mongoClient)
        {
           
        }
        public Customer GetByName(string name)
        {
            var customers = _database.GetCollection<Customer>("Customer");

            var filter = Builders<Customer>.Filter.Eq("Name", name);
            return  customers.Find(filter: filter).FirstOrDefault();
        }
        public Customer GetById(string id)
        {
            var customers = _database.GetCollection<Customer>("Customer");
            return customers.Find(c => c.id.ToString() == id).FirstOrDefault();
        }
        public List<Customer> GetCustomers()
        {
            var customers = _database.GetCollection<Customer>("Customer");
            return customers.Find(c => 1 == 1).ToList();
        }
    }
}
