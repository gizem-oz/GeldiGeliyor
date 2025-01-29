using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;

namespace GeldiGeliyor.Business.Concrete.Dtos.UserDtos
{
    public class SellerGetDto : IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }

        public DateTime CreateDate { get; set; } 
        public DateTime UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
