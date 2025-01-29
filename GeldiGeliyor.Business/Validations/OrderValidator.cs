

using FluentValidation;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Validations
{
    public class OrderValidator :AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x=>x.CustomerId).NotNull();
            RuleFor(x=>x.Customer).NotNull();
            RuleFor(x=>x.CreateDate).NotNull();
            RuleFor(x=>x.DeliveryDate).NotNull();
            
        }
    }
}
