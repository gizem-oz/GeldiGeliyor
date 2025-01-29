using GeldiGeliyor.WebUI.Models.BasketTransaction;
using GeldiGeliyor.WebUI.Models.BasketTransaction.BasketModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Controllers
{
    public class BasketController(IBasketTransaction basketTransaction) : Controller
    {
        [Authorize]
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            Basket basket = basketTransaction.GetOrCreateBasket();
            return View(basket);
        }
        public IActionResult Reduce(int productId)
        {
            basketTransaction.Reduce(productId);
            return RedirectToAction("Index");
        }
        public IActionResult Increase(int productId)
        {
            basketTransaction.Increase(productId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveItem(int productId)
        {
            basketTransaction.DeleteItem(productId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveBasket()
        {
            basketTransaction.DeleteBasket();
            return RedirectToAction("Index");
        }
        public IActionResult AddBasketItem(BasketItem basketItem)
        {
            basketTransaction.AddOrUpdateItem(basketItem);
            return RedirectToAction("Index","Urun eklendi :)");
        }


    }
}
