using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Index","Product") : View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(string username, string password)
        {
            //throw new Exception("Bilinen hata");
            var result = await _authService.SignInAsync(username, password);
            return result.Succeeded ? RedirectToAction("Index", "Product") : View();
        }
        [HttpGet]
        public async Task<IActionResult> CustomerRegister()
        {
           ICityService service = Request.HttpContext.RequestServices.GetService<ICityService>();
            ViewBag.Cities = await service.GetAllCityAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegister(CustomerAddDto customer)
        { 
            IdentityResult result =  await _authService.CustomerAddAsync(customer);
            return result.Succeeded ? RedirectToAction("Login") : View();
        }

        [HttpGet]
        public IActionResult SellerRegister()
        {

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> SellerRegister(SellerAddDto seller)
        {
            IdentityResult result = await _authService.SellerAddAsync(seller);
            return result.Succeeded ? RedirectToAction("Login") : View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
