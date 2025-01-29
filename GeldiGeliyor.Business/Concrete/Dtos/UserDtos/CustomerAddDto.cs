using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;

namespace GeldiGeliyor.Business.Concrete.Dtos.UserDtos
{
    public class CustomerAddDto : IDto
    {
        public int CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
