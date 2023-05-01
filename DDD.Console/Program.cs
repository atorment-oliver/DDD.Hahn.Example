using DDD.Infrastructure.Repositories;
using DDD.Domain.Contracts;
using DDD.Domain.Entities;
using MongoDB.Bson;
using System;

namespace DDD.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            //var customer = new Customer("john smith", "john@gmail.com", "30324510004");
            //var validator = new CustomerValidator();
            //var validationResult = validator.Validate(customer);

            var customer = new Customer("bill smith", "bill@gmail.com", "90324510004");
            var validator = new CustomerValidator();
            var validationResult = validator.Validate(customer);

            if (validationResult.IsValid)
            {
                var customerRepository = new CustomerRepository(null);
                customerRepository.Create(customer);
            }

            //var customer = new Customer(MongoDB.Bson.ObjectId.Parse("644c28d6a654c612f0c4adc6"), "john connor", "john.connor@hotmail.com", "30324510004");
            //var validator = new CustomerValidator();
            //var validationResult = validator.Validate(customer);

            //if (validationResult.IsValid)
            //{
            //    var customerRepository = new CustomerRepository(null);
            //    customerRepository.Update(customer);
            //}

            //var customerRepository2 = new CustomerRepository(null);
            //customerRepository2.Delete(MongoDB.Bson.ObjectId.Parse("644c28d6a654c612f0c4adc6"));
        }
    }
}
