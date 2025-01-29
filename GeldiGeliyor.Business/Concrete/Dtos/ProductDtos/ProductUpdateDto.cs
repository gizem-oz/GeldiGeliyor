using GeldiGeliyor.Business.Abstract;

namespace GeldiGeliyor.Business.Concrete.Dtos.ProductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}