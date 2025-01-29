using GeldiGeliyor.Core.Entities;
using GeldiGeliyor.Entities.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;


namespace GeldiGeliyor.Entities.Concrete
{
    public class Seller : Entity, IMasterBase
    {
        public Seller()
        {
            Status = Status.IsActive;
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public Status Status { get; set; }



        public ICollection<Product> Products { get; set; }
        public AppUser AppUser { get; set; }

    }
}
