
using FluentValidation;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Validations
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x=>x.Description).NotNull();
        }
    }
}
