using DDD.Domain.Entities;
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
        [Route("customer")]
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
        [Route("customer/{id}")]
        [Produces("application/json")]
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
        /// <param name="address">address</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create/customer")]
        public bool Create(string name, string email, string address)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                Customer objCustomer = new Customer(name, email, address);
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
        /// <param name="address">address</param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/customer")]
        public bool Update(string id, string name, string email, string address)
        {
            var customerRepository = new CustomerRepository(null);
            try
            {
                Customer objCustomer = new Customer(id, name, email, address);
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
