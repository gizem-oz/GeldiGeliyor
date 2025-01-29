namespace GeldiGeliyor.WebUI.Models.BasketTransaction.BasketModels
{
    public class Basket
    {
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price*x.Quantity); }
    }
}
