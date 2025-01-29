using GeldiGeliyor.Business.Abstract;

namespace GeldiGeliyor.Business.Concrete.Dtos.ProductDtos
{
    public class ProductAddDto : IDto
    {
    
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();


    }
}