using GeldiGeliyor.Business.Abstract;

namespace GeldiGeliyor.Business.Concrete.Dtos.UserDtos
{
    public class LoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
