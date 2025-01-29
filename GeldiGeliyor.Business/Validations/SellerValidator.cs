using FluentValidation;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Validations
{
    public class SellerValidator:AbstractValidator<AppUser>
    {
        public SellerValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Seller).NotNull();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.PasswordHash).NotNull();
            RuleFor(x => x.UserName).NotNull();          
            RuleFor(x => x.PhoneNumber).NotNull();
            RuleFor(x => x.Customer).NotNull();
           

        }
    }
}
