
using FluentValidation;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Validations
{
    public class PictureValidator:AbstractValidator<Picture>
    {
        public PictureValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.Product).NotNull();
            RuleFor(x => x.Image).NotNull();
        }
    }
}
