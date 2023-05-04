using FluentValidation;
using DDD.Domain.Entities;

namespace DDD.Domain.Contracts
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.name).MinimumLength(5).WithMessage("No less than 5 letters");
            RuleFor(customer => customer.name).MaximumLength(60).WithMessage("No more than 60 letters");
            RuleFor(customer => customer.email).EmailAddress().WithMessage("Email invalid");
        }
    }
}
