using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Controllers
{
    public class OrderController(IOrderService orderService) : Controller
    {
        [HttpPost]
        public async Task< IActionResult> Index(OrderAddDto orderAddDto)
        {
            IResponseResult result= await orderService.OrderAddAsync(orderAddDto);
            if (result.IsSuccessed)          
                return RedirectToAction("Index", "Basket",new {message = "Siparişiniz alındı :)"});            
            return RedirectToAction("Index", "Basket", new { message = $"Siparişiniz alınırken bir hata oluştu => {result.Error}" });
        }
    }

}
