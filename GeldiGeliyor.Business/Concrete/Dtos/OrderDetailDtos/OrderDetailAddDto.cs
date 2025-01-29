using GeldiGeliyor.Business.Abstract;

namespace GeldiGeliyor.Business.Concrete.Dtos.OrderDetailDtos
{
    public class OrderDetailAddDto : IDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }

    }
}