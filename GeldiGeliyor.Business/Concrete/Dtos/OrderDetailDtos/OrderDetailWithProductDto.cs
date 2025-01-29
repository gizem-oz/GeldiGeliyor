using GeldiGeliyor.Business.Abstract;

namespace GeldiGeliyor.Business.Concrete.Dtos.OrderDetailDtos
{
    public class OrderDetailWithProductDto : IDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }


    }
}