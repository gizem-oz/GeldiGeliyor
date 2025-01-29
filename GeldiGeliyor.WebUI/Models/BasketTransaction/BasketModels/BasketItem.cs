namespace GeldiGeliyor.WebUI.Models.BasketTransaction.BasketModels
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int CategoryName { get; set; }
        public int SellerName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
