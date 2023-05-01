using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByCPF(string cpf);
        Customer GetByName(string cpf);
        Customer GetById(string id);
        List<Customer> GetCustomers();
    }
}
