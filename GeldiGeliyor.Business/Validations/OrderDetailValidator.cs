
using FluentValidation;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Validations
{
    public class OrderDetailValidator: AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(x => x.OrderId).NotNull();
            RuleFor(x => x.Order).NotNull();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.Product).NotNull();
            RuleFor(x => x.CreateDate).NotNull();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.DeleteDate).NotNull();
        }
    }
}
