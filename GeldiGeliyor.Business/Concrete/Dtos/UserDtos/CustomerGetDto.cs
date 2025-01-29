using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;

namespace GeldiGeliyor.Business.Concrete.Dtos.UserDtos
{
    public class CustomerGetDto : IDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
