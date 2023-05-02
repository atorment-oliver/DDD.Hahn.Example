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
        /// <summary>
        /// Get a customer
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getbyid")]
        public Customer GetById(string id)
        {
            var customerRepository = new CustomerRepository(null);
            return customerRepository.GetById(id);
        }
        /// <summary>
        /// Create a customer
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="email">email</param>
        /// <param name="cpf">cpf</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
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
        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">name</param>
        /// <param name="email">email</param>
        /// <param name="cpf">cpf</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
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
        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("delete")]
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
