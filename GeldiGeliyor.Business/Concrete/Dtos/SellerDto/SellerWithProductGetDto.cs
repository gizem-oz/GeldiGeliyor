using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete.Dtos.SellerDtos
{
    public class SellerWithProductGetDto : IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
        public List<Product> Products { get; set; }
    }
}