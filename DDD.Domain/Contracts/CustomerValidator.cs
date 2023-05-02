using FluentValidation;
using DDD.Domain.Entities;

namespace DDD.Domain.Contracts
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).MinimumLength(5).WithMessage("No less than 5 letters");
            RuleFor(customer => customer.Name).MaximumLength(60).WithMessage("No more than 60 letters");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Email invalid");
        }
    }
}
