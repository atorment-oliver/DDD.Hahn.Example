using MongoDB.Driver;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DDD.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMongoClient mongoClient)
           : base(mongoClient)
        {
           
        }

        public Customer GetByCPF(string cpf)
        {
            var customers = _database.GetCollection<Customer>("customer");
            return customers.Find(c => c.CPF == cpf).FirstOrDefault();
        }

        public Customer GetByName(string cpf)
        {
            var customers = _database.GetCollection<Customer>("customer");
            return customers.Find(c => c.CPF == cpf).FirstOrDefault();
        }
        public Customer GetById(string id)
        {
            var customers = _database.GetCollection<Customer>("customer");
            return customers.Find(c => c.Id.ToString() == id).FirstOrDefault();
        }
        public List<Customer> GetCustomers()
        {
            var customers = _database.GetCollection<Customer>("customer");
            return customers.Find(c => 1 == 1).ToList();
        }
    }
}
