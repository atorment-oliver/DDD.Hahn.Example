using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace DDD.WebApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Get customers
        /// </summary>
        [HttpGet]
        [Route("Customer")]
        [Produces("application/json")]
        public ActionResult GetAll()
        {
            var customerRepository = new CustomerRepository(null);
            return Ok(customerRepository.GetCustomers());
        }
        /// <summary>
        /// Get a customer
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Customer/{id}")]
        [Produces("application/json")]
        public ActionResult GetById(string id)
        {
            var customerRepository = new CustomerRepository(null);
            return Ok(customerRepository.GetById(id));
        }
        /// <summary>
        /// Create a customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Customer")]
        public bool Create([FromBody] Customer customer)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                DDD.Domain.Entities.Customer objCustomer = new DDD.Domain.Entities.Customer(customer.name, customer.email, customer.address);
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
        /// <param name="customer">customer</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Customer/{id}")]
        public bool Update(string id, [FromBody] Customer customer)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                DDD.Domain.Entities.Customer objCustomer = new DDD.Domain.Entities.Customer(id, customer.name, customer.email, customer.address);
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
        [HttpDelete]
        [Route("Customer/{id}")]
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
