
using GeldiGeliyor.Business.Abstract;
namespace GeldiGeliyor.Business.Concrete.Dtos.OrderDtos
{
    public class OrderAddDto : IDto
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        
       
    }
}