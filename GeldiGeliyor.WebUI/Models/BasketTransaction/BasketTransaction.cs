using GeldiGeliyor.WebUI.Models.BasketTransaction.BasketModels;
using Newtonsoft.Json;

namespace GeldiGeliyor.WebUI.Models.BasketTransaction
{
    public class BasketTransaction(IHttpContextAccessor httpContextAccessor) : IBasketTransaction
    {
        const string key = "BizimSepetimizBu";
 public void AddOrUpdateItem(BasketItem _basketItem)
 {
     Basket basket = GetOrCreateBasket();
     BasketItem? basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == _basketItem.ProductId);

     if (basketItem is not null)
         basketItem.Quantity++;
     else
         basket.BasketItems.Add(_basketItem);

     string jsonBasket = JsonConvert.SerializeObject(basket);
     httpContextAccessor?.HttpContext?.Response.Cookies.Append(key, jsonBasket);
 }

 public string ConvertJson()
 {
     Basket basket = GetOrCreateBasket();
     string jsonBasket = JsonConvert.SerializeObject(basket);
     return jsonBasket;
 }

 public void DeleteBasket()
 {
     httpContextAccessor?.HttpContext?.Response.Cookies.Delete(key);

 }

 public void DeleteItem(int productId)
 {
     Basket basket = GetOrCreateBasket();
     BasketItem? basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
     if (basketItem is not null)
         basket.BasketItems.Remove(basketItem);
     string jsonBasket = JsonConvert.SerializeObject(basket);
     httpContextAccessor?.HttpContext?.Response.Cookies.Append(key, jsonBasket);
 }
 public Basket GetOrCreateBasket()
 {
     bool check = httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(key);
     string? cookie = httpContextAccessor.HttpContext.Request.Cookies[key];
     return check ? JsonConvert.DeserializeObject<Basket>(cookie) : new Basket()
     {
         BasketItems = new List<BasketItem>()
     };
 }
 public void Increase(int productId)
 {
     Basket basket = GetOrCreateBasket();
     BasketItem? basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
     if (basketItem is not null)
         basketItem.Quantity++;
     string serializeItem = JsonConvert.SerializeObject(basket);
     httpContextAccessor?.HttpContext?.Response.Cookies.Append(key, serializeItem);

 }
 public void Reduce(int productId)
 {
     Basket basket = GetOrCreateBasket();
     BasketItem? basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
     if (basketItem is not null)
     {
         if (basketItem?.Quantity > 1)
             basketItem.Quantity--;
         else
             basket.BasketItems.Remove(basketItem);
     }
     string jsonBasket = JsonConvert.SerializeObject(basket);
     httpContextAccessor?.HttpContext?.Response.Cookies.Append(key, jsonBasket);
 }       
    }
}
