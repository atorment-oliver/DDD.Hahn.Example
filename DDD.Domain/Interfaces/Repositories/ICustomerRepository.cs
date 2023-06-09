﻿using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByName(string name);
        Customer GetById(string id);
        List<Customer> GetCustomers();
    }
}
