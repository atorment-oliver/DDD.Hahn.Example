using DDD.Domain.Entities;
using DDD.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using System.Xml.Linq;

namespace DDD.WebApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            var customerRepository = new CustomerRepository(null);
            return customerRepository.GetCustomers().ToArray();
        }
        [HttpGet("{id}")]
        public Customer GetById(string id)
        {
            var customerRepository = new CustomerRepository(null);
            return customerRepository.GetById(id);
        }
        [HttpPost]
        public bool Create(string name, string email, string cpf)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                Customer objCustomer = new Customer(name, email, cpf);
                customerRepository.Create(objCustomer);
                return true;
            }
            catch (Exception error)
            { 
                return false;
            }
        }
        [HttpPost]
        public bool Update(string id, string name, string email, string cpf)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                Customer objCustomer = new Customer(id, name, email, cpf);
                customerRepository.Update(objCustomer);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        [HttpPost]
        public bool Delete(string id)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                customerRepository.Delete(id);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
    }
}
