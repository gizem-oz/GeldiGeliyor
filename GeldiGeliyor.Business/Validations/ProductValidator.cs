using FluentValidation;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Validations
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.SellerId).NotNull();
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.StockAmount).NotNull();
            RuleFor(x => x.Price).NotNull();           
        }
    }
}
