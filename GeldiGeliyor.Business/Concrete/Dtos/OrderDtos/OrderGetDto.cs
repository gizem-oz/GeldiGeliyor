using GeldiGeliyor.Business.Abstract;

namespace GeldiGeliyor.Business.Concrete.Dtos.OrderDtos
{
    public class OrderGetDto : IDto

    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
