using GeldiGeliyor.WebUI.Models.BasketTransaction.BasketModels;

namespace GeldiGeliyor.WebUI.Models.BasketTransaction
{
    public interface IBasketTransaction
    {
        Basket GetOrCreateBasket();
        void AddOrUpdateItem(BasketItem basketItem);
        void Reduce(int productId);
        void Increase(int productId);
        void DeleteItem(int productId);
        void DeleteBasket();

        //create method about json format from basket

        string ConvertJson();
    }
}
